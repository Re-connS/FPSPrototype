using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvMeneg : MonoBehaviour
{
    public Transform InvPanel;
    public List<InvSlot> slots = new List<InvSlot>();
    public Camera maincamera;
    public float rightDis = 3f;
    void Start()
    {
        maincamera = Camera.main;
        for (int i = 0; i < InvPanel.childCount; i++)
        {
            if (InvPanel.GetChild(i).GetComponent<InvSlot>() != null)
            {
                slots.Add(InvPanel.GetChild(i).GetComponent<InvSlot>());
            }
        }
    }
    void Update()
    {
        Ray ray = maincamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (Physics.Raycast(ray, out hit, rightDis))
            {
                Debug.DrawRay(ray.origin, ray.direction * rightDis, Color.green);
                if (hit.collider.gameObject.tag == "Item")
                {
                    if (hit.collider.gameObject.GetComponent<Item>() != null)
                    {
                        AddItem(hit.collider.gameObject.GetComponent<Item>().invSObj, hit.collider.gameObject.GetComponent<Item>().amount);
                        Destroy(hit.collider.gameObject);
                    }
                }
            }
        }
    }
    private void AddItem(InvSObj _item, int _amount)
    {
        foreach (InvSlot slot in slots)
        {
            if (slot.item == _item)
            {
                if (_item.MaxStak - slot.amount == 0)
                {
                    return;
                }
                else if (_item.MaxStak - slot.amount >= _amount)
                {
                    slot.amount += _amount;
                    return;
                }
                else
                {
                    int dif = _item.MaxStak - slot.amount;
                    slot.amount = _item.MaxStak;
                    _amount = _amount - dif;
                }

            }
            if (slot.item == null)
            {
                if (slot.IsEmty == true)
                {
                    slot.item = _item;
                    slot.amount = _amount;
                    slot.IsEmty = false;
                    slot.SetIconSlot(_item.icon);
                    return;
                }
            }
        }
    }
}
