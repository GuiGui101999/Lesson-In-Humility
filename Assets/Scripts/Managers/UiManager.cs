using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public static UiManager Instance;

    [SerializeField] private Health playerHealth;
    //[SerializeField] private GameObject GameOverEvent;
    //[SerializeField] private GameObject GameEndCutscene;

    [Header("UI Elements")]
    public TMP_Text healthTxt;
    public GameObject gameOverTxt; //Game object because we don't need a text and using a text as a game object due to use of images.
    //public GameObject gameSuccessTxt;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //gameOverTxt.SetActive(false);
        //GameOverEvent.SetActive(false);
        //gameSuccessTxt.SetActive(false);
    }

    private void OnEnable() //Only gets called when object becomes enabled within the scene.
    {
        playerHealth.OnHealthUpdated += OnHealthUpdate; //Subscribing to OnHealthUpdate.
        playerHealth.OnDeath += OnDeath; //Subscribing to OnDeath.
    }

    private void OnHealthUpdate(float health)
    {
        healthTxt.text = "HEALTH:" + Mathf.Floor(health).ToString();
    }
    public void OnDeath()
    {
        //GameOverEvent.SetActive(true);
        gameOverTxt.SetActive(true);
    }

    public void OnGameSuccess()
    {
        //GameEndCutscene.SetActive(true);
        //gameSuccessTxt.SetActive(true);
    }

    private void OnDestroy()
    {
        playerHealth.OnHealthUpdated -= OnHealthUpdate;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
