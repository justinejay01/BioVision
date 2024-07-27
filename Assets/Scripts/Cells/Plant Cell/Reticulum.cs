using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class Reticulum : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public void OnTouch()
    {
        //square.SetActive(true);
        GameObject.Find("ReticulumSq").SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
