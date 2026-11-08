using UnityEngine;
using TMPro;

public class UIOfffBullet : MonoBehaviour
{
    public GameObject BulletUI;
    void Start()
    {
        BulletUI = GameObject.Find("BulletU");
        BulletUI.transform.GetChild(0).GetComponent<TMP_Text>().text = null;
    }
}
