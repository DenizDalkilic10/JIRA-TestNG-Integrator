using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListController : MonoBehaviour
{
    [HideInInspector]
    public enum ListType { FAILED, PASSED};
    
    public ListType listType;
    private GameObject controller;
    private Controller controllerScript;
    public GameObject listItem;
    
    TestResultList testsList = new TestResultList();
    // Start is called before the first frame update
    void Start()
    {
        controllerScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<Controller>();

        if (listType == ListType.FAILED) {
            testsList = controllerScript.collection.getfailedTests();
        } else if (listType == ListType.PASSED) {
            testsList = controllerScript.collection.getpassedTests();
        }

        foreach (TestResult res in testsList.testDetails) {
            var obj = Instantiate(listItem);
            obj.transform.parent = gameObject.transform;

            var script = obj.GetComponent<ItemController>();
            script.testMethod = res.testMethod;
            script.parameters = res.parameters;
            script.testResults = res.testResults;
            script.description = res.description;
            script.summary = res.summary;
            script.requirement = res.requirement;

        }
        Debug.Log(testsList.toString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
