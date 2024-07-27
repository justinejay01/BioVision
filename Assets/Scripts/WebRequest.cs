using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class WebRequest : MonoBehaviour
{
    public GameObject inputCanvas;
    public GameObject outputCanvas;

    private string server = "http://localhost:8080/biovision/";
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //Void

    public void Print_Manual() {
        LightWebviewAndroid.instance.open("http://localhost:8080/biovision/print_manual.php", LightWebviewAndroid.CloseMode.back);
    }

    public void Forgot_Password(){
        LightWebviewAndroid.instance.open("http://localhost:8080/biovision/student_forgotpass.php", LightWebviewAndroid.CloseMode.back);
    }

    public void Login_Admin()
    {
        string username = inputCanvas.transform.Find("inputUsername").GetComponent<TMP_InputField>().text;
        string password = inputCanvas.transform.Find("inputPassword").GetComponent<TMP_InputField>().text;

        StartCoroutine(AdminAcc_Login(new string[] { username, password }));
    }

    public void Login_Student()
    {
        string username = inputCanvas.transform.Find("inputUsername").GetComponent<TMP_InputField>().text;
        string password = inputCanvas.transform.Find("inputPassword").GetComponent<TMP_InputField>().text;

        StartCoroutine(StudentAcc_Login(new string[] { username, password }));
    }

    public void Register_Admin()
    {
        string school_id = inputCanvas.transform.Find("inputSchoolid").GetComponent<TMP_InputField>().text;
        string firstname = inputCanvas.transform.Find("inputFirstname").GetComponent<TMP_InputField>().text;
        string lastname = inputCanvas.transform.Find("inputLastname").GetComponent<TMP_InputField>().text;
        string dept = inputCanvas.transform.Find("inputDept").GetComponent<TMP_InputField>().text;
        string email = inputCanvas.transform.Find("inputEmail").GetComponent<TMP_InputField>().text;
        string username = inputCanvas.transform.Find("inputUsername").GetComponent<TMP_InputField>().text;
        string password = inputCanvas.transform.Find("inputPassword").GetComponent<TMP_InputField>().text;

        StartCoroutine(AdminAcc_Register(new string[] { school_id, firstname, lastname, dept, email, username, password }));
    }

    public void Register_Student()
    {
        string teacher_code = inputCanvas.transform.Find("inputTeacherCode").GetComponent<TMP_InputField>().text;
        string school_id = inputCanvas.transform.Find("inputSchoolid").GetComponent<TMP_InputField>().text;
        string firstname = inputCanvas.transform.Find("inputFirstname").GetComponent<TMP_InputField>().text;
        string lastname = inputCanvas.transform.Find("inputLastname").GetComponent<TMP_InputField>().text;
        string dept = inputCanvas.transform.Find("inputDept").GetComponent<TMP_InputField>().text;
        string year_lvl = inputCanvas.transform.Find("inputYear").GetComponent<TMP_InputField>().text;
        string section = inputCanvas.transform.Find("inputSection").GetComponent<TMP_InputField>().text;
        string strand = inputCanvas.transform.Find("inputStrand").GetComponent<TMP_InputField>().text;
        string email = inputCanvas.transform.Find("inputEmail").GetComponent<TMP_InputField>().text;
        string username = inputCanvas.transform.Find("inputUsername").GetComponent<TMP_InputField>().text;
        string password = inputCanvas.transform.Find("inputPassword").GetComponent<TMP_InputField>().text;

        StartCoroutine(StudentAcc_Register(new string[] { school_id, teacher_code, firstname, lastname, dept, year_lvl, section, strand, email, username, password }));
    }

    //Enum

    IEnumerator AdminAcc_Register(params string[] post_query)
    {
        string web_api = server + "auth/admin_register.php";

        WWWForm form = new WWWForm();
        form.AddField("id", post_query[0]);
        form.AddField("firstname", post_query[1]);
        form.AddField("lastname", post_query[2]);
        form.AddField("department", post_query[3]);
        form.AddField("email", post_query[4]);
        form.AddField("username", post_query[5]);
        form.AddField("password", post_query[6]);

        using (UnityWebRequest www = UnityWebRequest.Post(web_api, form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                if (post_query[5] == www.downloadHandler.text)
                {
                    outputCanvas.transform.Find("lblPrompt").GetComponent<TextMeshProUGUI>().text = "Success!";
                    outputCanvas.transform.Find("btnToAdminLogin").gameObject.SetActive(true);
                }
                else
                {
                    outputCanvas.transform.Find("lblPrompt").GetComponent<TextMeshProUGUI>().text = www.downloadHandler.text;
                }
            }
        }
        outputCanvas.SetActive(true);
    }

    IEnumerator StudentAcc_Register(params string[] post_query)
    {
        string web_api = server + "auth/student_register.php";

        WWWForm form = new WWWForm();
        form.AddField("id", post_query[0]);
        form.AddField("t_code", int.Parse(post_query[1]));
        form.AddField("firstname", post_query[2]);
        form.AddField("lastname", post_query[3]);
        form.AddField("department", post_query[4]);
        form.AddField("year_lvl", int.Parse(post_query[5]));
        form.AddField("section", post_query[6]);
        form.AddField("strand", post_query[7]);
        form.AddField("email", post_query[8]);
        form.AddField("username", post_query[9]);
        form.AddField("password", post_query[10]);

        using (UnityWebRequest www = UnityWebRequest.Post(web_api, form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                if (post_query[9] == www.downloadHandler.text)
                {
                    outputCanvas.transform.Find("lblPrompt").GetComponent<TextMeshProUGUI>().text = "Success!";
                    outputCanvas.transform.Find("btnToStudentLogin").gameObject.SetActive(true);
                }
                else
                {
                    outputCanvas.transform.Find("lblPrompt").GetComponent<TextMeshProUGUI>().text = www.downloadHandler.text;
                }
            }
        }
        outputCanvas.SetActive(true);
    }

    IEnumerator AdminAcc_Login(params string[] post_query)
    {
        string web_api = server + "auth/admin_login.php";

        WWWForm form = new WWWForm();
        form.AddField("username", post_query[0]);
        form.AddField("password", post_query[1]);

        using (UnityWebRequest www = UnityWebRequest.Post(web_api, form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                outputCanvas.transform.Find("lblPrompt").GetComponent<TextMeshProUGUI>().text = www.error;
            }
            else
            {
                if (post_query[0] == www.downloadHandler.text)
                {
                    outputCanvas.transform.Find("lblPrompt").GetComponent<TextMeshProUGUI>().text = "Success!";
                    outputCanvas.transform.Find("btnToMain").gameObject.SetActive(true);
                }
                else
                {
                    outputCanvas.transform.Find("lblPrompt").GetComponent<TextMeshProUGUI>().text = www.downloadHandler.text;
                }
            }
        }
        outputCanvas.SetActive(true);
    }

    IEnumerator StudentAcc_Login(params string[] post_query)
    {
        string web_api = server + "auth/student_login.php";

        WWWForm form = new WWWForm();
        form.AddField("username", post_query[0]);
        form.AddField("password", post_query[1]);

        using (UnityWebRequest www = UnityWebRequest.Post(web_api, form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                if (post_query[0] == www.downloadHandler.text)
                {
                    outputCanvas.transform.Find("lblPrompt").GetComponent<TextMeshProUGUI>().text = "Success!";
                    outputCanvas.transform.Find("btnToMain").gameObject.SetActive(true);

                    DataLoader data = new DataLoader();
                    data.name = post_query[0];
                    DataSaver.saveData(data, "login");
                }
                else
                {
                    outputCanvas.transform.Find("lblPrompt").GetComponent<TextMeshProUGUI>().text = www.downloadHandler.text;
                }
            }
        }
        outputCanvas.SetActive(true);
    }

    public IEnumerator GetProfileNameScore(Button btnProfile, string username)
    {
        TextMeshProUGUI teacher, name, score;
        
        teacher = btnProfile.transform.Find("txtTeacher").GetComponent<TextMeshProUGUI>();
        name = btnProfile.transform.Find("txtName").GetComponent<TextMeshProUGUI>();
        score = btnProfile.transform.Find("txtScore").GetComponent<TextMeshProUGUI>();

        using (UnityWebRequest webRequest = UnityWebRequest.Get(server + "auth/student_getprofile.php?username=" + username))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError("Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError("HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    var json = JSONProfileMain.CreateFromJSON(webRequest.downloadHandler.text);
                    teacher.SetText(json.teacher.ToString());
                    name.SetText(json.name.ToString());

                    break;
            }
        }
    }
}
