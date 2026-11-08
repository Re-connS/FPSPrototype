using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
/// IPointerDownHandler - Следит за нажатиями мышки по объекту на котором висит этот скрипт
/// IPointerUpHandler - Следит за отпусканием мышки по объекту на котором висит этот скрипт
/// IDragHandler - Следит за тем не водим ли мы нажатую мышку по объекту
public class DragAndDropItem : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public InvSlot oldSlot;
    private Transform player;

    private void Start()
    {
        //ПОСТАВЬТЕ ТЭГ "PLAYER" НА ОБЪЕКТЕ ПЕРСОНАЖА!
        player = GameObject.FindGameObjectWithTag("Player").transform;
        // Находим скрипт InventorySlot в слоте в иерархии
        oldSlot = transform.GetComponentInParent<InvSlot>();
    }
    public void OnDrag(PointerEventData eventData)
    {
        // Если слот пустой, то мы не выполняем то что ниже return;
        if (oldSlot.IsEmty)
            return;
        GetComponent<RectTransform>().position += new Vector3(eventData.delta.x, eventData.delta.y);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (oldSlot.IsEmty)
            return;
        //Делаем картинку прозрачнее
        GetComponentInChildren<Image>().color = new Color(1, 1, 1, 0.75f);
        // Делаем так чтобы нажатия мышкой не игнорировали эту картинку
        GetComponentInChildren<Image>().raycastTarget = false;
        // Делаем наш DraggableObject ребенком InventoryPanel чтобы DraggableObject был над другими слотами инвенторя
        transform.SetParent(transform.parent.parent);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (oldSlot.IsEmty)
            return;
        // Делаем картинку опять не прозрачной
        GetComponentInChildren<Image>().color = new Color(1, 1, 1, 1f);
        // И чтобы мышка опять могла ее засечь
        GetComponentInChildren<Image>().raycastTarget = true;

        //Поставить DraggableObject обратно в свой старый слот
        transform.SetParent(oldSlot.transform);
        transform.position = oldSlot.transform.position;
        //Если мышка отпущена над объектом по имени InfPanel, то...
        if (eventData.pointerCurrentRaycast.gameObject.name == "Inventori")
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                GameObject itemObject = Instantiate(oldSlot.item.ItemPrefab, player.position + Vector3.up + player.forward, Quaternion.identity);
                itemObject.GetComponent<Item>().amount = Mathf.CeilToInt((float)oldSlot.amount / 2);
                // Устанавливаем количество объектов такое какое было в слоте
                oldSlot.amount -= Mathf.CeilToInt((float)oldSlot.amount / 2);
                oldSlot.itemAm.text = oldSlot.amount.ToString();
            }
            else if (Input.GetKey(KeyCode.LeftControl))
            {
                GameObject itemObject = Instantiate(oldSlot.item.ItemPrefab, player.position + Vector3.up + player.forward, Quaternion.identity);
                // Устанавливаем количество объектов такое какое было в слоте
                itemObject.GetComponent<Item>().amount = 1;
                oldSlot.amount--;
                oldSlot.itemAm.text = oldSlot.amount.ToString();
            }
            else
            {
                // Выброс объектов из инвентаря - Спавним префаб обекта перед персонажем
                GameObject itemObject = Instantiate(oldSlot.item.ItemPrefab, player.position + Vector3.up + player.forward, Quaternion.identity);
                // Устанавливаем количество объектов такое какое было в слоте
                itemObject.GetComponent<Item>().amount = oldSlot.amount;
                // убираем значения InventorySlot
                NullifySlotData();
            }
        }
        else if (eventData.pointerCurrentRaycast.gameObject.transform.parent.parent == null)
        {
            return;
        }
        else if (eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.GetComponent<InvSlot>() != null)
        {
            //Перемещаем данные из одного слота в другой
            ExchangeSlotData(eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.GetComponent<InvSlot>());
        }

    }
    void NullifySlotData()
    {
        // убираем значения InventorySlot
        oldSlot.item = null;
        oldSlot.amount = 0;
        oldSlot.IsEmty = true;
        oldSlot.icon.GetComponent<Image>().color = new Color(1, 1, 1, 1f);
        oldSlot.icon.GetComponent<Image>().sprite = null;
        oldSlot.itemAm.text = "";
    }
    void ExchangeSlotData(InvSlot newSlot)
    {
        // Временно храним данные newSlot в отдельных переменных
        InvSObj item = newSlot.item;
        int amount = newSlot.amount;
        bool IsEmty = newSlot.IsEmty;
        GameObject icon = newSlot.icon;
        TMP_Text itemAm = newSlot.itemAm;
        if (item == null)
        {
            if (oldSlot.item.MaxStak > 1 && oldSlot.amount > 1)
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {

                    newSlot.item = oldSlot.item;
                    newSlot.amount = Mathf.CeilToInt((float)oldSlot.amount / 2);
                    newSlot.IsEmty = false;
                    newSlot.SetIconSlot(oldSlot.icon.GetComponent<Image>().sprite);
                    newSlot.itemAm.text = newSlot.amount.ToString();
                    oldSlot.amount = Mathf.FloorToInt((float)oldSlot.amount / 2);
                    oldSlot.itemAm.text = oldSlot.amount.ToString();
                    return;
                }
                else if (Input.GetKey(KeyCode.LeftControl))
                {
                    newSlot.item = oldSlot.item;
                    newSlot.amount = 1;
                    newSlot.IsEmty = false;
                    newSlot.SetIconSlot(oldSlot.icon.GetComponent<Image>().sprite);
                    newSlot.itemAm.text = newSlot.amount.ToString();
                    oldSlot.amount--;
                    oldSlot.itemAm.text = oldSlot.amount.ToString();
                    return;
                }
            }
        }
        if (newSlot.item != null)
        {
            if (oldSlot.item.name.Equals(newSlot.item.name))
            {
                if (Input.GetKey(KeyCode.LeftShift) && oldSlot.amount > 1)
                {
                    if (Mathf.CeilToInt((float)oldSlot.amount / 2) < newSlot.item.MaxStak - newSlot.amount)
                    {
                        newSlot.amount += Mathf.CeilToInt((float)oldSlot.amount / 2);
                        newSlot.itemAm.text = newSlot.amount.ToString();

                        oldSlot.amount -= Mathf.CeilToInt((float)oldSlot.amount / 2);
                        oldSlot.itemAm.text = oldSlot.amount.ToString();
                    }
                    else
                    {
                        int difference = newSlot.item.MaxStak - newSlot.amount;
                        newSlot.amount = newSlot.item.MaxStak;
                        newSlot.itemAm.text = newSlot.amount.ToString();

                        oldSlot.amount -= difference;
                        oldSlot.itemAm.text = oldSlot.amount.ToString();

                    }
                    return;
                }
                else if (Input.GetKey(KeyCode.LeftControl) && oldSlot.amount > 1)
                {
                    if (newSlot.item.MaxStak != newSlot.amount)
                    {
                        newSlot.amount++;
                        newSlot.itemAm.text = newSlot.amount.ToString();

                        oldSlot.amount--;
                        oldSlot.itemAm.text = oldSlot.amount.ToString();
                    }
                    return;
                }
                else
                {
                    if (newSlot.amount + oldSlot.amount > newSlot.item.MaxStak)
                    {
                        int difference = newSlot.item.MaxStak - newSlot.amount;
                        newSlot.amount = newSlot.item.MaxStak;
                        newSlot.itemAm.text = newSlot.amount.ToString();

                        oldSlot.amount -= difference;
                        oldSlot.itemAm.text = oldSlot.amount.ToString();
                    }
                    else
                    {
                        newSlot.amount += oldSlot.amount;
                        newSlot.itemAm.text = newSlot.amount.ToString();
                        NullifySlotData();
                    }
                    return;
                }

            }
        }
        // Заменяем значения newSlot на значения oldSlot
        newSlot.item = oldSlot.item;
        newSlot.amount = oldSlot.amount;
        if (oldSlot.IsEmty == false)
        {
            newSlot.SetIconSlot(oldSlot.icon.GetComponent<Image>().sprite);
            newSlot.itemAm.text = oldSlot.amount.ToString();
        }
        else
        {
            newSlot.icon.GetComponent<Image>().color = new Color(1, 1, 1, 1f);
            newSlot.icon.GetComponent<Image>().sprite = null;
            newSlot.itemAm.text = "";
        }

        newSlot.IsEmty = oldSlot.IsEmty;

        oldSlot.item = item;
        oldSlot.amount = amount;
        if (IsEmty == false)
        {
            oldSlot.SetIconSlot(item.icon);
            if (item.MaxStak != 1) // added this if statement for single items
            {
                oldSlot.itemAm.text = amount.ToString();
            }
            else
            {
                oldSlot.itemAm.text = "";
            }
        }
        else
        {
            oldSlot.icon.GetComponent<Image>().color = new Color(1, 1, 1, 0);
            oldSlot.icon.GetComponent<Image>().sprite = null;
            oldSlot.itemAm.text = "";
            oldSlot.item = null;
        }

        oldSlot.IsEmty = IsEmty;
    }
        
}
