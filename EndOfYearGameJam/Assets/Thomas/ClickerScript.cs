using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClickerScript : MonoBehaviour
{
    public float clickCount;
    public TMP_Text countTxt;
    public float upgrade1Count;
    public float upgrade1Cost;
    public TMP_Text upgrade1Txt;
    public float upgrade2Count;
    public float upgrade2Cost;
    public TMP_Text upgrade2Txt;
    public float upgrade2Time;
    private float clickMult;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (upgrade2Time + (1 / upgrade2Count) < Time.time && upgrade2Count > 0)
        {
            upgrade2Time = Time.time;
            clickCount += 1;
            countTxt.text = clickCount.ToString();
        }
    }
    public void onUpgrade1()
    {
        if (clickCount >= upgrade1Cost)
        {
            clickCount -= upgrade1Cost;
            upgrade1Count += 1;
            clickMult = upgrade1Count / 10;
            upgrade1Cost += (10 * (1 + clickMult));
            upgrade1Txt.text = ("Cost: " + upgrade1Cost + ", Upgrades: " + upgrade1Count + ", Mult: " + (1 + (upgrade1Count / 10))).ToString();
            countTxt.text = clickCount.ToString();
        }
    }
    public void onUpgrade2()
    {
        if (clickCount >= upgrade2Cost)
        {
            clickCount -= upgrade2Cost;
            upgrade2Count += 1;
            upgrade2Cost += (100 * (1 + (upgrade2Count / 2)));
            upgrade2Txt.text = ("Cost: " + upgrade2Cost + ", Upgrades: " + upgrade2Count + ", Per Sec: " + upgrade1Count).ToString();
            countTxt.text = clickCount.ToString();
        }
    }
    public void onClick()
    {
        if (upgrade1Count != 0)
        {
            clickCount += (1 + clickMult);
        }
        else if (upgrade1Count == 0 )
        {
            clickCount += 1;
        }
        countTxt.text = clickCount.ToString();
    }
}
