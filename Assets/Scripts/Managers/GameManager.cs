using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private SectionManager[] levels;
    private static GameManager Instance;

    private GameState currentState;

    private bool isInputActive = true;

    private SectionManager currentLevel;
    private UiManager uiManager;
    public CharacterController playerController;

    private int currentLevelIndex = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public static GameManager GetInstance()
    {
        return Instance;
    }

    public bool InputActive()
    {
        return isInputActive;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Go to the briefing state of the game
        if (levels.Length > 0)
        {
            ChangeState(GameState.Briefing, levels[currentLevelIndex]);
        }

        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            playerController = playerObject.GetComponent<CharacterController>();
        }
        else
        {
            Debug.LogError("Player object not found");
        }

        if (uiManager == null)
        {
            uiManager = FindObjectOfType<UiManager>();
            if (uiManager == null)
            {
                Debug.Log("UiManager not found");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeState(GameState state, SectionManager level)
    {
        currentState = state;
        currentLevel = level;

        switch (currentState)
        {
            case GameState.Briefing:
                StartBriefing();
                break;
            case GameState.LevelStart:
                InitialiseLevel();
                break;
            case GameState.LevelIn:
                RunLevel();
                break;
            case GameState.LevelEnd:
                CompleteLevel();
                break;
            case GameState.GameOver:
                GameOver();
                break;
            case GameState.GameEnd:
                GameEnd();
                break;
        }
    }

    private void StartBriefing()
    {
        Debug.Log("Well, briefing Started");

        //Disable Player Input
        isInputActive = false;

        //Start the level
        ChangeState(GameState.LevelStart, currentLevel);
    }
    private void InitialiseLevel()
    {
        Debug.Log("Well, Level Initialised");
        isInputActive = true;
        currentLevel.StartLevel();
        ChangeState(GameState.LevelIn, currentLevel);
    }

    private void RunLevel()
    {
        Debug.Log("Well, Level Running");
    }

    private void CompleteLevel()
    {
        Debug.Log("Well, Level Complete");

        //Go to the next level
        ChangeState(GameState.LevelStart, levels[++currentLevelIndex]);

        Debug.Log($"This is {currentLevel} at {currentLevelIndex}");
    }

    private void GameOver()
    {
        Debug.Log("Well, Level Game Over and You Lose");
        uiManager.OnDeath();
    }
    private void GameEnd()
    {
        Debug.Log("Well, Game has Ended and You Win");
        uiManager.OnGameSuccess();
    }

    public enum GameState
    {
        Briefing,
        LevelStart,
        LevelIn,
        LevelEnd,
        GameOver,
        GameEnd
    }
}
