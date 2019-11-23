using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TestResultListCollection
{
    public TestResultList passedTests, failedTests;

    public TestResultListCollection()
    {
        passedTests = new TestResultList();
        failedTests = new TestResultList();
    }

    public TestResultList getfailedTests()
    {
        return failedTests;
    }

    public void setfailedTests(TestResultList failedTests)
    {
        this.failedTests = failedTests;
    }

    public TestResultList getpassedTests()
    {
        return passedTests;
    }

    public void setpassedTests(TestResultList passedTests)
    {
        this.passedTests = passedTests;
    }

    public string toString() {
        return "\n########################################Passed Tests########################################\n\n" + passedTests.toString() + "\n########################################Failed Tests########################################\n\n" + failedTests.toString();
    }
}
