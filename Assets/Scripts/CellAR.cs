using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CellAR : MonoBehaviour
{
    public GameObject cellParts;
    public GameObject cellLbl;
    Transform cellLabel;
    string cellName;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (cellLabel != null) cellLabel.gameObject.SetActive(false);

                cellName = hit.transform.name;
                if (cellName == "CellWall")
                {
                    cellLabel = cellParts.transform.Find("Cell Envelope");
                    cellLabel.localPosition = new Vector3(hit.transform.localPosition.x, 0.1f, hit.transform.localPosition.z);
                    cellLabel.gameObject.SetActive(true);
                }
                else if (cellName == "CentralVacuole_type01")
                {
                    cellLabel = cellParts.transform.Find("Central Vacuole");
                    cellLabel.localPosition = new Vector3(hit.transform.localPosition.x, 0.1f, hit.transform.localPosition.z);
                    cellLabel.gameObject.SetActive(true);
                }
                else if (cellName == "Cytoplasm_01" || cellName == "Cytoplasm_02" || cellName == "Cytoplasm_03" || cellName == "Cytoplasm_04" || cellName == "Cytoplasm_05" || cellName == "Cytoplasm_06" || cellName == "Cytoplasm_07" || cellName == "Cytoplasm_08")
                {
                    cellLabel = cellParts.transform.Find("Cytoplasm");
                    cellLabel.localPosition = new Vector3(hit.transform.localPosition.x, 0.1f, hit.transform.localPosition.z);
                    cellLabel.gameObject.SetActive(true);
                }
                else if (cellName == "Cytoskeleton")
                {
                    cellLabel = cellParts.transform.Find("Cytoskeleton");
                    cellLabel.localPosition = new Vector3(hit.transform.localPosition.x, 0.1f, hit.transform.localPosition.z);
                    cellLabel.gameObject.SetActive(true);
                }
                else if (cellName == "GolgiApparatus_type01")
                {
                    cellLabel = cellParts.transform.Find("Golgi Apparatus");
                    cellLabel.localPosition = new Vector3(hit.transform.localPosition.x, 0.1f, hit.transform.localPosition.z);
                    cellLabel.gameObject.SetActive(true);
                }
                else if (cellName == "Lysosome_00" || cellName == "Lysosome_01" || cellName == "Lysosome_02" || cellName == "Lysosome_03" || cellName == "Lysosome_04" || cellName == "Lysosome_05" || cellName == "Lysosome_06" || cellName == "Lysosome_07")
                {
                    cellLabel = cellParts.transform.Find("Lysosome");
                    cellLabel.localPosition = new Vector3(hit.transform.localPosition.x, 0.1f, hit.transform.localPosition.z);
                    cellLabel.gameObject.SetActive(true);
                }
                else if (cellName == "Mesosome_00" || cellName == "Mesosome_01" || cellName == "Mesosome_02" || cellName == "Mesosome_03")
                {
                    cellLabel = cellParts.transform.Find("Mesosome");
                    cellLabel.localPosition = new Vector3(hit.transform.localPosition.x, 0.1f, hit.transform.localPosition.z);
                    cellLabel.gameObject.SetActive(true);
                }
                else if (cellName == "MitochondrionInnerMembrane_00" || cellName == "MitochondrionInnerMembrane_01" || cellName == "MitochondrionInnerMembrane_02" || cellName == "MitochondrionInnerMembrane_03" || cellName == "MitochondrionInnerMembrane_04" || cellName == "MitochondrionInnerMembrane_05" || cellName == "MitochondrionInnerMembrane_06" || cellName == "MitochondrionInnerMembrane_07" || cellName == "MitochondrionSliceInnerMembrane" || cellName == "MitochondrionOuterMembrane_00" || cellName == "MitochondrionOuterMembrane_01" || cellName == "MitochondrionOuterMembrane_02" || cellName == "MitochondrionOuterMembrane_03" || cellName == "MitochondrionOuterMembrane_04" || cellName == "MitochondrionOuterMembrane_05" || cellName == "MitochondrionOuterMembrane_06" || cellName == "MitochondrionOuterMembrane_07" || cellName == "MitochondrionSliceOuterMembrane")
                {
                    cellLabel = cellParts.transform.Find("Mitochondrion");
                    cellLabel.localPosition = new Vector3(hit.transform.localPosition.x, 0.1f, hit.transform.localPosition.z);
                    cellLabel.gameObject.SetActive(true);
                }
                else if (cellName == "NuclearEnvelope_00" || cellName == "NuclearEnvelope_01" || cellName == "NuclearEnvelope_02" || cellName == "NuclearNucleolus" || cellName == "NuclearPore_00" || cellName == "NuclearPore_01")
                {
                    cellLabel = cellParts.transform.Find("Nucleus");
                    cellLabel.localPosition = new Vector3(hit.transform.localPosition.x, 0.1f, hit.transform.localPosition.z);
                    cellLabel.gameObject.SetActive(true);
                }
                else if (cellName == "PlasmaMembrane")
                {
                    cellLabel = cellParts.transform.Find("Plasma Membrane");
                    cellLabel.localPosition = new Vector3(hit.transform.localPosition.x, 0.1f, hit.transform.localPosition.z);
                    cellLabel.gameObject.SetActive(true);
                }
                else if (cellName == "ReticulumCisternae_00" || cellName == "ReticulumCisternae_01" || cellName == "ReticulumRough" || cellName == "ReticulumSmooth")
                {
                    cellLabel = cellParts.transform.Find("Endoplasmic Reticulum");
                    cellLabel.localPosition = new Vector3(hit.transform.localPosition.x, 0.1f, hit.transform.localPosition.z);
                    cellLabel.gameObject.SetActive(true);
                }
                else if (cellName == "Ribosome_00" || cellName == "Ribosome_01" || cellName == "Ribosome_02" || cellName == "Ribosome_03" || cellName == "Ribosome_04" || cellName == "Ribosome_05" || cellName == "Ribosome_06" || cellName == "Ribosome_07" || cellName == "Ribosome_08" || cellName == "Ribosome_09" || cellName == "Ribosome_10" || cellName == "Ribosome_11" || cellName == "Ribosome_12" || cellName == "Ribosome_13" || cellName == "Ribosome_14" || cellName == "Ribosome_15" || cellName == "Ribosome_16" || cellName == "Ribosome_17" || cellName == "Ribosome_18" || cellName == "Ribosome_19" || cellName == "Ribosome_20" || cellName == "Ribosome_21" || cellName == "Ribosome_22" || cellName == "Ribosome_23" || cellName == "Ribosome_24" || cellName == "Ribosome_25" || cellName == "Ribosome_26" || cellName == "Ribosome_27" || cellName == "Ribosome_28" || cellName == "Ribosome_29" || cellName == "Ribosome_30" || cellName == "Ribosome_31" || cellName == "Ribosome_32" || cellName == "Ribosome_33" || cellName == "Ribosome_34" || cellName == "Ribosome_35" || cellName == "Ribosome_36" || cellName == "Ribosome_37" || cellName == "Ribosome_38" || cellName == "Ribosome_39" || cellName == "Ribosome_40" || cellName == "Ribosome_41" || cellName == "Ribosome_42" || cellName == "Ribosome_43" || cellName == "Ribosome_44" || cellName == "Ribosome_45" || cellName == "Ribosome_46" || cellName == "Ribosome_47" || cellName == "Ribosome_48" || cellName == "Ribosome_49" || cellName == "Ribosome_50" || cellName == "Ribosome_51" || cellName == "Ribosome_52" || cellName == "Ribosome_53" || cellName == "Ribosome_54" || cellName == "Ribosome_55" || cellName == "Ribosome_56" || cellName == "Ribosome_57" || cellName == "Ribosome_58" || cellName == "Ribosome_59" || cellName == "Ribosome_60" || cellName == "Ribosome_61" || cellName == "Ribosome_62" || cellName == "Ribosome_63" || cellName == "Ribosome_64" || cellName == "Ribosome_65" || cellName == "Ribosome_66" || cellName == "Ribosome_67" || cellName == "Ribosome_68" || cellName == "Ribosome_69" || cellName == "Ribosome_70" || cellName == "Ribosome_71" || cellName == "Ribosome_72" || cellName == "Ribosome_73" || cellName == "Ribosome_74" || cellName == "Ribosome_75" || cellName == "Ribosome_76" || cellName == "Ribosome_77" || cellName == "Ribosome_78" || cellName == "Ribosome_79" || cellName == "Ribosome_80" || cellName == "Ribosome_81" || cellName == "Ribosome_82" || cellName == "Ribosome_83" || cellName == "Ribosome_84" || cellName == "Ribosome_85" || cellName == "Ribosome_86" || cellName == "Ribosome_87" || cellName == "Ribosome_88" || cellName == "Ribosome_89" || cellName == "Ribosome_90" || cellName == "Ribosome_91" || cellName == "Ribosome_92" || cellName == "Ribosome_93" || cellName == "Ribosome_94" || cellName == "Ribosome_95" || cellName == "Ribosome_96" || cellName == "Ribosome_97" || cellName == "Ribosome_98" || cellName == "Ribosome_99" || cellName == "Ribosome_100" || cellName == "Ribosome_101" || cellName == "Ribosome_102" || cellName == "Ribosome_103" || cellName == "Ribosome_104" || cellName == "Ribosome_105" || cellName == "Ribosome_106" || cellName == "Ribosome_107" || cellName == "Ribosome_108" || cellName == "Ribosome_109" || cellName == "Ribosome_110" || cellName == "Ribosome_111" || cellName == "Ribosome_112" || cellName == "Ribosome_113" || cellName == "Ribosome_114" || cellName == "Ribosome_115" || cellName == "Ribosome_116" || cellName == "Ribosome_117" || cellName == "Ribosome_118" || cellName == "Ribosome_119" || cellName == "Ribosome_120" || cellName == "Ribosome_121" || cellName == "Ribosome_122" || cellName == "Ribosome_123" || cellName == "Ribosome_124" || cellName == "Ribosome_125" || cellName == "Ribosome_126" || cellName == "Ribosome_127" || cellName == "Ribosome_128" || cellName == "Ribosome_129" || cellName == "Ribosome_130" || cellName == "Ribosome_131" || cellName == "Ribosome_132" || cellName == "Ribosome_133" || cellName == "Ribosome_134" || cellName == "Ribosome_135" || cellName == "Ribosome_136" || cellName == "Ribosome_137" || cellName == "Ribosome_138" || cellName == "Ribosome_139" || cellName == "Ribosome_140" || cellName == "Ribosome_141" || cellName == "Ribosome_142" || cellName == "Ribosome_143" || cellName == "Ribosome_144" || cellName == "Ribosome_145" || cellName == "Ribosome_146" || cellName == "Ribosome_147" || cellName == "Ribosome_148" || cellName == "Ribosome_149" || cellName == "Ribosome_150" || cellName == "Ribosome_151" || cellName == "Ribosome_152" || cellName == "Ribosome_153" || cellName == "Ribosome_154" || cellName == "Ribosome_155" || cellName == "Ribosome_156")
                {
                    cellLabel = cellParts.transform.Find("Ribosome");
                    cellLabel.localPosition = new Vector3(hit.transform.localPosition.x, 0.1f, hit.transform.localPosition.z);
                    cellLabel.gameObject.SetActive(true);
                }
            }
        }
    }
}
