using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject playerTurnCounter;
    public GameObject enemy;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject attacks;
    [SerializeField] private GameObject desc;

    public float playerCurrentHealth;
    [SerializeField] private float playerMaxHealth;

    public Image playerHealthBar;
    public GameObject playerPoisonedText;
    public GameObject playerParalysisText;

    public bool playerDefended;
    private int specialRoll;
    private int dodgeRoll;
    private bool dodge;
    private int backfireRoll;
    private bool backfire;
    private int paralysisRoll;
    public bool playerParalysis;
    public int playerParalysisTurnCounter;
    private int poisonRoll;
    public bool playerPoison;
    public bool takePoisonDamage;
    public int playerPoisonTurnCounter;

    public bool attacked;
    private Animator anim;

    void Start()
    {
        playerCurrentHealth = playerMaxHealth;
        player = this.gameObject;
        
        enemy = GameObject.Find("Enemy(Clone)");
        playerTurnCounter = GameObject.Find("TurnBasedBattle");
        attacks = GameObject.Find("MoveButtons");
        desc = GameObject.Find("MoveDescriptionBox");
        attacks.GetComponentInChildren<AttackButtons>().player = this.gameObject;
        attacks.GetComponentInChildren<AttackButtons>().assigned = false;
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        playerHealthBar.fillAmount = playerCurrentHealth / playerMaxHealth;

        if (playerTurnCounter.gameObject.GetComponent<TurnCounter>().pTurn == true)
        {
            attacks.SetActive(true);
            desc.SetActive(true);

            if (playerPoison == true && takePoisonDamage == true)
            {
                takePoisonDamage = false;
                playerTurnCounter.gameObject.GetComponent<TurnCounter>().battleText.text = "player is poisoned. they takes 10 damage";
                playerCurrentHealth -= 10;
                playerPoisonTurnCounter--;
                if (playerPoisonTurnCounter == 0)
                {
                    playerPoisonedText.SetActive(false);
                    Invoke("EndPoison", 2);
                }
            }

            if (playerParalysis == true)
            {
                playerTurnCounter.gameObject.GetComponent<TurnCounter>().battleText.text = "player is paralysed. they cant attack";
                playerParalysisTurnCounter--;
                if (playerParalysisTurnCounter == 0)
                {
                    Invoke("EndParalysis", 1);
                    playerParalysisText.SetActive(false);
                    hasAttacked();
                    EndTurn();
                }
                EndTurn();
            }
            else
            {
                if(attacked == true)
                {
                    EndTurn();
                }
            }

        }
    }

    public void Attack()
    {
        dodgeRoll = Random.Range(0, 5);
        anim.SetBool("attack", true);

        if (dodgeRoll == 3)
        {
            dodge = true;
        }
        else
        {
            dodge = false;
        }

        backfireRoll = Random.Range(0, 8);

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
                if (enemy.GetComponent<Enemy>().enemyDefended == false)
                {
                    playerTurnCounter.gameObject.GetComponent<TurnCounter>().battleText.text = "player does 30 damage";
                    enemy.GetComponent<Enemy>().enemyCurrentHealth -= 30;
                }
                else if (enemy.GetComponent<Enemy>().enemyDefended == true)
                {
                    playerTurnCounter.gameObject.GetComponent<TurnCounter>().battleText.text = "Enemy defended! player does 15 damage";
                    enemy.GetComponent<Enemy>().enemyCurrentHealth -= 15;
                }
            }
            else
            {
                playerTurnCounter.gameObject.GetComponent<TurnCounter>().battleText.text = "It backfired! Player takes 30 damage";
                playerCurrentHealth -= 20;
            }
        }
        else
        {
            playerTurnCounter.gameObject.GetComponent<TurnCounter>().battleText.text = "Enemy dodged!";
        }

        enemy.GetComponent<Enemy>().enemyDefended = false;

        EndTurn();
    }

    public void Defend()
    {
        playerTurnCounter.gameObject.GetComponent<TurnCounter>().battleText.text = "player braced themself";
        playerDefended = true;
        enemy.GetComponent<Enemy>().enemyDefended = false;

        EndTurn();
    }

    public void Special()
    {
        dodgeRoll = Random.Range(0, 5);
        anim.SetBool("attack", true);

        if (dodgeRoll == 3)
        {
            dodge = true;
        }
        else
        {
            dodge = false;
        }

        backfireRoll = Random.Range(0, 7);

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
                    playerTurnCounter.gameObject.GetComponent<TurnCounter>().battleText.text = "player used special attack. enemy took 45 damage";
                    enemy.GetComponent<Enemy>().enemyCurrentHealth -= 45;
                }
                else if (specialRoll == 1 || specialRoll == 2 && dodge == false)
                {
                    playerTurnCounter.gameObject.GetComponent<TurnCounter>().battleText.text = "player used special attack. it missed";
                }
            }
            else
            {
                playerTurnCounter.gameObject.GetComponent<TurnCounter>().battleText.text = "It backfired! Player takes 45 damage";
                playerCurrentHealth -= 45;
            }
        }
        else
        {
            playerTurnCounter.gameObject.GetComponent<TurnCounter>().battleText.text = "Enemy dodged!";
        }

        enemy.GetComponent<Enemy>().enemyDefended = false;

        EndTurn();
    }

    public void Poison()
    {
        poisonRoll = Random.Range(0, 5);
        dodgeRoll = Random.Range(0, 5);
        anim.SetBool("attack", true);

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

            if (enemy.GetComponent<Enemy>().enemyPoison == true)
            {
                playerTurnCounter.gameObject.GetComponent<TurnCounter>().battleText.text = "enemy is already poisoned";
            }
            else
            {
                if (poisonRoll == 2 && enemy.GetComponent<Enemy>().enemyPoison == false)
                {
                    playerTurnCounter.gameObject.GetComponent<TurnCounter>().battleText.text = "it worked. enemy is poisoned for 5 turns";
                    enemy.GetComponent<Enemy>().enemyPoisonTurnCounter = 5;
                    enemy.GetComponent<Enemy>().enemyPoison = true;
                    enemy.GetComponent<Enemy>().enemyPoisonedText.SetActive(true);
                }
                else if (poisonRoll == 2 && enemy.GetComponent<Enemy>().enemyPoison == true)
                {
                    playerTurnCounter.gameObject.GetComponent<TurnCounter>().battleText.text = "enemy defended. player is poisoned for 3 turns";
                    enemy.GetComponent<Enemy>().enemyPoisonTurnCounter = 3;
                    enemy.GetComponent<Enemy>().enemyPoison = true;
                    enemy.GetComponent<Enemy>().enemyPoisonedText.SetActive(true);
                }
                else
                {
                    playerTurnCounter.gameObject.GetComponent<TurnCounter>().battleText.text = "It failed!";
                }
            }
        }
        else
        {
            playerTurnCounter.gameObject.GetComponent<TurnCounter>().battleText.text = "Enemy dodged!";
        }

        enemy.GetComponent<Enemy>().enemyDefended = false;

        EndTurn();
    }

    public void Paralysis()
    {
        dodgeRoll = Random.Range(0, 5);
        paralysisRoll = Random.Range(0, 4);
        anim.SetBool("attack", true);

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
            if (enemy.GetComponent<Enemy>().enemyParalysis == true)
            {
                playerTurnCounter.gameObject.GetComponent<TurnCounter>().battleText.text = "enemy is already paralysed";
            }
            else
            {
                if (paralysisRoll == 2 && enemy.GetComponent<Enemy>().enemyDefended == false)
                {
                    playerTurnCounter.gameObject.GetComponent<TurnCounter>().battleText.text = "it worked. enemy is paralysed for 3 turns";
                    enemy.GetComponent<Enemy>().enemyParalysisTurnCounter = 3;
                    enemy.GetComponent<Enemy>().enemyParalysis = true;
                    enemy.GetComponent<Enemy>().enemyParalysedText.SetActive(true);
                }
                else if (paralysisRoll == 2 && enemy.GetComponent<Enemy>().enemyDefended == true)
                {
                    playerTurnCounter.gameObject.GetComponent<TurnCounter>().battleText.text = "enemy defended. enemy is paralysed for 1 turns";
                    enemy.GetComponent<Enemy>().enemyParalysisTurnCounter = 1;
                    enemy.GetComponent<Enemy>().enemyParalysis = true;
                    enemy.GetComponent<Enemy>().enemyParalysedText.SetActive(true);
                }
                else
                {
                    playerTurnCounter.gameObject.GetComponent<TurnCounter>().battleText.text = "It failed!";
                }
            }
        }
        else
        {
            playerTurnCounter.gameObject.GetComponent<TurnCounter>().battleText.text = "Enemy dodged!";
        }

        enemy.GetComponent<Enemy>().enemyDefended = false;

        EndTurn();
    }

    public void Foretell()
    {
        playerTurnCounter.GetComponent<TurnCounter>().battleText.text = enemy.GetComponent<Enemy>().enemyInfo;

        enemy.GetComponent<Enemy>().enemyDefended = false;

        EndTurn();
    }

     public void hasAttacked()
    {
        attacked = true;
    }

    void EndPoison()
    {
        playerTurnCounter.gameObject.GetComponent<TurnCounter>().battleText.text = "Player is no longer poisoned";
        playerPoison = false;
        playerPoisonedText.SetActive(false);
        enemy.GetComponent<Enemy>().enemyDefended = false;
    }

    void EndParalysis()
    {
        playerTurnCounter.gameObject.GetComponent<TurnCounter>().battleText.text = "Player is no longer paralysed";
        playerParalysis = false;
        playerParalysisText.SetActive(false);
        enemy.GetComponent<Enemy>().enemyDefended = false;
    }

    public void EndTurn()
    {
        playerTurnCounter.gameObject.GetComponent<TurnCounter>().pTurn = false;
        playerTurnCounter.gameObject.GetComponent<TurnCounter>().eTurn = true;
        attacks.SetActive(false);
        anim.SetBool("attack", false);
    }
}
