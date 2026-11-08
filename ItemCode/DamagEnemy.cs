using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DamagEnemy : MonoBehaviour
{
    public float Damag;
    public string TagEnemy;
    public GameObject Img;
    public AudioSource AS;
    public AudioClip Attakc;
    public float volume = 0.5f;

    public void Start()
    {
        Img = GameObject.Find("HitPoint");
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == TagEnemy)
        {
            if (AS != null)
            { 
                if (AS.isPlaying == false)
                {
                    AS.PlayOneShot(Attakc, volume);
                }
            }
            if (other.tag != "Player")
            {
                if (other.gameObject.name == "Body")
                {
                    other.GetComponent<HP>().DamagMe(Damag);
                    Img.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
                }
                else if (other.gameObject.name == "Head")
                {
                    other.GetComponent<HeadShot>().DamagMe(Damag * 1.5f);
                    Img.GetComponent<Image>().color = new Color(1f, 0f, 0f, 1f);
                }
            }
            else
            { 
                other.GetComponent<HP>().DamagMe(Damag);
            }
            
        }
    }
}
