using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class JsonLoader : MonoBehaviour
{
    public static TextAsset GetJsonFile(string jsonFileName)
    {
        TextAsset jsonFile = Resources.Load<TextAsset>(jsonFileName);

        if (jsonFile != null)
        {
            return jsonFile;
        }
        else
        {
            Debug.LogError("Không thể tải file JSON với tên: " + jsonFileName);
            return null;
        }
    }
}
