using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ARManager0 : MonoBehaviour
{
    public GameObject arFab;
    public GameObject adFab;
    public GameObject arContainer;
    public TextMeshProUGUI txtObject;
    public string arObject;
    // Start is called before the first frame update
    void Start()
    {
        
        txtObject.text = "Cell";
    }

    public void OnAfterTargetFound() 
    {
        GameObject arDupli = Instantiate(arFab, new Vector3(0, 0), arFab.transform.rotation);
        
        txtObject.text = arObject;
    }

    public void OnTargetFound()
    {
        adFab.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, 3);
        arContainer.SetActive(false);
        arFab.SetActive(true);

        txtObject.text = arObject;
    }

    public void OnTargetLost()
    {
        adFab.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, 3);
        arContainer.SetActive(true);
        arFab.SetActive(false);

        txtObject.text = arObject;
    }

    public void OnTargetDestroy()
    {
        var ar = new List<GameObject>();
        foreach (Transform child in arContainer.transform) ar.Add(child.gameObject);
        ar.ForEach(child => Destroy(child) );

        txtObject.text = arObject;
    }

    // Update is called once per frame
    void Update()
    {
        adFab.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, 3);
    }

}
