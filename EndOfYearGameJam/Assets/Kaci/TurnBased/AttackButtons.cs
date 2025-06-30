using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackButtons : MonoBehaviour
{
    [SerializeField] private Button button;
    public GameObject player;
    public bool assigned;
    [SerializeField] private int buttonType;

    void Update()
    {
        if(assigned == false)
        {
            Assign();
        }
    }

    void Assign()
    {
        player = GameObject.Find("Player(Clone)");
        button.onClick.AddListener(player.GetComponent<Player>().hasAttacked);
        if (buttonType == 0)
        {
            button.onClick.AddListener(player.gameObject.GetComponent<Player>().Attack);
        }
        if (buttonType == 1)
        {
            button.onClick.AddListener(player.gameObject.GetComponent<Player>().Defend);
        }
        if (buttonType == 2)
        {
            button.onClick.AddListener(player.gameObject.GetComponent<Player>().Special);
        }
        if (buttonType == 3)
        {
            button.onClick.AddListener(player.gameObject.GetComponent<Player>().Poison);
        }
        if (buttonType == 4)
        {
            button.onClick.AddListener(player.gameObject.GetComponent<Player>().Paralysis);
        }
        if (buttonType == 5)
        {
            button.onClick.AddListener(player.gameObject.GetComponent<Player>().Foretell);
        }
        assigned = true;
    }

    public void AssignReset()
    {
        assigned = false;
        player = null;
    }

    public void FindPlayer()
    {

    }
}
