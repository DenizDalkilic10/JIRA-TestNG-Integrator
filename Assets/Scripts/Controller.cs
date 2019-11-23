using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
using System.IO;
using SFB;

public class Controller : MonoBehaviour
{
    static string resourceLocation; //"C:\\Users\\asus\\Desktop\\Test_Results.txt";
    public TestResultListCollection collection = new TestResultListCollection();
    private FileController fileController;
    public Text passedTitle;
    public Text failedTitle;

    // Start is called before the first frame update
    void Start()
    {
        fileController = GameObject.FindGameObjectWithTag("GameController").GetComponent<FileController>();
        resourceLocation = FileController.path;
        TestResultList failedTestsList = new TestResultList();
        TestResultList passedTestsList = new TestResultList();

        StreamReader reader = new StreamReader(resourceLocation);
        string json = reader.ReadToEnd();
        reader.Close();

        // use simpleJSON to get values stored in JSON data for different key value pair
        JSONNode jsonNode = SimpleJSON.JSON.Parse(json);

        //Passed and Failed Tests
        JSONArray failedTestsJson = jsonNode["failedTests"]["testDetails"].AsArray;
        JSONArray passedTestsJson = jsonNode["passedTests"]["testDetails"].AsArray;

        IEnumerable<JSONNode> failedTestNodes = failedTestsJson.Children;
        IEnumerable<JSONNode> passedTestNodes = passedTestsJson.Children;

        foreach (JSONNode node in failedTestNodes) {
            TestResult res = new TestResult(node["testMethod"], node["parameters"], node["testResults"], node["summary"], node["description"],node["requirement"]);
            failedTestsList.addTestResult(res);
        }

        collection.setfailedTests(failedTestsList);

        foreach (JSONNode node in passedTestNodes)
        {
            TestResult res = new TestResult(node["testMethod"], node["parameters"], node["testResults"], node["summary"], node["description"], node["requirement"]);
            passedTestsList.addTestResult(res);
        }

        collection.setpassedTests(passedTestsList);

        failedTitle.text = "F A I L E D ( " + collection.getfailedTests().getSize() + " )";
        passedTitle.text = "P A S S E D ( " + collection.getpassedTests().getSize() + " )";

        //Debug.Log(collection.toString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
