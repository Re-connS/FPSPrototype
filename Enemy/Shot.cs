using UnityEngine;

public class Shot : MonoBehaviour
{
    public GameObject bullet;
    public Transform posShut;
    public float MaxX;
    public float MaxY;
    public Transform Tur;
    public CameraMove PlauerM;
    public float Output;

    public void Start()
    {
        PlauerM = GameObject.Find("Player").GetComponent<CameraMove>();

    }
    public void Shoten()
    {
        PlauerM.Outputi = Output;
        Instantiate(bullet, posShut.position, Quaternion.Euler(new Vector3(Random.Range(Tur.eulerAngles.x - MaxX, Tur.eulerAngles.x + MaxX), Random.Range(Tur.eulerAngles.y - MaxY, Tur.eulerAngles.y + MaxY), 0f)));
    }
}
