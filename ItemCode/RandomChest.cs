using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomChest : MonoBehaviour
{
    public List<GameObject> Slots = new List<GameObject>();
    public ActivCode AC;
    public Transform PosSpawn;

    public void Update()
    {
        if (AC.Activ == true)
        {
            Instantiate(Slots[Random.Range(0, Slots.Count - 1)], PosSpawn.position, PosSpawn.rotation);
            Destroy(this.gameObject);
        }
    }

}
