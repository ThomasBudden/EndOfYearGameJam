using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseMove : MonoBehaviour
{
    private Vector2 startTouchPos;
    private Vector2 endTouchPos;
    private float direction;
    [SerializeField] private GameObject moveSelect;
    [SerializeField] private List<GameObject> attacks = new List<GameObject>();
    [SerializeField] private int attackShown;

    void Start()
    {
        attacks[attackShown].SetActive(true);
    }

    public void BattleStart()
    {
        moveSelect.SetActive(true);
        attacks[attackShown].SetActive(true);
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                startTouchPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                endTouchPos = touch.position;
                direction = startTouchPos.y - endTouchPos.y;
                if(direction > 100)
                {
                    attacks[attackShown].SetActive(false);
                    attackShown += 1;
                    if(attackShown > 5)
                    {
                        attackShown = 0;
                    }
                    attacks[attackShown].SetActive(true);
                }
                else if(direction < -100)
                {
                    attacks[attackShown].SetActive(false);
                    attackShown -= 1;
                    if (attackShown < 0)
                    {
                        attackShown = 5;
                    }
                    attacks[attackShown].SetActive(true);
                }
            }
        }
    }
}