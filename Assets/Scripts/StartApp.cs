using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartApp : MonoBehaviour
{
    public GameObject exitPrompt;
    //public TMP_InputField password;

    void Start()
    {
        DataLoader data = new DataLoader();
        data.name = "";
        DataSaver.saveData(data, "scene");

    }

    void ShowExitPrompt()
    {
        exitPrompt.SetActive(true);
    }

    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (SceneManager.GetActiveScene().buildIndex == 0 || SceneManager.GetActiveScene().buildIndex == 2) ShowExitPrompt();
            }
        }
    }

    public void Quit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
