using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 5f;
    public float lookSpeed = 5f;
    private Camera playerCamera;
    public bool puzzleMode = false;

    public Light flashlight;
    private bool flashlightActive = false;

    void Start()
    {
        playerCamera = Camera.main;
    }

    void Update()
    {
        if (!puzzleMode)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput).normalized * speed * Time.deltaTime;
            transform.Translate(movement);

            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            transform.Rotate(Vector3.up * mouseX * lookSpeed);
            playerCamera.transform.Rotate(Vector3.right * -mouseY * lookSpeed);

            if (Input.GetKeyDown(KeyCode.E))
            {
                flashlightActive = !flashlightActive;
                flashlight.enabled = flashlightActive;
            }
        }
    }
}
