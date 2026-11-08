using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ShotMashinGan : MonoBehaviour
{
    public GameObject bullet;
    public Transform posShut;
    public float MaxX;
    public float MaxY;
    public float MaxTemp;
    public float RealTemp;
    public float MaxTime;
    public float RealTime;
    public Animator anim;
    public Slider sliderTemp;
    public CameraMove PlauerM;
    public float Output;

    public void Start()
    {
        sliderTemp = GameObject.Find("SliderTemp").GetComponent<Slider>();
        sliderTemp.maxValue = MaxTemp;
        sliderTemp.minValue = 0f;
        PlauerM = GameObject.Find("Player").GetComponent<CameraMove>();
    }
    public void Update()
    {
        sliderTemp.value = RealTemp;
        if (RealTemp >= MaxTemp)
        {
            anim.SetBool("Reload", true);
            anim.SetBool("Shoot", false);
            PlauerM.Outputi = 0;
        }
        else if (Input.GetMouseButton(0) == true)
        {
            anim.SetBool("Shoot", true);
        }
        if (Input.GetMouseButton(0) == false)
        {
            RealTime = RealTime - Time.deltaTime;
            anim.SetBool("Shoot", false);
            PlauerM.Outputi = 0;
        }
        if (Input.GetMouseButton(0) == false && RealTime <= 0 && RealTemp > 0)
        {
            RealTemp = RealTemp - 1;
        }

    }
    public void ShootHev()
    {
        if (RealTemp <= MaxTemp)
        {
            Instantiate(bullet, posShut.position, Quaternion.Euler(new Vector3(Random.Range(posShut.eulerAngles.x - RealTemp / 5, posShut.eulerAngles.x + RealTemp / 5), Random.Range(posShut.eulerAngles.y - RealTemp / 5, posShut.eulerAngles.y + RealTemp / 5), 0f)));
            RealTemp = RealTemp + 1;
            RealTime = MaxTime;
            PlauerM.Outputi = Output;
        }

    }
    public void StopAn()
    {
        RealTemp = 0;
        anim.SetBool("Reload", false);
        PlauerM.Outputi = 0;
    }
}
