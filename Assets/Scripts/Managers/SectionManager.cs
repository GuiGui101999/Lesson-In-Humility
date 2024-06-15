using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;

public class SectionManager : MonoBehaviour
{
    [SerializeField] private bool isFinalLevel = false;
    public UnityEvent onLevelStart;
    public UnityEvent onLevelEnd;
    public bool gameEnd = false;

    public void StartLevel()
    {
        onLevelStart?.Invoke(); //Ensure that if onLevelStart is empty, that means that no functions are subscribed to it, and will not invoke.
    }

    public void EndLevel()
    {
        onLevelEnd?.Invoke();

        if (isFinalLevel)
        {
            //TO DO: Let game manager know to change game state to Game End. 
            GameManager.GetInstance().ChangeState(GameManager.GameState.GameEnd, this);

        }
        else
        {
            //TO DO; Let game manager know to change state to Level End.
            GameManager.GetInstance().ChangeState(GameManager.GameState.LevelEnd, this);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
