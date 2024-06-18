using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ReturnToMainMenu : MonoBehaviour
{
    private PlayerInput playerInput;

    // Start is called before the first frame update
    void Start()
    {
        playerInput = PlayerInput.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void MainMenuOnKeyPressed()
    {
        if (playerInput.exitPressed)
        {
            Debug.Log("Escape was pressed");
            SceneManager.LoadScene("MainMenu");
        }
    }
}
