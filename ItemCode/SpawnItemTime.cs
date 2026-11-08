using UnityEngine;

public class SpawnItemTime : MonoBehaviour
{
    public GameObject item;
    public float MaxTime;
    public float RealTime;
    public Transform Pos;

    void Update()
    {
        RealTime = RealTime + Time.deltaTime;
        if (RealTime >= MaxTime && Pos.childCount == 0)
        {
            Instantiate(item, Pos.position, Pos.rotation, Pos);
            RealTime = 0f;
        }   
    }
}
