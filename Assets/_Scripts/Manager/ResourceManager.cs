using Assets._Scripts.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
    private static ResourceManager instance;
    public Text goldText;
    public List<Resource> resource;

    public static ResourceManager Instance { get => instance; set => instance = value; }

    private void Awake()
    {
        resource = new List<Resource>
        {
            new Resource("Gold", 2000)
        };
        goldText.text = FindResourceByName("Gold").Quantity.ToString();
        instance = this;
    }

    public void AddGold(int amount)
    {
        foreach (Resource r in resource) 
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
        foreach (Resource r in resource)
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
        return resource.FirstOrDefault(resource => resource.Name == name);
    }

    private void SetGoldText(string goldText)
    {
        this.goldText.text = goldText;
    }
}
