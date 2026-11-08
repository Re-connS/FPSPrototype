using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopSystem : MonoBehaviour
{
    public int Money;
    public int Credit;
    public TMP_Text MoneyText;
    public TMP_Text CreditText;
    public List<ShopSlot> Slots = new List<ShopSlot>();
    public MoneySystem MS;
    public Transform PosSpawn;
    public int id;
    void Update()
    {
        if (MS == null)
        {
            MS = GameObject.Find("Player").GetComponent<MoneySystem>();
        }
        else if(MS != null)
        { 
            Money = MS.Money;
            MoneyText.text = "Денег:" + Money;
            CreditText.text = "Credit: " + Credit; 
        }
    }
    public void OnInput()
    {
        if (Money >= Credit)
        {
            foreach (ShopSlot slot in Slots)
            {

                if (slot.Sell == true)
                {
                    Instantiate(slot.Item, PosSpawn.position, PosSpawn.rotation);
                }
            }

            foreach (ShopSlot slot in Slots)
            {
                if (slot.Sell == true)
                {
                    slot.Sell = false; ;
                }
            }
            MS.Money -= Credit;
            Credit = 0;
        }
        
    }
}
