using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginPrompt : MonoBehaviour
{
    public GameObject canvas;
    public TMP_InputField password;
    // Start is called before the first frame update
    void Start()
    {
        password.contentType = TMP_InputField.ContentType.Password;
    }

    public void ShowPrompt()
    {
        canvas.SetActive(true);
    }

    public void HidePrompt()
    {
        canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (SceneManager.GetActiveScene().buildIndex == 0 || SceneManager.GetActiveScene().buildIndex == 2) HidePrompt();
            }
        }
    }
}
