using Assets._Scripts.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private void Start()
    {
    }

    public void LoadGameplayScene()
    {
        SceneManager.LoadScene("Map 1");
    }

    public void LoadMainMenu()
    {
        DestroyImmediate(GlobalControl.Instance.gameObject);
        DestroyImmediate(InteractManager.Instance.gameObject);
        DestroyImmediate(DataPersistenceManager.Instance.gameObject);
        SceneManager.LoadScene("Main Menu");
    }
}
