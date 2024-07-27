using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;
using Gpm.WebView;

public class StartQuiz : MonoBehaviour
{
    private string category;

    // FullScreen
    public void ShowUrlFullScreen()
    {
        DataLoader quizData = DataSaver.loadData<DataLoader>("quiz");
        if (quizData == null)
        {
            return;
        }

        category = quizData.name;

        LightWebviewAndroid.instance.open("http://localhost:8080/biovision/auth/quiz_question.php?category=" + category, LightWebviewAndroid.CloseMode.back);
        /* GpmWebView.ShowUrl(
            "http://localhost:8080/biovision/auth/quiz_question.php",
            new GpmWebViewRequest.Configuration()
            {
                style = GpmWebViewStyle.POPUP,
                orientation = GpmOrientation.PORTRAIT,
                isClearCookie = true,
                isClearCache = true,
                backgroundColor = "#FFFFFF",
                isNavigationBarVisible = true,
                navigationBarColor = "#335500",
                title = "BioVision",
                isBackButtonVisible = true,
                isForwardButtonVisible = true,
                isCloseButtonVisible = true,
                position = new GpmWebViewRequest.Position
                {
                    hasValue = true,
                    x = (int)(Screen.width * 0.05f),
                    y = (int)(Screen.height * 0.05f)
                },
                size = new GpmWebViewRequest.Size
                {
                    hasValue = true,
                    width = (int)(Screen.width * 0.95f),
                    height = (int)(Screen.height * 0.98f)
                },
                supportMultipleWindows = true,
    #if UNITY_IOS
                contentMode = GpmWebViewContentMode.MOBILE
    #endif
            },
            // See the end of the code example
            OnCallback,
            new List<string>()
            {
                "USER_ CUSTOM_SCHEME"
            }); */
    }

