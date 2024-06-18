using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-100)] //This player input will get executed before every other script
public class PlayerInput : MonoBehaviour //This script should be called before every other script. Manages anything that has to do with inputs.
{
    public float horizontal { get; private set; } //Encapsulation allows you to hide values for your objects. Only class that can set player input, but other classes can get access to the values.
    public float vertical { get; private set; }
    public float mouseX { get; private set; }
    public float mouseY { get; private set; }
    public bool sprintHeld { get; private set; }
    public bool activatePressed { get; private set; }
    public bool readPressed { get; private set; }
    public bool exitPressed { get; private set; }
    public bool pausePressed { get; private set; }

    public bool clear; //clear all Inputs that have been pressed

    //Singleton implementation
    private static PlayerInput instance;

    public static PlayerInput GetInstance()
    {
        return instance;
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this; //Setting this value to the instance of player input that has been created by Unity when we add this as a component of a game object.
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ClearInput();
        ProcessInput();
    }

    void ProcessInput()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        sprintHeld = sprintHeld || Input.GetButton("Sprint"); //sprintHeld or Input
        activatePressed = activatePressed || Input.GetKeyDown(KeyCode.E);
        readPressed = readPressed || Input.GetKeyDown(KeyCode.F);
        exitPressed = exitPressed || Input.GetKeyDown(KeyCode.M);
    }

    private void FixedUpdate()
    {
        clear = true;
    }

    void ClearInput()
    {
        if (!clear) return;

        horizontal = 0;
        vertical = 0;
        mouseX = 0;
        mouseY = 0;

        sprintHeld = false; //sprintHeld or Input
        activatePressed = false;
        readPressed = false;
        exitPressed = false;
    }
}
