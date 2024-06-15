using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))] //Needs the camera
public class PlayerCameraMovement : MonoBehaviour
{
    private PlayerInput playerInput;

    [Header("Player Camera Movement")]
    [SerializeField] private float turnSpeed = 10.0f; //For rotation of the head
    [SerializeField] private bool invertMouse;

    private float camXRotation;

    // Start is called before the first frame update
    void Start()
    {
        playerInput = PlayerInput.GetInstance();
        //HideMouse
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        RotateCamera();
    }
    private void RotateCamera()
    {
        //Camera up/down movement

        camXRotation += Time.deltaTime * playerInput.mouseY * turnSpeed * (invertMouse ? 1 : -1); //checks if invert mouse is true or false.
        camXRotation = Mathf.Clamp(camXRotation, -50.0f, 50.0f); //Limits the rotation of the head on the x axis.
        transform.localRotation = Quaternion.Euler(camXRotation, 0, 0);
    }
}
