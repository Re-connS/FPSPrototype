using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HP : MonoBehaviour
{
    public float HPme;
    public float MaxHP;
    public float Deff;
    public float MaxTime;
    public float RealTime;
    public Slider sliderHP;

    public void Start()
    {
        if (sliderHP != null)
        { 
            sliderHP.maxValue = MaxHP;
            sliderHP.minValue = 0f;
        }
    }
    public void DamagMe(float Damag)
    {
        if (RealTime >= MaxTime)
        {
            HPme = HPme - (Damag - Deff);
            RealTime = 0f;
        }
    }
    public void Update()
    {
        RealTime = RealTime + Time.deltaTime;
        if (sliderHP != null)
        {
            sliderHP.value = HPme;
        }
        if (HPme > MaxHP)
        {
            HPme = MaxHP;
        }
    }
}
