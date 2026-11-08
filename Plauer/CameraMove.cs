using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CharacterController))]
public class CameraMove :   MonoBehaviour
{
    public Slider sliderStamina;
    public float walkingSpeed;
    public float runningSpeed;
    public float BaseJumpSpeed;
    public float jumpSpeed;
    public float gravity;
    public Camera playerCamera;
    public float lookSpeed;
    public float lookXLimit;
    public float Stamin;
    public float MaxStamina;
    public Transform Spina;
    public CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;
    public float Outputi;

    [HideInInspector]
    public bool canMove = true;
    public bool isRunning;
    public float rightDis = 3f;
    public GameObject Player;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        sliderStamina.maxValue = MaxStamina;
        sliderStamina.minValue = 0f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        sliderStamina.value = Stamin;
        // We are grounded, so recalculate move direction based on axes
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        // Press Left Shift to run
        bool isSite =  Input.GetKey(KeyCode.LeftControl);
        if (isSite == false && Input.GetKeyDown(KeyCode.LeftShift))
        {
            isRunning = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isRunning = false;
        }
        if (isSite == true)
        {
            characterController.height = 1f;
            characterController.center = new Vector3(0f, -0.50f, 0f);
            playerCamera.transform.localPosition = new Vector3(0.05f, -0.17f, 0.05f);
        }
        else
        {
            characterController.height = 2f;
            characterController.center = new Vector3(0f, 0f, 0f);
            playerCamera.transform.localPosition = new Vector3(0.05f, 0.5f, 0.05f);
        }
        if (isRunning == true && (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0) && isSite == false)
        {
            Stamin = Stamin - Time.deltaTime;
        }
        else
        {
            if (Stamin < MaxStamina)
            {
                Stamin = Stamin + Time.deltaTime;
            }
        }
        if (Stamin <= 0)
        {
            Stamin = 0;
            isRunning = false;
        }
        float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded && Stamin > 0)
        {
            moveDirection.y = jumpSpeed;
            Stamin = Stamin - 1f;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);

        // Player and Camera rotation
        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX + Outputi, -lookXLimit, lookXLimit);
            Spina.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
    }
}
