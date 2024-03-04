using Assets._Scripts.Models;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
    private static ResourceManager instance;
    public Text goldText;
    public ResourceData resourceData;

    public static ResourceManager Instance { get => instance; set => instance = value; }

    private void Awake()
    {
        goldText.text = FindResourceByName("Gold").Quantity.ToString();
        if (Instance != null)
        {
            Debug.Log("Found more than one Resource Manager in the scene.");
            Destroy(gameObject);
        }
        instance = this;
    }
    private void Start()
    {
        this.resourceData = GlobalControl.Instance.resourceData;
    }
    public void SaveResource()
    {
        GlobalControl.Instance.resourceData = this.resourceData;
    }

    public void AddGold(int amount)
    {
        foreach (Resource r in resourceData.resources) 
        {
            if (r.Name.Equals("Gold"))
            {
                r.Quantity += amount;
                SetGoldText(r.Quantity.ToString());
            } 
        }
    }

    public bool SpendGold(int amount)
    {
        foreach (Resource r in resourceData.resources)
        {
            if (r.Name.Equals("Gold"))
            {
                if (r.Quantity < amount)
                {
                    return false;
                } 
                else
                {
                    r.Quantity -= amount;
                    SetGoldText(r.Quantity.ToString());
                    return true;
                }
            }
        }
        return false;
    }
    public Resource FindResourceByName(string name)
    {
        return resourceData.resources.FirstOrDefault(resource => resource.Name == name);
    }

    private void SetGoldText(string goldText)
    {
        this.goldText.text = goldText;
    }
}
