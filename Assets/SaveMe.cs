using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveMe : MonoBehaviour
{
    void Awake()
    {
        if (gameObject.name.Equals("Inventory")) gameObject.SetActive(false);
        DontDestroyOnLoad(gameObject); 
    }
}
