using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MultiShot : MonoBehaviour
{
    public GameObject bullet;
    public List<Transform> posShut = new List<Transform>();
    public float MaxX;
    public float MaxY;
    public float Output;
    public int i;
    public bool Multi;
    public CameraMove PlauerM;

    public void Start()
    {
        PlauerM = GameObject.Find("Player").GetComponent<CameraMove>();

    }
    public void Shoten()
    {
        if (Multi == false)
        {
            Instantiate(bullet, posShut[i].position, Quaternion.Euler(new Vector3(Random.Range(posShut[i].rotation.eulerAngles.x - MaxX, posShut[i].rotation.eulerAngles.x + MaxX), Random.Range(posShut[i].rotation.eulerAngles.y - MaxY, posShut[i].rotation.eulerAngles.y + MaxY), 0f)));
            if (i < posShut.Count - 1)
            {
                i++;
            }
            else
            {
                i = 0;
            }
        }
        else
        {
            for (int i = 0; i < posShut.Count; i++)
            {
                Instantiate(bullet, posShut[0].position, Quaternion.Euler(new Vector3(Random.Range(posShut[i].rotation.eulerAngles.x - MaxX, posShut[i].rotation.eulerAngles.x + MaxX), Random.Range(posShut[i].rotation.eulerAngles.y - MaxY, posShut[i].rotation.eulerAngles.y + MaxY), 0f)));
            }
        }
        PlauerM.Outputi = Output;
    }
}
