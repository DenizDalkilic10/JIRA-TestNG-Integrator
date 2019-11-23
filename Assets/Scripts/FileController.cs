using UnityEngine;
using UnityEditor;
using SFB;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FileController : MonoBehaviour
{
    public static string path;
    public Text text;

    public void Open()
    {
        var paths = StandaloneFileBrowser.OpenFilePanel("Open File", "", "", false);
        path = paths[0];
        EventSystem.current.SetSelectedGameObject(null);
        text.text = path;
    }

    public void Navigate() {
        SceneManager.LoadScene("ViewTestResults");
    }
}