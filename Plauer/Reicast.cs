using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
public class Reicast :  MonoBehaviour
{
    public Camera mainCamera;
    public Image Icon;
    public Sprite RightMouse;
    public TMP_Text Key;
    

    void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.GetComponentInParent<UnityEngine.UI.Button>() != null)
            {
                UnityEngine.UI.Button button = hit.collider.GetComponentInParent<UnityEngine.UI.Button>();
                if (button != null)
                {
                    Icon.sprite = RightMouse;
                    Icon.color = new Color(1f, 1f, 1f, 1f);
                    if (Input.GetMouseButtonDown(0))
                    {
                        if (Physics.Raycast(ray, out hit))
                        {
                            button.onClick.Invoke();
                        }
                    }
                }
            }
            else if (hit.collider.gameObject.GetComponent<ActivCode>() != null || hit.collider.gameObject.tag == "Item")
            {
                Key.text = "F";
                Icon.color = new Color(0f, 0f, 0f, 0f);
                if (Input.GetKeyDown(KeyCode.F) && hit.collider.gameObject.GetComponent<ActivCode>() != null)
                {
                    hit.collider.gameObject.GetComponent<ActivCode>().Put();
                }
            }
            else
            {
                Icon.color = new Color(0f, 0f, 0f, 0f);
                Key.text = null;
                Icon.sprite = null;
            }
        }
    }    
}