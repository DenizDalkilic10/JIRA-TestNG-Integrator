import org.json.simple.JSONArray;
import org.json.simple.JSONObject;
import org.json.simple.parser.JSONParser;
import java.io.FileReader;
import java.util.Iterator;


public class Main {

    static String resourceLocation = "C:\\Users\\asus\\Desktop\\Test_Results.txt";
    static TestResultCollection collection = new TestResultCollection();

    public static void main(String[] args) {
        JSONParser parser = new JSONParser();

        try {

            Object obj = parser.parse(new FileReader(
                    resourceLocation));

            JSONObject jsonObject = (JSONObject) obj;

            JSONObject failedTests = (JSONObject) jsonObject.get("failedTests");
            JSONObject passedTests = (JSONObject) jsonObject.get("passedTests");

            JSONArray failedTestResults = (JSONArray) failedTests.get("testDetails");
            JSONArray passedTestResults = (JSONArray) passedTests.get("testDetails");

            Iterator<JSONObject> iterator = failedTestResults.iterator();
            generateTestResultCollection(iterator, "failed");

            iterator = passedTestResults.iterator();
            generateTestResultCollection(iterator, "passed");

            displayResults();

        } catch (Exception e) {
            e.printStackTrace();
        }

    }

    private static void displayResults() {
        System.out.println("\nTest Results\n");
        System.out.println("Passed Test Cases ("+ collection.getNumberOfPassedTestResults()+")\n");
        for (TestResult res : collection.getPassedtestResults()){
            System.out.println(res.toString());
        }

        System.out.println("Failed Test Cases ("+ collection.getNumberOfFailedTestResults()+")\n");
        for (TestResult res : collection.getFailedtestResults()){
            System.out.println(res.toString());
        }
    }


    private static void generateTestResultCollection(Iterator<JSONObject> iterator, String status) {
        while (iterator.hasNext()) {
            JSONObject testResultObj = iterator.next();
            String methodName = (String) testResultObj.get("testMethod");
            String parameters = (String) testResultObj.get("parameters");
            String testResults = (String) testResultObj.get("testResults");
            String summary = (String) testResultObj.get("summary");
            String description = (String) testResultObj.get("description");

            TestResult testResult = new TestResult(methodName,parameters,testResults,summary,description,status);
            collection.addTestResult(testResult);
        }
    }
}
