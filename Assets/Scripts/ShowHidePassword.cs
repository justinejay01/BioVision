using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowHidePassword : MonoBehaviour
{
    public Sprite ShowPassword;
    public Sprite HidePassword;
    public Button btn;
    public TMP_InputField password;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnEyeClicked()
    {
        if(btn.image.sprite == ShowPassword)
        {
            password.contentType = TMP_InputField.ContentType.Standard;
            btn.image.sprite = HidePassword;
        }
        else
        {
            password.contentType = TMP_InputField.ContentType.Password;
            btn.image.sprite = ShowPassword;
        }
        password.ForceLabelUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
