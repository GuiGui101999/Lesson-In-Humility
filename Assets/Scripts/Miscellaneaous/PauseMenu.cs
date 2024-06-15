using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private PlayerInput playerInput;
    [SerializeField] public GameObject pauseMenuUI;
    private bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        playerInput = PlayerInput.GetInstance();
        pauseMenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInput.pausePressed && isPaused)
        {
            Resume();
        }
        if (playerInput.pausePressed && !isPaused)
        {
            Pause();
        }
    }

    public void Resume()
    {
        playerInput.enabled = true;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }

    public void Pause()
    {
        playerInput.enabled = false;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;
    }
}
