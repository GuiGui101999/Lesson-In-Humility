using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public static UiManager Instance;

    [SerializeField] private Health playerHealth;

    public CharacterController playerController;

    [Header("UI Elements")]
    public TMP_Text healthTxt;
    public GameObject gameOverTxt; 


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

    void Start()
    {

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
        playerController.GetComponent<CharacterController>().enabled = false;
        gameOverTxt.SetActive(true);
    }

    public void OnGameSuccess()
    {

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
