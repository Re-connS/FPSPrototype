using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public float JumpUp;
    public float BaseJump;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            BaseJump = other.GetComponent<CameraMove>().jumpSpeed;
            other.GetComponent<CameraMove>().jumpSpeed = JumpUp + BaseJump;
        }
    }
    public void OnTriggerExit(Collider other)
    { 
        if (other.gameObject.tag == "Player") // && other.gameObject.GetComponent<CameraMove>().characterController.isGrounded
        {
            other.GetComponent<CameraMove>().jumpSpeed = BaseJump;
        }
    }
}
