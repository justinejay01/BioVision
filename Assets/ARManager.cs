using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ARManager : MonoBehaviour
{
    public Button arButton; // Cell Button
    public string arLabel; // Cell Name
    public string arObject; // Cell 3D Object
    public GameObject parentObj;

    private TextMeshProUGUI arText;

    // Start is called before the first frame update
    void Start()
    {
        arButton.enabled = false;
    }

    public void OnTargetFound()
    {
        DataLoader data = new DataLoader
        {
            name = arLabel,
            obj = arObject
        };
        DataSaver.saveData(data, "cell");

        arText = arButton.GetComponentInChildren<TextMeshProUGUI>();
        arText.text = arLabel;
        arButton.enabled = true;
    }

    public void OnTargetLost()
    {
        arText = arButton.GetComponentInChildren<TextMeshProUGUI>();
        arText.text = "Cell";
        arButton.enabled = false;
    }

    public void SwitchToObject()
    {
        SceneManager.LoadScene("Cell3D");
    }

    // Update is called once per frame
    void Update()
    {

    }

    // For debugging purposes only
    private void CellDebug()
    {
        DataLoader cellData = DataSaver.loadData<DataLoader>("cell");
        if (cellData == null)
        {
            return;
        }

        Debug.Log("cell: " + cellData.obj);
    }
}