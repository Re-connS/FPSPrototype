using UnityEngine;

public class Attakc : MonoBehaviour
{
    public Transform targetpos;
    public float rotationSpeed;
    public bool Activ;
    public Transform Player;
    public Animator anim;
    public Quaternion targetRotation;

    RaycastHit hit;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Debug.Log("Player");
            Activ = true;
            Player = other.gameObject.transform;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Activ = false;
            Player = null;
            anim.SetBool("Readi", false);
            anim.SetBool("Shot", false);
        }
    }
    public void Update()
    {
        if (Activ == true)
        {
            if (Physics.Raycast(targetpos.position, Player.position - targetpos.position, out hit))
            {
                if (hit.collider.name == "Player")
                {
                    anim.SetBool("Readi", true);
                    Vector3 direction = Player.position - targetpos.position;
                    targetRotation = Quaternion.LookRotation(direction);
                    targetpos.localRotation = Quaternion.Slerp(targetpos.localRotation, targetRotation, rotationSpeed * Time.deltaTime);
                }
            }
            else
            {
                anim.SetBool("Readi", false);
            }
        }
    }
}
