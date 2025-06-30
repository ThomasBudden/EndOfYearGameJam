using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelSwap : MonoBehaviour
{
    private Vector2 startTouchPos;
    private Vector2 endTouchPos;
    private float direction;
    [SerializeField] private List<GameObject> screens = new List<GameObject>();
    [SerializeField] private int screenShown;

    // Start is called before the first frame update
    void Start()
    {
        screens[screenShown].SetActive(true);
    }

    // Update is called once per frame
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
                direction = startTouchPos.x - endTouchPos.x;
                if (direction > 100)
                {
                    screens[screenShown].SetActive(false);
                    screenShown += 1;
                    if (screenShown > 2)
                    {
                        screenShown = 0;
                    }
                    screens[screenShown].SetActive(true);
                }
                else if (direction < -100)
                {
                    screens[screenShown].SetActive(false);
                    screenShown -= 1;
                    if (screenShown < 0)
                    {
                        screenShown = 2;
                    }
                    screens[screenShown].SetActive(true);
                }
            }
        }
    }
}
