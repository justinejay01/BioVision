using UnityEngine;

public class Init : MonoBehaviour
{
    public string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SceneAdditive>().PlayScene(sceneName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
