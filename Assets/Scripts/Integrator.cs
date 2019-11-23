using UnityEngine;
using UnityEditor;
using System.Collections;
using UnityEngine.Networking;
using System.Text;
using SimpleJSON;
using UnityEngine.SceneManagement;

public class Integrator : MonoBehaviour
{
    private static Integrator _instance;

    public static Integrator Instance { get { return _instance; } }

    public enum REQUESTTYPE { POST, GET, PUT };
    public enum OPERATIONTYPE { CREATEISSUE, AUTHORIZATION };

    private static string createissue_url = "http://10.150.0.164:8080/rest/api/2/issue";
    private static string authorization_url = "http://10.150.0.164:8080/rest/auth/1/session";
    private static string request;
    private static string response;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public IEnumerator CreateIssue(string testMethod, string parameters, string testResults, string description, string summary)
    {

        /////////////////////////////////////////////AUTHORIZATION/////////////////////////////////////////////////

        string body = "";
        //string JSESSIONID = "";

        //body = createSessionJSON(SessionInfo.username,SessionInfo.password);
        
        //var authRequest = new UnityWebRequest(authorization_url, "POST");
        //byte[] bodyRaw = Encoding.UTF8.GetBytes(body);
        //authRequest.uploadHandler = new UploadHandlerRaw(bodyRaw);
        //authRequest.downloadHandler = new DownloadHandlerBuffer();
        //authRequest.SetRequestHeader("Content-Type", "application/json");
        //yield return authRequest.SendWebRequest();
        //response = authRequest.downloadHandler.text;
        //JSONNode responseJSONNode = JSON.Parse(response);
        //JSESSIONID = responseJSONNode["session"]["value"];
        //Debug.Log(response);

        /////////////////////////////////////////////CREATE ISSUE/////////////////////////////////////////////////

        body = createIssueJSON(testMethod,parameters,testResults,description,summary);

        var bugRequest = new UnityWebRequest(createissue_url, "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(body);
        bugRequest.uploadHandler = new UploadHandlerRaw(bodyRaw);
        bugRequest.downloadHandler = new DownloadHandlerBuffer();
        bugRequest.SetRequestHeader("Content-Type", "application/json");
        bugRequest.SetRequestHeader("Cookie", "JSESSIONID=" + SessionInfo.JSESSIONID);
        yield return bugRequest.SendWebRequest();
        response = bugRequest.downloadHandler.text;
        Debug.Log(response);
    }

    public IEnumerator MaintainAuthorization(string username, string password, string projectKey) {

        SessionInfo.username = username;
        SessionInfo.password = password;
        SessionInfo.projectKey = projectKey;

        string body = createSessionJSON(SessionInfo.username, SessionInfo.password);

        var authRequest = new UnityWebRequest(authorization_url, "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(body);
        authRequest.uploadHandler = new UploadHandlerRaw(bodyRaw);
        authRequest.downloadHandler = new DownloadHandlerBuffer();
        authRequest.SetRequestHeader("Content-Type", "application/json");
        yield return authRequest.SendWebRequest();

        Debug.Log(authRequest.responseCode + " , " + authRequest.downloadHandler.text);

        if (authRequest.responseCode == 200)
        {
            response = authRequest.downloadHandler.text;
            JSONNode responseJSONNode = JSON.Parse(response);
            SessionInfo.JSESSIONID = responseJSONNode["session"]["value"];
            SceneManager.LoadScene("SelectFile");
        }
        
    }

    public string createIssueJSON(string testMethod, string parameters, string testResults, string description , string summary) {
        JSONObject createIssueJSON = new JSONObject();
        JSONObject fieldsJSON = new JSONObject();

        JSONObject projectJSON = new JSONObject();
        projectJSON.AddField("key", SessionInfo.projectKey);

        JSONObject issueTypeJSON = new JSONObject();
        issueTypeJSON.AddField("name", "Bug");

        JSONObject customField_10101_JSON = new JSONObject();
        customField_10101_JSON.AddField("id", "10104");

        fieldsJSON.AddField("project", projectJSON);
        fieldsJSON.AddField("issuetype", issueTypeJSON);
        fieldsJSON.AddField("summary", summary + " Method Name: " + testMethod);
        fieldsJSON.AddField("description", description + " Test Result: " + testResults + " Test Parameters: " + parameters);
        fieldsJSON.AddField("customfield_10101", customField_10101_JSON);

        createIssueJSON.AddField("fields", fieldsJSON);

        return createIssueJSON.ToString();
    }

    public string createSessionJSON(string username, string password)
    {
        JSONObject authJSON = new JSONObject();
        authJSON.AddField("username", username);
        authJSON.AddField("password", password);

        return authJSON.ToString();
    }

    public struct SessionInfo { 
        public static string username = "";
        public static string password = "";
        public static string JSESSIONID = "";
        public static string projectKey = "";
    }
}