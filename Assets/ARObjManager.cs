using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ARObjManager : MonoBehaviour
{
    //public string switchToScene;
    //public string arObject;
    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "CellCam")
        {
            if (PlayerPrefs.HasKey("obj"))
            {
                GameObject obj = GameObject.Find(PlayerPrefs.GetString("obj"));
                obj.SetActive(true);
            }
        }
    }
    public void SwitchToScene(string arObject)
    {
        PlayerPrefs.SetString("obj", arObject);
        SceneManager.LoadScene("CellCam");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
