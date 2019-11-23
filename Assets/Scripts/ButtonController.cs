using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public string testMethod, parameters, testResults, description, summary,username,password,projectKey;
    public Text TestMethod, Parameters, TestResults, Description, Summary,Username,Password,ProjectKey;
    public static Integrator integrator;

    private void Start()
    {
        integrator = new Integrator();
    }

    public void createIssue() {
        testMethod = TestMethod.text;
        parameters = Parameters.text;
        testResults = TestResults.text;
        description = Description.text;
        summary = Summary.text;

        SendPostRequest();

       // Debug.Log(testMethod + " , " + parameters + " , " + testResults + " , " + description + " , " + summary);
    }

    public void createSession() {
        username = Username.text;
        password = Password.text;
        projectKey = ProjectKey.text;

        CreateSessionRequest();

        //Debug.Log(username + " , " + password + " , " + projectKey);
    }

    public void SendPostRequest()
    {
        StartCoroutine(integrator.CreateIssue(testMethod,parameters,testResults,description,summary));
    }

    public void CreateSessionRequest() {
        StartCoroutine(integrator.MaintainAuthorization(username, password,projectKey));
    }
}
