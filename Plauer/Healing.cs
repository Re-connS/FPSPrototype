using UnityEngine;

public class Healing : MonoBehaviour
{
    public int hp;
    public GameObject He;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (other.gameObject.GetComponent<HP>().HPme < other.gameObject.GetComponent<HP>().MaxHP)
            {
                other.gameObject.GetComponent<HP>().HPme += hp;
                Destroy(He);
            }
        }
    }
}
