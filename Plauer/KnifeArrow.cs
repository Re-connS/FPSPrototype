using UnityEngine;

public class KnifeArrow : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;
    public string Name;
    public GameObject KnifeObj;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.linearVelocity = transform.up * -speed;
    }
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == Name)
        {
            speed = 0f;
            rb. isKinematic = true;
            Instantiate(KnifeObj, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
    }
}
