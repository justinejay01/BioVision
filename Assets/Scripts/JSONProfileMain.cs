using UnityEngine;

[System.Serializable]
public class JSONProfileMain
{
    public string teacher;
    public string name;
    //public string score;

    public static JSONProfileMain CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<JSONProfileMain>(jsonString);
    }
}