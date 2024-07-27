using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScreen : MonoBehaviour
{
    public string switchToScene;
    private string backToScene;

    void Start()
    {
        if (string.IsNullOrEmpty(switchToScene)) backToScene = GetSceneFromDataSaver();
        else backToScene = switchToScene;
    }
    public void SwitchToScene(string sceneName)
    {
        DataLoader data = new DataLoader();
        string scene;
        switch (sceneName)
        {
            case "Animal3D":
                data.name = "Animal Cell";
                data.obj = "3D_AnimalCell";
                DataSaver.saveData(data, "cell");
                scene = "Cell3D";
                break;
            case "Plant3D":
                data.name = "Plant Cell";
                data.obj = "3D_PlantCell";
                DataSaver.saveData(data, "cell");
                scene = "Cell3D";
                break;
            case "QuizEukaryotic":
                data.name = "Eukaryotic Cell";
                DataSaver.saveData(data, "quiz");
                scene = "Quiz";
                break;
            case "QuizProkaryotic":
                data.name = "Prokaryotic Cell";
                DataSaver.saveData(data, "quiz");
                scene = "Quiz";
                break;
            case "QuizAnimal":
                data.name = "Animal Cell";
                DataSaver.saveData(data, "quiz");
                scene = "Quiz";
                break;
            case "QuizPlant":
                data.name = "Plant Cell";
                DataSaver.saveData(data, "quiz");
                scene = "Quiz";
                break;
            default:
                scene = sceneName;
                break;
        };

        SetSceneToDataSaver();
        SceneManager.LoadScene(scene);
    }

    public void BackToPrevScene()
    {
        SceneManager.LoadScene(backToScene);
    }

    private void SetSceneToDataSaver()
    {
        DataLoader data = new DataLoader();
        data.name = SceneManager.GetActiveScene().name;
        DataSaver.saveData(data, "scene");
    }

    private string GetSceneFromDataSaver()
    {
        DataLoader sceneData = DataSaver.loadData<DataLoader>("scene");
        string scene = sceneData.name;
        return scene;
    }

    //Print
    public void SwitchToPrint()
    {

    }

    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (string.IsNullOrEmpty(switchToScene))
                {
                    if (SceneManager.GetActiveScene().buildIndex != 0 || SceneManager.GetActiveScene().buildIndex != 2) SceneManager.LoadScene(backToScene);
                }
                else
                {
                    if (SceneManager.GetActiveScene().buildIndex != 0 || SceneManager.GetActiveScene().buildIndex != 2) SceneManager.LoadScene(switchToScene);
                }
            }
        }
    }
}
