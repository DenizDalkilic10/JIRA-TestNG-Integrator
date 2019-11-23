using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TestResult
{
    public string testMethod;
    public string parameters;
    public string testResults;
    public string summary;
    public string description;
    public string requirement;
    

    public TestResult(string testMethod, string parameters, string testResults, string summary, string description, string requirement)
    {
        this.testMethod = testMethod;
        this.parameters = parameters;
        this.testResults = testResults;
        this.summary = summary;
        this.description = description;
        this.requirement = requirement;
    }

    public JSONObject toJSONObject()
    {
        JSONObject obj = new JSONObject();
        
        obj.SetField("testMethod", testMethod);
        obj.SetField("parameters", parameters);
        obj.SetField("testResults", testResults);
        obj.SetField("summary", summary);
        obj.SetField("description", description);
        obj.SetField("requirement" , requirement);

        return obj;
    }

    public string toString()
    {
        return testMethod + " , " + parameters + " , " + testResults + " , " + summary + " , " + description + " , " + requirement +"\n";
    }

    public string gettestMethod()
    {
        return testMethod;
    }

    public void settestMethod(string testMethod)
    {
        this.testMethod = testMethod;
    }

    public string getparameters()
    {
        return parameters;
    }

    public void setparameters(string parameters)
    {
        this.parameters = parameters;
    }

    public string gettestResults()
    {
        return testResults;
    }

    public void settestResults(string testResults)
    {
        this.testResults = testResults;
    }

    public string getSummary()
    {
        return summary;
    }

    public void setSummary(string summary)
    {
        this.summary = summary;
    }

    public string getRequirement()
    {
        return requirement;
    }

    public void setRequirement(string requirement)
    {
        this.requirement = requirement;
    }

    public string getDescription()
    {
        return description;
    }

    public void setDescription(string description)
    {
        this.description = description;
    }

}
