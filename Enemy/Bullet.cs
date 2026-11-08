using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;
    public float MaxTime;
    public float RealTime;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.linearVelocity = transform.forward * speed;
    }
    public void Update()
    {
        RealTime += Time.deltaTime;
        if (RealTime > MaxTime)
        { 
            Destroy(this.gameObject);
        }
    }
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "Graund")
        {
            Destroy(this.gameObject);
        }
    }
}
