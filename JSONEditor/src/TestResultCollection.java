import java.util.ArrayList;

public class TestResultCollection {

    private ArrayList<TestResult> passedtestResults, failedtestResults;
    private int numberOfTestResults, numberOfFailedTestResults, numberOfPassedTestResults;

    public TestResultCollection() {
        passedtestResults = new ArrayList<TestResult>();
        failedtestResults = new ArrayList<TestResult>();
        numberOfTestResults = 0;
        numberOfFailedTestResults = 0;
        numberOfPassedTestResults = 0;
    }

    public void addTestResult(TestResult result) {
        if (result.getStatus().equals("passed")) {
            passedtestResults.add(result);
            numberOfPassedTestResults = passedtestResults.size();
        } else if (result.getStatus().equals("failed")) {
            failedtestResults.add(result);
            numberOfFailedTestResults = failedtestResults.size();
        }
    }

    public int getNumberOfTestResults() {
        return numberOfTestResults;
    }

    public void setNumberOfTestResults(int numberOfTestResults) {
        this.numberOfTestResults = numberOfTestResults;
    }

    public int getNumberOfFailedTestResults() {
        return numberOfFailedTestResults;
    }

    public void setNumberOfFailedTestResults(int numberOfFailedTestResults) {
        this.numberOfFailedTestResults = numberOfFailedTestResults;
    }

    public int getNumberOfPassedTestResults() {
        return numberOfPassedTestResults;
    }

    public void setNumberOfPassedTestResults(int numberOfPassedTestResults) {
        this.numberOfPassedTestResults = numberOfPassedTestResults;
    }

    public ArrayList<TestResult> getFailedtestResults() {
        return failedtestResults;
    }

    public void setFailedtestResults(ArrayList<TestResult> failedtestResults) {
        this.failedtestResults = failedtestResults;
    }

    public ArrayList<TestResult> getPassedtestResults() {
        return passedtestResults;
    }

    public void setPassedtestResults(ArrayList<TestResult> passedtestResults) {
        this.passedtestResults = passedtestResults;
    }
}
