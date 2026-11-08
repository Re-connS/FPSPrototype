using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InvSlot : MonoBehaviour
{
    public InvSObj item;
    public int amount;
    public bool IsEmty = true;
    public GameObject icon;
    public TMP_Text itemAm;
    public GameObject PosHand;
    public GameObject Hand;
    

    void Awake()
    {
        icon = transform.GetChild(0).gameObject;
        itemAm = transform.GetChild(1).GetComponent<TMP_Text>();
    }
    void Update()
    {
        itemAm.text = "" + amount;
        if (amount == 0)
        {
            itemAm.text = null;
        }
    }
    public void SetIconSlot(Sprite _icon)
    {
        icon.GetComponent<Image>().sprite = _icon;
    }
    public void DellItem()
    {
        item = null;
        icon.GetComponent<Image>().sprite = null;
        amount = 0;
        Destroy(PosHand.transform.GetChild(0).gameObject);
        Instantiate(Hand, PosHand.transform);
        IsEmty = true;
    }
}
