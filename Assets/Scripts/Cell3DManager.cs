using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Cell3DManager : MonoBehaviour
{
    public GameObject square; 

    // Start is called before the first frame update
    void Start()
    {

    }

    public void OnTouch()
    {
        square.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
