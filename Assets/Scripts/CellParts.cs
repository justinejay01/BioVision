using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CellParts : MonoBehaviour
{
    public GameObject cellLabel;
    public GameObject parentObj;
    public GameObject cellPartsLbl;

    private TextMeshProUGUI cellText;
    private string cellTxt;
    private Transform obj;
    private GameObject btn_prev, btn_next;
    private new string name;
    private string index;
    private int c;

    private string[] animalCell, plantCell, eukaryoticCell, prokaryoticCell;

    private string[] cellParts = { "Cell Envelope", "Central Vacuole", "Chloroplast", "Cytoplasm", "Cytoskeleton", "Cytosol", "Endoplasmic Reticulum", "Golgi Apparatus", "Lysosomes", "Mesosomes", "Mitochondrion", "Nucleus", "Plasma Membrane", "Ribosomes" };
    private string[] prokaryoticCellPartsLoc = { "0, -150, 2500", "-1075, -700, 2500", "", "", "", "", "", "", "", "", "350, -700, 2500", "", "", "-480, -700, 2500", "-145, -140, 2500" };
    private string[] prokaryoticCellPartsScale = { "1400", "5000", "", "", "", "", "", "", "", "", "5000", "", "", "5000", "5000" };

    private string[] plantCellPartsLoc = { "0, 0, 9000", "-800, -810, 9000", "500, 50, 9000", "-600, 550, 9000", "-300, 275, 9000", "1315, 715, 9000", "", "140, -250, 9000", "-500, 150, 9000", "-815, -200, 9000", "", "-450, 420, 9000", "-250, -400, 9000", "700, -800, 9000", "-420, -535, 9000" };

    private string[] plantCellPartsScale = { "900", "2500", "2500", "2500", "2500", "5000", "", "2500", "2500", "2500", "", "2500", "2500", "2500", "9000" };

    private string[] animalCellPartsLoc = { "0, 0, 9000", "", "", "", "300, 300, 9000", "1050, 140, 9000", "", "-1000, 700, 9000", "-35, 230, 9000", "350, -480, 9000", "", "900, 750, 9000", "-1000, 270, 9000", "-1300, -600, 9000", "-1255, -280, 9000" };

    private string[] animalCellPartsScale = { "850", "", "", "", "3000", "5000", "", "3000", "3000", "3000", "", "3000", "3000", "3000", "9000" };

    private string[] eukaryoticCellPartsLoc = { "0, 0, 1000", "3300, 0, 1000", "-900, 0, 1000", "", "-300, 750, 1000", "315, 1230, 1000", "", "1600, -180, 1000", "160, 50, 1000", "-160, -300, 1000", "", "250, -730, 1000", "1130, -175, 1000", "900, -1250, 1000", "2300, 110, 1000" };

    private string[] eukaryoticCellPartsScale = { "750", "5000", "3000", "", "5000", "5000", "", "5000", "3000", "3000", "", "3000", "3000", "3000", "9000" };

    // Start is called before the first frame update
    void Start()
    {
        cellText = cellLabel.GetComponentInChildren<TextMeshProUGUI>();
        cellText.text = "Plant Cell";
        btn_prev = parentObj.transform.Find("btnPrev").gameObject;
        btn_next = parentObj.transform.Find("btnNext").gameObject;
        btn_prev.SetActive(false);
    }

    void DisplayCells(Cells cells, int cell, bool prev, bool next)
    {
        string[] init_loc, init_scale;

        if (cells == Cells.EUKARYOTIC_CELL)
        {
            init_loc = eukaryoticCellPartsLoc;
            init_scale = eukaryoticCellPartsScale;
        }
        else if (cells == Cells.PROKARYOTIC_CELL)
        {
            init_loc = prokaryoticCellPartsLoc;
            init_scale = prokaryoticCellPartsScale;
        }
        else if (cells == Cells.ANIMAL_CELL)
        {
            init_loc = animalCellPartsLoc;
            init_scale = animalCellPartsScale;
        }
        else if (cells == Cells.PLANT_CELL)
        {
            init_loc = plantCellPartsLoc;
            init_scale = plantCellPartsScale;
        }
        else
        {
            return;
        }

        btn_prev.SetActive(prev);
        btn_next.SetActive(next);
        int index = cell;
        cellText.text = cellParts[index];
        float locX = float.Parse(init_loc[index + 1].Split(',')[0]);
        float locY = float.Parse(init_loc[index + 1].Split(',')[1]);
        float locZ = float.Parse(init_loc[index + 1].Split(',')[2]);
        float scale = float.Parse(init_scale[index + 1]);
        obj.localPosition = new Vector3(locX, locY, locZ);
        obj.localScale = new Vector3(scale, scale, scale);
        for (int i = 0; i < c; i++)
        {
            cellPartsLbl.transform.GetChild(i).gameObject.SetActive(false);
        }

        cellPartsLbl.transform.Find(cellParts[index]).gameObject.SetActive(true);
    }

    void DisplayCells(Cells cells, string cell, bool prev, bool next)
    {
        btn_prev.SetActive(prev);
        btn_next.SetActive(next);
        cellText.text = cell;

        if (cells == Cells.EUKARYOTIC_CELL)
        {
            obj.localPosition = new Vector3(0, 0, 1000);
            obj.localScale = new Vector3(750, 750, 750);
        }
        else if (cells == Cells.PROKARYOTIC_CELL)
        {
            obj.localPosition = new Vector3(0, -200, 211);
            obj.localScale = new Vector3(1000, 1000, 1000);
        }
        else if (cells == Cells.ANIMAL_CELL)
        {
            obj.localPosition = new Vector3(0, 0, 9000);
            obj.localScale = new Vector3(850, 850, 850);
        }
        else if (cells == Cells.PLANT_CELL)
        {
            obj.localPosition = new Vector3(0, 0, 900);
            obj.localScale = new Vector3(900, 900, 900);
        }

        for (int i = 0; i < c; i++)
        {
            cellPartsLbl.transform.GetChild(i).gameObject.SetActive(false);
        }

    }

    public void OnNextClick()
    {
        DataLoader cellData = DataSaver.loadData<DataLoader>("cell");
        if (cellData == null)
        {
            return;
        }

        if (!string.IsNullOrEmpty(cellData.obj))
        {
            obj = parentObj.transform.Find(cellData.obj);
        }

        name = cellData.name;
        cellTxt = cellText.text;

        c = cellPartsLbl.transform.childCount;

        if (name == "Animal Cell")
        {
            switch (cellTxt)
            {
                case "Animal Cell":
                    DisplayCells(Cells.ANIMAL_CELL, 3, true, true);
                    break;
                case "Cytoplasm":
                    DisplayCells(Cells.ANIMAL_CELL, 4, true, true);
                    break;
                case "Cytoskeleton":
                    DisplayCells(Cells.ANIMAL_CELL, 6, true, true);
                    break;
                case "Endoplasmic Reticulum":
                    DisplayCells(Cells.ANIMAL_CELL, 7, true, true);
                    break;
                case "Golgi Apparatus":
                    DisplayCells(Cells.ANIMAL_CELL, 8, true, true);
                    break;
                case "Lysosomes":
                    DisplayCells(Cells.ANIMAL_CELL, 10, true, true);
                    break;
                case "Mitochondrion":
                    DisplayCells(Cells.ANIMAL_CELL, 11, true, true);
                    break;
                case "Nucleus":
                    DisplayCells(Cells.ANIMAL_CELL, 12, true, true);
                    break;
                case "Plasma Membrane":
                    DisplayCells(Cells.ANIMAL_CELL, 13, true, false);
                    break;
            }
        }
        else if (name == "Plant Cell")
        {
            switch (cellTxt)
            {
                case "Plant Cell":
                    DisplayCells(Cells.PLANT_CELL, 0, true, true);
                    break;
                case "Cell Envelope":
                    DisplayCells(Cells.PLANT_CELL, 1, true, true);
                    break;
                case "Central Vacuole":
                    DisplayCells(Cells.PLANT_CELL, 2, true, true);
                    break;
                case "Chloroplast":
                    DisplayCells(Cells.PLANT_CELL, 3, true, true);
                    break;
                case "Cytoplasm":
                    DisplayCells(Cells.PLANT_CELL, 4, true, true);
                    break;
                case "Cytoskeleton":
                    DisplayCells(Cells.PLANT_CELL, 6, true, true);
                    break;
                case "Endoplasmic Reticulum":
                    DisplayCells(Cells.PLANT_CELL, 7, true, true);
                    break;
                case "Golgi Apparatus":
                    DisplayCells(Cells.PLANT_CELL, 8, true, true);
                    break;
                case "Lysosomes":
                    DisplayCells(Cells.PLANT_CELL, 10, true, true);
                    break;
                case "Mitochondrion":
                    DisplayCells(Cells.PLANT_CELL, 11, true, true);
                    break;
                case "Nucleus":
                    DisplayCells(Cells.PLANT_CELL, 12, true, true);
                    break;
                case "Plasma Membrane":
                    DisplayCells(Cells.PLANT_CELL, 13, true, false);
                    break;
            }
        }
        else if (name == "Eukaryotic Cell")
        {
            switch (cellTxt)
            {
                case "Eukaryotic Cell":
                    DisplayCells(Cells.EUKARYOTIC_CELL, 0, true, true);
                    break;
                case "Cell Envelope":
                    DisplayCells(Cells.EUKARYOTIC_CELL, 1, true, true);
                    break;
                case "Central Vacuole":
                    DisplayCells(Cells.EUKARYOTIC_CELL, 3, true, true);
                    break;
                case "Cytoplasm":
                    DisplayCells(Cells.EUKARYOTIC_CELL, 4, true, true);
                    break;
                case "Cytoskeleton":
                    DisplayCells(Cells.EUKARYOTIC_CELL, 6, true, true);
                    break;
                case "Endoplasmic Reticulum":
                    DisplayCells(Cells.EUKARYOTIC_CELL, 7, true, true);
                    break;
                case "Golgi Apparatus":
                    DisplayCells(Cells.EUKARYOTIC_CELL, 8, true, true);
                    break;
                case "Lysosomes":
                    DisplayCells(Cells.EUKARYOTIC_CELL, 10, true, true);
                    break;
                case "Mitochondrion":
                    DisplayCells(Cells.EUKARYOTIC_CELL, 11, true, true);
                    break;
                case "Nucleus":
                    DisplayCells(Cells.EUKARYOTIC_CELL, 12, true, true);
                    break;
                case "Plasma Membrane":
                    DisplayCells(Cells.EUKARYOTIC_CELL, 13, true, false);
                    break;
            }
        }
        else if (name == "Prokaryotic Cell")
        {
            switch (cellTxt)
            {
                case "Prokaryotic Cell":
                    DisplayCells(Cells.PROKARYOTIC_CELL, 0, true, true);
                    break;
                case "Cell Envelope":
                    DisplayCells(Cells.PROKARYOTIC_CELL, 9, true, true);
                    break;
                case "Mesosomes":
                    DisplayCells(Cells.PROKARYOTIC_CELL, 12, true, true);
                    break;
                case "Plasma Membrane":
                    DisplayCells(Cells.PROKARYOTIC_CELL, 13, true, false);
                    break;
            }
        }
    }

    public void OnPrevClick()
    {
        DataLoader cellData = DataSaver.loadData<DataLoader>("cell");
        if (cellData == null)
        {
            return;
        }

        if (!string.IsNullOrEmpty(cellData.obj))
        {
            obj = parentObj.transform.Find(cellData.obj);
        }

        c = cellPartsLbl.transform.childCount;

        name = cellData.name;
        cellTxt = cellText.text;

        if (name == "Animal Cell")
        {
            switch (cellTxt)
            {
                case "Cytoplasm":
                    DisplayCells(Cells.ANIMAL_CELL, "Animal Cell", false, true);
                    break;
                case "Cytoskeleton":
                    DisplayCells(Cells.ANIMAL_CELL, 3, true, true);
                    break;
                case "Endoplasmic Reticulum":
                    DisplayCells(Cells.ANIMAL_CELL, 4, true, true);
                    break;
                case "Golgi Apparatus":
                    DisplayCells(Cells.ANIMAL_CELL, 6, true, true);
                    break;
                case "Lysosomes":
                    DisplayCells(Cells.ANIMAL_CELL, 7, true, true);
                    break;
                case "Mitochondrion":
                    DisplayCells(Cells.ANIMAL_CELL, 8, true, true);
                    break;
                case "Nucleus":
                    DisplayCells(Cells.ANIMAL_CELL, 10, true, true);
                    break;
                case "Plasma Membrane":
                    DisplayCells(Cells.ANIMAL_CELL, 11, true, true);
                    break;
                case "Ribosomes":
                    DisplayCells(Cells.ANIMAL_CELL, 12, true, true);
                    break;
            }
        }
        else if (name == "Plant Cell")
        {
            switch (cellTxt)
            {
                case "Cell Envelope":
                    DisplayCells(Cells.PLANT_CELL, "Plant Cell", false, true);
                    break;
                case "Central Vacuole":
                    DisplayCells(Cells.PLANT_CELL, 0, true, true);
                    break;
                case "Chloroplast":
                    DisplayCells(Cells.PLANT_CELL, 1, true, true);
                    break;
                case "Cytoplasm":
                    DisplayCells(Cells.PLANT_CELL, 2, true, true);
                    break;
                case "Cytoskeleton":
                    DisplayCells(Cells.PLANT_CELL, 3, true, true);
                    break;
                case "Endoplasmic Reticulum":
                    DisplayCells(Cells.PLANT_CELL, 4, true, true);
                    break;
                case "Golgi Apparatus":
                    DisplayCells(Cells.PLANT_CELL, 6, true, true);
                    break;
                case "Lysosomes":
                    DisplayCells(Cells.PLANT_CELL, 7, true, true);
                    break;
                case "Mitochondrion":
                    DisplayCells(Cells.PLANT_CELL, 8, true, true);
                    break;
                case "Nucleus":
                    DisplayCells(Cells.PLANT_CELL, 10, true, true);
                    break;
                case "Plasma Membrane":
                    DisplayCells(Cells.PLANT_CELL, 11, true, true);
                    break;
                case "Ribosomes":
                    DisplayCells(Cells.PLANT_CELL, 12, true, true);
                    break;
            }
        }
        else if (name == "Eukaryotic Cell")
        {
            switch (cellTxt)
            {
                case "Cell Envelope":
                    DisplayCells(Cells.EUKARYOTIC_CELL, "Eukaryotic Cell", false, true);
                    break;
                case "Central Vacuole":
                    DisplayCells(Cells.EUKARYOTIC_CELL, 0, true, true);
                    break;
                case "Cytoplasm":
                    DisplayCells(Cells.EUKARYOTIC_CELL, 1, true, true);
                    break;
                case "Cytoskeleton":
                    DisplayCells(Cells.EUKARYOTIC_CELL, 3, true, true);
                    break;
                case "Endoplasmic Reticulum":
                    DisplayCells(Cells.EUKARYOTIC_CELL, 4, true, true);
                    break;
                case "Golgi Apparatus":
                    DisplayCells(Cells.EUKARYOTIC_CELL, 6, true, true);
                    break;
                case "Lysosomes":
                    DisplayCells(Cells.EUKARYOTIC_CELL, 7, true, true);
                    break;
                case "Mitochondrion":
                    DisplayCells(Cells.EUKARYOTIC_CELL, 8, true, true);
                    break;
                case "Nucleus":
                    DisplayCells(Cells.EUKARYOTIC_CELL, 10, true, true);
                    break;
                case "Plasma Membrane":
                    DisplayCells(Cells.EUKARYOTIC_CELL, 11, true, true);
                    break;
                case "Ribosomes":
                    DisplayCells(Cells.EUKARYOTIC_CELL, 12, true, true);
                    break;
            }
        }
        else if (name == "Prokaryotic Cell")
        {
            switch (cellTxt)
            {
                case "Cell Envelope":
                    DisplayCells(Cells.PROKARYOTIC_CELL, "Prokaryotic Cell", false, true);
                    break;
                case "Mesosomes":
                    DisplayCells(Cells.PROKARYOTIC_CELL, 0, true, true);
                    break;
                case "Plasma Membrane":
                    DisplayCells(Cells.PROKARYOTIC_CELL, 9, true, true);
                    break;
                case "Ribosomes":
                    DisplayCells(Cells.PROKARYOTIC_CELL, 12, true, true);
                    break;
            }
        }


    }

    // Update is called once per frame
    void Update()
    {

    }
}

enum Cells
{
    EUKARYOTIC_CELL,
    PROKARYOTIC_CELL,
    ANIMAL_CELL,
    PLANT_CELL
}
