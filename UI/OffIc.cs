using UnityEngine;
using UnityEngine.UI;

public class OffIc : MonoBehaviour
{
    public float MaxTime;
    public float RealTime;
    public Image Icon;
    void Update()
    {
        if (Icon.color != new Color(1f, 1f, 1f, 0f))
        {
            RealTime = RealTime + Time.deltaTime;
            if (RealTime >= MaxTime)
            {
                Icon.color = new Color(1f, 1f, 1f, 0f);
                RealTime = 0f;
            }
        }
    }
}
