using UnityEngine;

public class HeadShot : MonoBehaviour
{
    public HP HPScript;

    public void DamagMe(float Damag)
    {
        if (HPScript.RealTime >= HPScript.MaxTime)
        {
            HPScript.HPme = HPScript.HPme - (Damag);
            HPScript.RealTime = 0f;
        }
    }
}
