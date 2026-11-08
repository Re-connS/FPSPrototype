using UnityEngine;

public class AmmoPlus : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            if (GameObject.Find("Hands").transform.GetChild(0).GetComponent<Reload>() != null)
            {
                if ( GameObject.Find("Hands").transform.GetChild(0).GetComponent<Reload>().RealAmmo <  GameObject.Find("Hands").transform.GetChild(0).GetComponent<Reload>().MaxAmmo)
                {
                    GameObject.Find("Hands").transform.GetChild(0).GetComponent<Reload>().RealAmmo =  GameObject.Find("Hands").transform.GetChild(0).GetComponent<Reload>().MaxAmmo;
                    Destroy(this.gameObject);
                }
            }
        }
    }
}