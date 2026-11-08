using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopSlot : MonoBehaviour
{
    public int Cena;
    public GameObject Item;
    public bool Sell;
    public TMP_Text CenaUI;
    public Image IC;
    public ShopSystem SS;
    public void Start()
    {
        CenaUI.text = "" + Cena;
    }
    public void Update()
    {
        if (Sell == true)
        {
            IC.color = Color.black;
        }
        else
        { 
            IC.color = Color.red;
        }
    }
    public void Put()
    {
        Sell = !Sell;
        if (Sell == true)
        {
            SS.Credit += Cena;
        }
        else
        {
            if (SS.Credit != 0)
            {
                SS.Credit -= Cena;
            }
        }
    }
}
