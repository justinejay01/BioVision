using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AR3DMAnager : MonoBehaviour
{
    public Button arButton; // Cell Button
    public GameObject parentObj;

    private string objCell;
    private string lblCell;

    private Transform obj;
    private TextMeshProUGUI arText;

    // Start is called before the first frame update
    void Start()
    {
        DataLoader cellData = DataSaver.loadData<DataLoader>("cell");
        if (cellData == null)
        {
            return;
        }

        arText = arButton.GetComponentInChildren<TextMeshProUGUI>();

        if (!string.IsNullOrEmpty(cellData.obj))
        {
            objCell = cellData.obj;
            lblCell = cellData.name;

            Debug.Log("Object: " + objCell);
            obj = parentObj.transform.Find(objCell);
            arButton.enabled = true;
            arText.text = lblCell;

            switch(lblCell){
                case "Eukaryotic Cell":
                    obj.localScale = new Vector3(750, 750, 750);
                    break;
                case "Prokaryotic Cell":
                    obj.localScale = new Vector3(1400, 1400, 1400);
                    break;
                case "Animal Cell":
                    obj.localScale = new Vector3(850, 850, 850);
                    break;
                case "Plant Cell":
                    obj.localScale = new Vector3(900, 900, 900);
                    break;
                case "Red Blood Cell":
                    obj.localScale = new Vector3(150, 150, 150);
                    parentObj.transform.Find("CellParts").transform.Find("Erythrocyte").gameObject.SetActive(true);
                    parentObj.transform.Find("btnNext").gameObject.SetActive(false);
                    break;
                case "White Blood Cell":
                    obj.localScale = new Vector3(300, 300, 300);
                    parentObj.transform.Find("CellParts").transform.Find("Leukocyte").gameObject.SetActive(true);
                    parentObj.transform.Find("btnNext").gameObject.SetActive(false);
                    break;
            }

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
