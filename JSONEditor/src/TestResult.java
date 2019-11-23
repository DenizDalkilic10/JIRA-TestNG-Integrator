import org.json.simple.JSONObject;

public class TestResult {

    private String methodName;
    private String parameters;
    private String testResults;
    private String summary;
    private String description;
    private String status;

    public TestResult(String methodName, String parameters, String testResults, String summary, String description, String status) {
        this.methodName = methodName;
        this.parameters = parameters;
        this.testResults = testResults;
        this.summary = summary;
        this.description = description;
        this.status = status;
    }

    public JSONObject toJSONObject() {
        JSONObject obj = new JSONObject();
        obj.put("methodName", methodName);
        obj.put("parameters", parameters);
        obj.put("testResults", testResults);
        obj.put("summary", summary);
        obj.put("description", description);
        obj.put("status", status);

        return obj;
    }

    public String toString() {
       return methodName + " , " + parameters + " , " + testResults + " , " + summary + " , " + description + " , " + status + "\n";
    }

    public String getMethodName() {
        return methodName;
    }

    public void setMethodName(String methodName) {
        this.methodName = methodName;
    }

    public String getparameters() {
        return parameters;
    }

    public void setparameters(String parameters) {
        this.parameters = parameters;
    }

    public String gettestResults() {
        return testResults;
    }

    public void settestResults(String testResults) {
        this.testResults = testResults;
    }

    public String getSummary() {
        return summary;
    }

    public void setSummary(String summary) {
        this.summary = summary;
    }

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public String getStatus() {
        return status;
    }

    public void setStatus(String status) {
        this.status = status;
    }
}
