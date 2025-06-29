using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TurnCounter : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject enemy;

    public bool pTurn;
    public bool eTurn;

    public TMP_Text battleText;
    public TMP_Text turnText;

    public bool playerDead = false;
    public bool enemyDead = false;

    private float enemyTxtTimer;
    private float deathTxtTimer = 0;

    void Start()
    {
        player = GameObject.Find("Player");
        enemy = GameObject.Find("Enemy");
    }

    void Update()
    {
        if (player.GetComponent<Player>().playerCurrentHealth <= 0 )
        {
            playerDead = true;
            pTurn = false;
            eTurn = false;
        }
        if (enemy.GetComponent<Enemy>().enemyCurrentHealth <= 0)
        {
            enemyDead = true;
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
}
