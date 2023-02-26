using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Collections;
[RequireComponent(typeof(CharacterController))]

public class characterControll : MonoBehaviour
{
    public float walkingSpeed = 7.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Camera playerCamera;
    public float lookSpeed = 4.0f;
    public float lookXLimit = 45.0f;

    CharacterController characterController;
    Vector3 moveDirection = new Vector3(0.0f,0.0f,0.0f);
    float rotationX = 0;

    //[HideInInspector]
    public TextMeshProUGUI HPtext;
    public int HP=100;

    public GameObject takeDamageImage;
    public float takeDamageTime = 0.7f;
    void Start()
    {
        characterController = GetComponent<CharacterController>();

        // mouse lock
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        HPtext.text = "Player HP: " + HP;
    }

    void Update()
    {
        // input
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        float XSpeed = walkingSpeed * Input.GetAxis("Vertical");
        float YSpeed = walkingSpeed * Input.GetAxis("Horizontal");
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * XSpeed) + (right * YSpeed);

        // jump
        if (Input.GetButton("Jump") && characterController.isGrounded)
            moveDirection.y = jumpSpeed;
        
        else
            moveDirection.y = movementDirectionY;

        // gravity
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // move
        characterController.Move(moveDirection * Time.deltaTime);

        //cam rotate
        rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);

        takeDamageTime -= Time.deltaTime;
        
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "enemy" && takeDamageTime<0)
        {
            takeDamageTime = 0.7f;
            Destroy(col.gameObject);
            HP -= 10;
            HPtext.text = "Player HP:" + HP;
            takeDamageImage.SetActive(true);
        }
    }
    
}