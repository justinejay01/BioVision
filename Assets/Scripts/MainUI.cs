using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    public Button btnProfile;
    private WebRequest webRequest;

    // Start is called before the first frame update
    void Start()
    {
        webRequest = gameObject.AddComponent<WebRequest>();
        DataLoader loginData = DataSaver.loadData<DataLoader>("login");
        string login = loginData.name;

        StartCoroutine(webRequest.GetProfileNameScore(btnProfile, login));
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
