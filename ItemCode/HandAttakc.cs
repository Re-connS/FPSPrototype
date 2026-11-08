using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HandAttakc : MonoBehaviour
{
    public Animator anim;
    public GameObject Img;
    public GameObject Player;

    public void Start()
    {
        Img = GameObject.Find("HitPoint");
        Player = GameObject.Find("Player");
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
}
