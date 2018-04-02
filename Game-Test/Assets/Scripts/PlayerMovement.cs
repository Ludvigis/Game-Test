using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float moveSpeed = 5.0f;
    public float mouseSensitivity = 1.0f;
    public Camera cam;

    private CharacterController controller;

	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {

        //TODO time.deltaTime på rotation?
        float rotX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float rotY = - (Input.GetAxis("Mouse Y") * mouseSensitivity);
        transform.Rotate(new Vector3(0, rotX, 0));
        cam.transform.Rotate(rotY, 0, 0);
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, 0, Input.GetAxis("Vertical") * moveSpeed);
        movement = transform.rotation * movement;
        controller.Move(movement * Time.deltaTime);

    }
}
