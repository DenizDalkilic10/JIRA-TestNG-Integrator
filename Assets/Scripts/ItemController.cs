using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class ItemController : MonoBehaviour
{
    public string testMethod;
    public string parameters;
    public string testResults;
    public string description;
    public string summary;
    public string requirement;
    public Text textObject;
    public GameObject canvas;
    public Button createIssueButton;
    Text[] texts;

    // Use this for initialization
    void Start()
    {
        canvas = GameObject.Find("Canvas");
        Transform panel = canvas.transform.Find("Panel");
        texts = panel.GetComponentsInChildren<Text>();
        createIssueButton = panel.GetComponentInChildren<Button>();

        if (texts != null) {
            texts[0].text = "Create Bug";
            texts[1].text = "Test Method";
            texts[2].text = "Parameters";
            texts[3].text = "Test Results";
        }
        textObject.text = testMethod;
    }

    // Update is called once per frame
    void Update()
    {
        if (textObject.text == "")
        {
            textObject.text = testMethod;
        }
    }


    public void setTestDetails() {
        texts[0].text = "Create Bug";
        texts[1].text = testMethod + ",  Requirement No: " + requirement ;
        texts[2].text = parameters;
        if(testResults != "Passed")
            texts[3].text =  Regex.Replace(testResults.Substring(1, testResults.Length - 2), @"\t|\n|\r", "");
        else
            texts[3].text = testResults;
    }
}
