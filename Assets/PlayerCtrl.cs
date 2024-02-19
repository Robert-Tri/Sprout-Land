using Assets._Scripts.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    static public PlayerCtrl instance;
    public Player Player;
    private void Awake()
    {
        PlayerCtrl.instance = this;
        this.Player = GetComponent<Player>();
    }
}
