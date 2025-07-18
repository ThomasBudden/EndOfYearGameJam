using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TurnCounter : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    [SerializeField] private GameObject playerSpawnPos; 
    [SerializeField] private GameObject enemySpawnPos;
    [SerializeField] private GameObject playerSpawn;
    [SerializeField] private List<GameObject> enemyTypes = new List<GameObject>();
    [SerializeField] private Image playerHealthBar;
    [SerializeField] private Image enemyHealthBar;

    [SerializeField] private GameObject currency;

    private int enemyNo;

    public bool pTurn;
    public bool eTurn;

    private bool win;
    private bool lose;

    public TMP_Text battleText;
    public TMP_Text turnText;

    public bool playerDead = false;
    public bool enemyDead = false;

    private float enemyTxtTimer;
    private float deathTxtTimer = 0;

    [SerializeField] private GameObject backToGame;

    void Start()
    {
        backToGame.SetActive(false);
       // player = GameObject.Find("Player");
       // enemy = GameObject.Find("Enemy");
    }

    void Update()
    {
        if (player.GetComponent<Player>().playerCurrentHealth <= 0 )
        {
            playerDead = true;
            lose = true;
            backToGame.SetActive(true);
            pTurn = false;
            eTurn = false;
        }
        if (enemy.GetComponent<Enemy>().enemyCurrentHealth <= 0)
        {
            enemyDead = true;
            win = true;
            backToGame.SetActive(true);
            pTurn = false;
            eTurn = false;
        }

        if (playerDead == true)
        {
            deathTxtTimer += Time.deltaTime;

            if (deathTxtTimer > 1)
            {
                battleText.text = "Player lost the battle";
                turnText.text = "Battle Over";
            }
        }

        if (enemyDead == true)
        {
            deathTxtTimer += Time.deltaTime;

            if (deathTxtTimer > 1)
            {
                battleText.text = "Enemy dies. You Win!";
                turnText.text = "Battle Over";
            }
        }

        if (pTurn == true)
        {
            enemyTxtTimer = 0;
            turnText.text = "Player Turn";
        }
        else if (pTurn == false)
        {
            enemyTxtTimer += Time.deltaTime;

            if (enemyTxtTimer >= 2)
            {
                turnText.text = "Enemy Turn";
                enemyTxtTimer = 0;
            }

        }
    }

    public void BattleStart()
    {
        pTurn = true;
        eTurn = false;
        playerDead = false;
        enemyDead= false;
        battleText.text = "Battle Start";
        turnText.text = "Battle Start";
        enemyTxtTimer = 0;
        deathTxtTimer = 0;

        backToGame.SetActive(false);
        GameObject player = Instantiate(playerSpawn, playerSpawnPos.transform);
        this.player = player;
        enemyNo = Random.Range(0, 3);
        GameObject enemy = Instantiate(enemyTypes[enemyNo], enemySpawnPos.transform);
        this.enemy = enemy;

        player.GetComponent<Player>().playerHealthBar = playerHealthBar;

        enemy.GetComponent<Enemy>().enemyHealthBar = enemyHealthBar;

    }

    public void Reset()
    {
        Destroy(player);
        Destroy(enemy);
    }

    public void LoseBattle()
    {
        if(lose == true)
        {
            currency.GetComponent<ClickerScript>().influenceCount -= 100;
            if(currency.GetComponent<ClickerScript>().influenceCount <= 0)
            {
                currency.GetComponent<ClickerScript>().influenceCount = 0;
            }
            currency.GetComponent<ClickerScript>().cultistsCount -= 5;
            if(currency.GetComponent<ClickerScript>().cultistsCount <= 0)
            {
                currency.GetComponent<ClickerScript>().cultistsCount = 0;
            }
            lose = false;
        }
    }

    public void WinBattle()
    {
        if (win == true)
        {
            currency.GetComponent<ClickerScript>().influenceCount += 200;
            currency.GetComponent<ClickerScript>().infamyCount -= 20;
            if(currency.GetComponent<ClickerScript>().infamyCount <= 0)
            {
                currency.GetComponent<ClickerScript>().infamyCount = 0;
            }
            currency.GetComponent<ClickerScript>().cultistsCount += 10;
            currency.GetComponent<ClickerScript>().battlesWon++;
            win = false;
        }
    }
}
