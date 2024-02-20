using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class JsonLoader : MonoBehaviour
{
    public static TextAsset GetJsonFile(string jsonFileName)
    {
        string[] jsonFiles = AssetDatabase.FindAssets("t:TextAsset " + jsonFileName);

        if (jsonFiles.Length > 0)
        {
            string path = AssetDatabase.GUIDToAssetPath(jsonFiles[0]);
            TextAsset jsonFile = AssetDatabase.LoadAssetAtPath<TextAsset>(path);

            if (jsonFile != null)
            {
                return jsonFile;
            }
            else
            {
                Debug.LogError("Không thể tải file JSON.");
                return null;
            }
        }
        else
        {
            Debug.LogError("Không tìm thấy file JSON với tên: " + jsonFileName);
            return null;
        }
    }
}
