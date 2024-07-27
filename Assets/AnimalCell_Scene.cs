using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimalCell_Scene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SceneAdditive();
    }

    public void SceneAdditive()
    {
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            SceneManager.LoadScene("ARCamera", LoadSceneMode.Additive);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (SceneManager.GetActiveScene().buildIndex == 0) Application.Quit();
                else SceneManager.LoadScene("Main");
            }
        }
    }
}
