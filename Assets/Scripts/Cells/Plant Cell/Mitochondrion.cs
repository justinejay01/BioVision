using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class Mitochondrion : MonoBehaviour
{
    //private GameObject obj;
    // Start is called before the first frame update;
    void Start()
    {

    }

    public void OnTouch(GameObject obj)
    {
        //square.SetActive(true);

        obj.transform.Find("Mitochondrion").transform.Find("MitoSq").gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
