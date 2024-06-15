using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class SceneSwitcher : MonoBehaviour
{
    //public UnityEvent onEscapePressed;
    private PlayerInput playerInput;

    // Start is called before the first frame update
    void Start()
    {
        playerInput = PlayerInput.GetInstance();
    }

    void Update()
    {
        //Scene currentScene = SceneManager.GetActiveScene();
    }

    public void SwitchScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    //public void ReturnToMainMenu()
    //{
        //if (playerInput.exitPressed)
        //{
            //Debug.Log("Escape was pressed");
            //onEscapePressed.Invoke();
        //}
    //}
}
