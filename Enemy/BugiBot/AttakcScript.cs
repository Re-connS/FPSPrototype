using UnityEngine;

public class AttakcScript : MonoBehaviour
{
    public Animator anim;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            anim.SetBool("Attakc", true);
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            anim.SetBool("Attakc", false);
        }
    }
}
