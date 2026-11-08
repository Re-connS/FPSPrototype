using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuickslotInventory : MonoBehaviour
{
    // Объект у которого дети являются слотами
    public Transform quickslotParent;
    public int currentQuickslotID = 0;
    public Sprite selectedSprite;
    public Sprite notSelectedSprite;
    public GameObject Ruka;
    public GameObject PosItem;
    public GameObject StanRuk;

    // Update is called once per frame
    void Update()
    {
        if(Ruka.transform.childCount > 1)
        {
            Destroy(Ruka.transform.GetChild(1).gameObject);
        }
        float mw = Input.GetAxis("Mouse ScrollWheel");
        // Используем колесико мышки
        if (mw > 0.1)
        {

            // Берем предыдущий слот и меняем его картинку на обычную
            quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite = notSelectedSprite;
            // Если крутим колесиком мышки вперед и наше число currentQuickslotID равно последнему слоту, то выбираем наш первый слот (первый слот считается нулевым)
            if (currentQuickslotID >= quickslotParent.childCount - 1)
            {
                currentQuickslotID = 0;
            }
            else
            {
                // Прибавляем к числу currentQuickslotID единичку
                currentQuickslotID++;
            }
            // Берем предыдущий слот и меняем его картинку на "выбранную"
            quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite = selectedSprite;
            ChangeItem();

            // Что то делаем с предметом:

        }
        if (mw < -0.1)
        {
            // Берем предыдущий слот и меняем его картинку на обычную
            quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite = notSelectedSprite;
            // Если крутим колесиком мышки назад и наше число currentQuickslotID равно 0, то выбираем наш последний слот
            if (currentQuickslotID <= 0)
            {
                currentQuickslotID = quickslotParent.childCount - 1;
            }
            else
            {
                // Уменьшаем число currentQuickslotID на 1
                currentQuickslotID--;
            }
            // Берем предыдущий слот и меняем его картинку на "выбранную"
            quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite = selectedSprite;
            // Что то делаем с предметом:
            ChangeItem();

        }
        // Используем цифры
        for (int i = 0; i < quickslotParent.childCount; i++)
        {
            // если мы нажимаем на клавиши 1 по 5 то...
            if (Input.GetKeyUp((i + 1).ToString()))
            {
                // проверяем если наш выбранный слот равен слоту который у нас уже выбран, то
                if (currentQuickslotID == i)
                {
                    // Ставим картинку "selected" на слот если он "not selected" или наоборот
                    if (quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite == notSelectedSprite)
                    {
                        quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite = selectedSprite;
                        ChangeItem();
                    }
                    else
                    {
                        quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite = notSelectedSprite;
                        if (Ruka.transform.GetChild(0).gameObject != null)
                        {
                            Destroy(Ruka.transform.GetChild(0).gameObject);
                        }
                        PosItem = Instantiate(StanRuk, Ruka.transform);
                    }
                }
                // Иначе мы убираем свечение с предыдущего слота и светим слот который мы выбираем
                else if(currentQuickslotID != i)
                {
                    quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite = notSelectedSprite;
                    currentQuickslotID = i;
                    quickslotParent.GetChild(currentQuickslotID).GetComponent<Image>().sprite = selectedSprite;
                    ChangeItem();
                }
            }
        }
    }
    // Вызывается для смены предмета по индексу
    public void ChangeItem()
    {
        // Удаляем текущий предмет, если он есть
        if (Ruka.transform.GetChild(0).gameObject != null)
        {
            Destroy(Ruka.transform.GetChild(0).gameObject);
        }

        // Проверяем индекс
        if (quickslotParent.GetChild(currentQuickslotID).GetComponent<InvSlot>().item != null)
        {
            // Создаем новый предмет (префаб или объект из сцены)
            PosItem = Instantiate(quickslotParent.GetChild(currentQuickslotID).GetComponent<InvSlot>().item.InstPrefab, Ruka.transform);
            PosItem.transform.localPosition = new Vector3(0, 0, 0);
            //PosItem.transform.localRotation = Ruka.transform.localRotation;
        }
        else
        {
            PosItem = Instantiate(StanRuk, Ruka.transform); // Означает, что руку оставить пустой
            PosItem.transform.localPosition = new Vector3(0, 0, 0);
            PosItem.transform.localRotation = Ruka.transform.localRotation;
        }
    }
}
