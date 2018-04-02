using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float moveSpeed = 5.0f;
    public float jumpSpeed = 5.0f;
    public float mouseSensitivity = 1.0f;
    public float gravity = 9.8f;
    public Camera cam;
    
    private CharacterController controller;
    private Vector3 movement;

    
    float rotY;

    // Use this for initialization
    void Start () {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {

        //TODO time.deltaTime på rotation?
        float rotX = Input.GetAxis("Mouse X") * mouseSensitivity;
        rotY -= (Input.GetAxis("Mouse Y") * mouseSensitivity);
        
        transform.Rotate(new Vector3(0, rotX, 0));

        rotY = Mathf.Clamp(rotY, -89.0f, 89.0f);
        cam.transform.localRotation = Quaternion.Euler(rotY, 0, 0);

        movement = new Vector3(Input.GetAxis("Horizontal") *moveSpeed , movement.y, Input.GetAxis("Vertical") * moveSpeed);
        
        
        if (controller.isGrounded && Input.GetButton("Jump"))
            movement.y = jumpSpeed;
        movement.y -= gravity * Time.deltaTime;

        movement = transform.rotation * movement;
        controller.Move(movement * Time.deltaTime);



    }
}