    // FullScreen
    public void ShowUrlFullScreen(string category)
    {
        LightWebviewAndroid.instance.open("http://localhost:8080/biovision/auth/quiz_question.php?category=" + category, LightWebviewAndroid.CloseMode.back);
    }

    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }


    // Popup default
    public void ShowUrlPopupDefault()
    {
        GpmWebView.ShowUrl(
            "https://google.com/",
            new GpmWebViewRequest.Configuration()
            {
                style = GpmWebViewStyle.POPUP,
                orientation = GpmOrientation.UNSPECIFIED,
                isClearCookie = true,
                isClearCache = true,
                isNavigationBarVisible = true,
                isCloseButtonVisible = true,
                supportMultipleWindows = true,
#if UNITY_IOS
            contentMode = GpmWebViewContentMode.MOBILE,
            isMaskViewVisible = true,
#endif
            },
            // See the end of the code example
            OnCallback,
            new List<string>()
            {
            "USER_ CUSTOM_SCHEME"
            });
    }

    // Popup custom position and size
    public void ShowUrlPopupPositionSize()
    {
        GpmWebView.ShowUrl(
            "https://google.com/",
            new GpmWebViewRequest.Configuration()
            {
                style = GpmWebViewStyle.POPUP,
                orientation = GpmOrientation.UNSPECIFIED,
                isClearCookie = true,
                isClearCache = true,
                isNavigationBarVisible = true,
                isCloseButtonVisible = true,
                position = new GpmWebViewRequest.Position
                {
                    hasValue = true,
                    x = (int)(Screen.width * 0.1f),
                    y = (int)(Screen.height * 0.1f)
                },
                size = new GpmWebViewRequest.Size
                {
                    hasValue = true,
                    width = (int)(Screen.width * 0.8f),
                    height = (int)(Screen.height * 0.8f)
                },
                supportMultipleWindows = true,
#if UNITY_IOS
            contentMode = GpmWebViewContentMode.MOBILE,
            isMaskViewVisible = true,
#endif
            }, null, null);
    }

    // Popup custom margins
    public void ShowUrlPopupMargins()
    {
        GpmWebView.ShowUrl(
            "https://google.com/",
            new GpmWebViewRequest.Configuration()
            {
                style = GpmWebViewStyle.POPUP,
                orientation = GpmOrientation.UNSPECIFIED,
                isClearCookie = true,
                isClearCache = true,
                isNavigationBarVisible = true,
                isCloseButtonVisible = true,
                margins = new GpmWebViewRequest.Margins
                {
                    hasValue = true,
                    left = (int)(Screen.width * 0.1f),
                    top = (int)(Screen.height * 0.1f),
                    right = (int)(Screen.width * 0.1f),
                    bottom = (int)(Screen.height * 0.1f)
                },
                supportMultipleWindows = true,
#if UNITY_IOS
            contentMode = GpmWebViewContentMode.MOBILE,
            isMaskViewVisible = true,
#endif
            }, null, null);
    }

    private void OnCallback(
        GpmWebViewCallback.CallbackType callbackType,
        string data,
        GpmWebViewError error)
    {
        Debug.Log("OnCallback: " + callbackType);
        switch (callbackType)
        {
            case GpmWebViewCallback.CallbackType.Open:
                if (error != null)
                {
                    Debug.LogFormat("Fail to open WebView. Error:{0}", error);
                }
                break;
            case GpmWebViewCallback.CallbackType.Close:
                if (error != null)
                {
                    Debug.LogFormat("Fail to close WebView. Error:{0}", error);
                }
                break;
            case GpmWebViewCallback.CallbackType.PageStarted:
                if (string.IsNullOrEmpty(data) == false)
                {
                    Debug.LogFormat("PageStarted Url : {0}", data);
                }
                break;
            case GpmWebViewCallback.CallbackType.PageLoad:
                if (string.IsNullOrEmpty(data) == false)
                {
                    Debug.LogFormat("Loaded Page:{0}", data);
                }
                break;
            case GpmWebViewCallback.CallbackType.MultiWindowOpen:
                Debug.Log("MultiWindowOpen");
                break;
            case GpmWebViewCallback.CallbackType.MultiWindowClose:
                Debug.Log("MultiWindowClose");
                break;
            case GpmWebViewCallback.CallbackType.Scheme:
                if (error == null)
                {
                    if (data.Equals("USER_ CUSTOM_SCHEME") == true || data.Contains("CUSTOM_SCHEME") == true)
                    {
                        Debug.Log(string.Format("scheme:{0}", data));
                    }
                }
                else
                {
                    Debug.Log(string.Format("Fail to custom scheme. Error:{0}", error));
                }
                break;
            case GpmWebViewCallback.CallbackType.GoBack:
                Debug.Log("GoBack");
                break;
            case GpmWebViewCallback.CallbackType.GoForward:
                Debug.Log("GoForward");
                break;
            case GpmWebViewCallback.CallbackType.ExecuteJavascript:
                Debug.LogFormat("ExecuteJavascript data : {0}, error : {1}", data, error);
                break;
#if UNITY_ANDROID
            case GpmWebViewCallback.CallbackType.BackButtonClose:
                Debug.Log("BackButtonClose");
                break;
#endif
        }
    }
    /* public class Quiz
    {
        public string id { get; set; }
        public string category { get; set; }
        public string question { get; set; }
        public string answer { get; set; }
        public string choices_1 { get; set; }
        public string choices_2 { get; set; }
        public string choices_3 { get; set; }
        public string choices_4 { get; set; }
    }
    // Start is called before the first frame update
    void Start()
    {
        DataLoader quizData = DataSaver.loadData<DataLoader>("quiz");
        if (quizData == null)
        {
            return;
        }

        string category = quizData.name;
        StartCoroutine(GetQuiz(category));

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GetQuiz(String category){
        string uri = "http://localhost:8080/biovision/auth/quiz_get.php?category=" + category;
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Quiz quiz = JsonConvert.DeserializeObject<Quiz>(webRequest.downloadHandler.text);
                    
                    break;
            }
        }
    } */
}
