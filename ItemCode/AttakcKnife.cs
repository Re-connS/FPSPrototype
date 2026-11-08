using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class AttakcKnife : MonoBehaviour
{
    public Animator anim;
    public GameObject Img;
    public GameObject Marker;
    public GameObject Player;
    public GameObject KnifeObj;
    public Transform KnifeT;
    public QuickslotInventory QI;

    public void Start()
    {
        Img = GameObject.Find("HitPoint");
        Marker = GameObject.Find("Marker");
        Player = GameObject.Find("Player");
        QI = GameObject.Find("HotKey").GetComponent<QuickslotInventory>();
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0) == true && Input.GetMouseButtonDown(1) == false)
        {
            anim.SetBool("Attakc", true);
        }
        if (Input.GetMouseButtonDown(0) == false)
        {
            anim.SetBool("Attakc", false);
        }
        if (Input.GetMouseButton(1) == true && Input.GetMouseButton(0) == false)
        {
            anim.SetBool("Shild", true);
        }
        if (Input.GetMouseButton(1) == false)
        {
            anim.SetBool("Shild", false);
        }
    }
    public void StopDamage()
    {
        Img.GetComponent<Image>().color = new Color(0f, 0f, 0f, 0f);
    }
    public void SpawnKnife()
    {
        Instantiate(KnifeObj, KnifeT.position, KnifeT.rotation);
        QI.quickslotParent.GetChild(QI.currentQuickslotID).GetComponent<InvSlot>().DellItem();
    }
}
