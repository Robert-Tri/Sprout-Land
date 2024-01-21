using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public virtual void LoadGameplayScene()
    {
        SceneManager.LoadScene("Map 1");
    }
}
