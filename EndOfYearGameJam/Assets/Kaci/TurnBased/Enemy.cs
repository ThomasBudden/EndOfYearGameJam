using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public GameObject turnCounter;
    public GameObject player;

    public float enemyCurrentHealth;
    [SerializeField] private float enemyMaxHealth;

    public bool enemyDefended;

    private int moveRoll;
    private int specialRoll;
    private int dodgeRoll;
    private bool dodge;
    private int backfireRoll;
    private bool backfire;
    private int paralysisRoll;
    public bool enemyParalysis;
    public int enemyParalysisTurnCounter;
    private int poisonRoll;
    public bool enemyPoison;
    public int enemyPoisonTurnCounter;

    public Image enemyHealthBar;
    public GameObject enemyPoisonedText;
    public GameObject enemyParalysedText;

    void Start()
    {
        enemyCurrentHealth = enemyMaxHealth;
        player = GameObject.Find("Player(Clone)");
        turnCounter = GameObject.Find("TurnBasedBattle");
    }

    void Update()
    {
        enemyHealthBar.fillAmount = enemyCurrentHealth / enemyMaxHealth;

        if (turnCounter.gameObject.GetComponent<TurnCounter>().eTurn == true && turnCounter.GetComponent<TurnCounter>().enemyDead == false)
        {
            turnCounter.gameObject.GetComponent<TurnCounter>().eTurn = false;
            Invoke("PoisonCheck", 2);
            Invoke("Action", 2);
            Invoke("EndOfTurn", 5);
        }
    }

    void Action()
    {
        if (enemyParalysis == true)
        {
            turnCounter.gameObject.GetComponent<TurnCounter>().battleText.text = "Enemy is paralysed. it cant attack";
            enemyParalysisTurnCounter--;
            if (enemyParalysisTurnCounter == 0)
            {
                Invoke("EndParalysis", 1);
                enemyParalysedText.SetActive(false);
                turnCounter.gameObject.GetComponent<TurnCounter>().eTurn = false;
                Invoke("EndOfTurn", 3);
            }
            turnCounter.gameObject.GetComponent<TurnCounter>().eTurn = false;
            Invoke("EndOfTurn", 3);
        }
        else
        {
            moveRoll = Random.Range(0, 11);

            if (moveRoll == 0 || moveRoll == 1 || moveRoll == 2)
            {
                turnCounter.gameObject.GetComponent<TurnCounter>().battleText.text = "Enemy Chose Defend";
                Invoke("Defend", 2);
                Invoke("EndOfTurn", 3);

            }
            else if (moveRoll == 3 || moveRoll == 4)
            {
                turnCounter.gameObject.GetComponent<TurnCounter>().battleText.text = "Enemy Chose Attack";
                Invoke("Attack", 2);
                Invoke("EndOfTurn", 3);
            }
            else if (moveRoll == 5 || moveRoll == 7)
            {
                turnCounter.gameObject.GetComponent<TurnCounter>().battleText.text = "Enemy Chose Special";
                Invoke("Special", 2);
                Invoke("EndOfTurn", 3);
            }
            else if (moveRoll == 8 || moveRoll == 9)
            {
                turnCounter.gameObject.GetComponent<TurnCounter>().battleText.text = "Enemy Chose Paralysis";
                Invoke("Paralysis", 2);
                Invoke("EndOfTurn", 3);
            }
            else if (moveRoll == 10)
            {
                turnCounter.gameObject.GetComponent<TurnCounter>().battleText.text = "Enemy Chose poison";
                Invoke("Poison", 2);
                Invoke("EndOfTurn", 3);
            }
            else if (moveRoll == 6)
            {
                turnCounter.gameObject.GetComponent<TurnCounter>().battleText.text = "Enemy Missed";
                Invoke("EndOfTurn", 3);
            }
            else
            {
                turnCounter.gameObject.GetComponent<TurnCounter>().battleText.text = "Enemy Failed To Choose";
                Invoke("EndOfTurn", 3);
            }
        }
    }

    void Defend()
    {
        turnCounter.gameObject.GetComponent<TurnCounter>().battleText.text = "Enemy braced itself";
        enemyDefended = true;
    }

    void Attack()
    {
        dodgeRoll = Random.Range(0, 4);

        if (dodgeRoll == 3)
        {
            dodge = true;
        }
        else
        {
            dodge = false;
        }

        backfireRoll = Random.Range(0, 6);

        if (backfireRoll == 3)
        {
            backfire = true;
        }
        else
        {
            backfire = false;
        }

        if (dodge == false)
        {
            if (backfire == false)
            {
                if (player.GetComponent<Player>().playerDefended == false && dodge == false)
                {
                    turnCounter.gameObject.GetComponent<TurnCounter>().battleText.text = "Enemy does 20 damage";
                    player.gameObject.GetComponent<Player>().playerCurrentHealth -= 20;
                }
                else if (player.GetComponent<Player>().playerDefended == true && dodge == false)
                {
                    turnCounter.gameObject.GetComponent<TurnCounter>().battleText.text = "Player defended! Enemy does 10 damage";
                    player.gameObject.GetComponent<Player>().playerCurrentHealth -= 10;
                }
            }
            else
            {
                turnCounter.gameObject.GetComponent<TurnCounter>().battleText.text = "It backfired! Enemy takes 20 damage";
                enemyCurrentHealth -= 20;
            }
        }
        else
        {
            turnCounter.gameObject.GetComponent<TurnCounter>().battleText.text = "Player dodged!";
            backfire = false;
        }
    }

    void Special()
    {
        dodgeRoll = Random.Range(0, 5);

        if (dodgeRoll == 3)
        {
            dodge = true;
        }
        else
        {
            dodge = false;
        }

        backfireRoll = Random.Range(0, 4);

        if (backfireRoll == 3)
        {
            backfire = true;
        }
        else
        {
            backfire = false;
        }

        specialRoll = Random.Range(0, 3);

        if (dodge == false)
        {
            if (backfire == false)
            {
                if (specialRoll == 0 && dodge == false)
                {
                    turnCounter.gameObject.GetComponent<TurnCounter>().battleText.text = "Enemy used special attack. Player took 35 damage";
                    player.gameObject.GetComponent<Player>().playerCurrentHealth -= 35;
                }
                else if (specialRoll == 1 || specialRoll == 2 && dodge == false)
                {
                    turnCounter.gameObject.GetComponent<TurnCounter>().battleText.text = "Enemy used special attack. it missed";
                }
            }
            else
            {
                turnCounter.gameObject.GetComponent<TurnCounter>().battleText.text = "It backfired! Enemy takes 35 damage";
                enemyCurrentHealth -= 35;
            }
        }
        else
        {
            turnCounter.gameObject.GetComponent<TurnCounter>().battleText.text = "Player dodged!";
            backfire = false;
        }
    }

    void Paralysis()
    {
        paralysisRoll = Random.Range(0, 5);
        dodgeRoll = Random.Range(0, 5);

        if (dodgeRoll == 3)
        {
            dodge = true;
        }
        else
        {
            dodge = false;
        }

        if (dodge == false)
        {
            if (player.GetComponent<Player>().playerParalysis == true)
            {
                turnCounter.gameObject.GetComponent<TurnCounter>().battleText.text = "player is already paralysed";
            }
            else
            {
                if (paralysisRoll == 2 && player.GetComponent<Player>().playerDefended == false)
                {
                    turnCounter.gameObject.GetComponent<TurnCounter>().battleText.text = "it worked. player is paralysed for 3 turns";
                    player.GetComponent<Player>().playerParalysisTurnCounter = 3;
                    player.GetComponent<Player>().playerParalysis = true;
                    player.GetComponent<Player>().playerParalysisText.SetActive(true);
                }
                else if (paralysisRoll == 2 && player.GetComponent<Player>().playerDefended == true)
                {
                    turnCounter.gameObject.GetComponent<TurnCounter>().battleText.text = "player defended. player is paralysed for 2 turns";
                    player.GetComponent<Player>().playerParalysisTurnCounter = 2;
                    player.GetComponent<Player>().playerParalysis = true;
                    player.GetComponent<Player>().playerParalysisText.SetActive(true);
                }
                else
                {
                    turnCounter.gameObject.GetComponent<TurnCounter>().battleText.text = "It failed!";
                }
            }
        }
        else
        {
            turnCounter.gameObject.GetComponent<TurnCounter>().battleText.text = "Player dodged!";
        }
    }

    void Poison()
    {
        poisonRoll = Random.Range(0, 5);
        dodgeRoll = Random.Range(0, 5);

        if (dodgeRoll == 3)
        {
            dodge = true;
        }
        else
        {
            dodge = false;
        }

        if (dodge == false)
        {
            if (player.GetComponent<Player>().playerPoison == true)
            {
                turnCounter.gameObject.GetComponent<TurnCounter>().battleText.text = "player is already poisoned";
            }
            else
            {
                if (poisonRoll == 2 && player.GetComponent<Player>().playerDefended == false)
                {
                    turnCounter.gameObject.GetComponent<TurnCounter>().battleText.text = "it worked. player is poisoned for 5 turns";
                    player.GetComponent<Player>().playerPoisonTurnCounter = 5;
                    player.GetComponent<Player>().playerPoison = true;
                    player.GetComponent<Player>().playerPoisonedText.SetActive(true);
                }
                else if (poisonRoll == 2 && player.GetComponent<Player>().playerDefended == true)
                {
                    turnCounter.gameObject.GetComponent<TurnCounter>().battleText.text = "player defended. player is poisoned for 3 turns";
                    player.GetComponent<Player>().playerPoisonTurnCounter = 3;
                    player.GetComponent<Player>().playerPoison = true;
                    player.GetComponent<Player>().playerPoisonedText.SetActive(true);
                }
                else
                {
                    turnCounter.gameObject.GetComponent<TurnCounter>().battleText.text = "It failed!";
                }
            }
        }
        else
        {
            turnCounter.gameObject.GetComponent<TurnCounter>().battleText.text = "Player dodged!";
        }

    }

    void PoisonCheck()
    {
        if (enemyPoison == true)
        {
            turnCounter.gameObject.GetComponent<TurnCounter>().battleText.text = "Enemy is poisoned. it takes 10 damage";
            enemyCurrentHealth -= 10;
            enemyPoisonTurnCounter--;
            if (enemyPoisonTurnCounter == 0)
            {
                enemyPoisonedText.SetActive (false);
                Invoke("EndPoison", 3);
            }
        }
    }

    void EndOfTurn()
    {
        turnCounter.gameObject.GetComponent<TurnCounter>().pTurn = true;
        player.GetComponent<Player>().playerDefended = false;
        player.GetComponent<Player>().attacked = false;
        player.GetComponent<Player>().takePoisonDamage = true;
    }

    void EndParalysis()
    {
        turnCounter.gameObject.GetComponent<TurnCounter>().battleText.text = "Enemy is no longer paralysed";
        enemyParalysis = false;
        enemyParalysedText.SetActive(false);
    }

    void EndPoison()
    {
        turnCounter.gameObject.GetComponent<TurnCounter>().battleText.text = "Enemy is no longer poisoned";
        enemyPoison = false;
        enemyParalysedText.SetActive(false);
    }

}
