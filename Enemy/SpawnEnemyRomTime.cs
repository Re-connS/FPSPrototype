using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class SpawnEnemyRomTime : MonoBehaviour
{
    public bool Eneter;
    public float MaxTime;
    public float RealTime;
    public List<Transform> Spawn = new List<Transform>();
    public List<GameObject> Enemy = new List<GameObject>();
    public Animator anim;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Eneter = true;
            anim.SetBool("Close", true);
        }
    }
    public void Update()
    {
        if (Eneter == true)
        {
            RealTime += Time.deltaTime;
            if (RealTime > MaxTime)
            {
                EnemySpawn();
            }
        }
    }
    public void EnemySpawn()
    {
        Instantiate(Enemy[Random.Range(0, Enemy.Count - 1)], Spawn[Random.Range(0, Spawn.Count - 1)].position, Spawn[Random.Range(0, Spawn.Count - 1)].rotation);
        RealTime = 0f;
        if (MaxTime > 0.7f)
        { 
            MaxTime = MaxTime - 0.01f;
        }
    }
}
