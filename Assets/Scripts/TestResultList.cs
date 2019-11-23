using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TestResultList
{
    public List<TestResult> testDetails;
    // Use this for initialization
    public TestResultList() {
        testDetails = new List<TestResult>();
    }

    public void addTestResult(TestResult result)
    {
        testDetails.Add(result);
    }

    public int getSize() {
        return testDetails.Count;
    }

    public string toString() {
        string str = "";
        foreach (TestResult res in testDetails) {
            str += res.toString();
        }

        return str;
    }
}
