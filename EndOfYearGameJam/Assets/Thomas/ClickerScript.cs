using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClickerScript : MonoBehaviour
{
    //e= cards level
    //f = Influence / dark energy - currency allows you to unlock and upgrade cards, allowing you to get win condition after accumulating a certain amount.
    //c =Cultists - people amount of people in cult
    //l = loyalty - how loyal they are to cult
    //i = infamy - negative multiplier that affects influence
    //A = initial number (just for math)

    //l(c/2(2a + (c-1))) = f 

    public float influenceCount;
    public float infamyCount;
    public TMP_Text countTxt;
    public TMP_Text infamyCountTxt;
    public TMP_Text onClickTxt;

    public float upgrade1Count;
    public float upgrade1Cost;
    public TMP_Text upgrade1Txt;
    public float clickMult;

    [Header("Upgrade2: mind control")]
    public float upgrade2E; //Upgrade2 = mind control
    public float upgrade2F; //Mind con influence
    public float upgrade2I; //Mind con infamy
    public float upgrade2L; //Mind con loyalty
    public float upgrade2C; //Mind con cultists
    public float upgrade2A;
    public float upgrade2Cost;
    public float upgrade2Infamy;
    public float upgrade2Time;
    public TMP_Text upgrade2Txt;

    [Header("Upgrade3: social media")]
    public float upgrade3E; //Upgrade2 = social media
    public float upgrade3F; //Soc med influence
    public float upgrade3I; //Soc med infamy
    public float upgrade3L; //Soc med loyalty
    public float upgrade3C; //Soc med cultists
    public float upgrade3A;
    public float upgrade3Cost;
    public float upgrade3Infamy;
    public float upgrade3Time;
    public TMP_Text upgrade3Txt;
    // Start is called before the first frame update
    void Start()
    {
        upgrade2Time = Time.time - 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (upgrade2Time + 10 < Time.time && upgrade2E > 0) //mind control
        {
            upgrade2Time = Time.time;
            upgrade2F += (upgrade2L * (upgrade2E + (upgrade2C / 2 * ((2 * upgrade2E) + (upgrade2C - 1)))));
            infamyCount += upgrade2I;
            upgrade2Infamy += upgrade2I;
            upgrade2Txt.text = ("Cost: " + upgrade2Cost + ", Upgrades: " + upgrade2E + ", Influence: " + upgrade2F + ", Infamy: " + upgrade2Infamy).ToString();
        }

        if (upgrade3Time + 10 < Time.time && upgrade3E > 0) //social media
        {
            upgrade3Time = Time.time;
            upgrade3F += (upgrade3L * (upgrade3E + (upgrade3C / 2 * ((2 * upgrade3E) + (upgrade3C - 1)))));
            infamyCount += upgrade3I;
            upgrade3Infamy += upgrade3I;
            upgrade3Txt.text = ("Cost: " + upgrade3Cost + ", Upgrades: " + upgrade3E + ", Influence: " + upgrade3F + ", Infamy: " + upgrade3Infamy).ToString();
        }
        onClickTxt.text = ("On click: " + ((1 + clickMult) / (1 + (infamyCount / 10)))).ToString();
        infamyCountTxt.text = infamyCount.ToString();
    }
    public void onUpgrade1()
    {
        if (influenceCount >= upgrade1Cost)
        {
            influenceCount -= upgrade1Cost;
            upgrade1Count += 1;
            clickMult = ((upgrade1Count / 10) + ((upgrade1Count - 1) / 100));
            upgrade1Cost += (10 * (1 + clickMult));
            upgrade1Txt.text = ("Cost: " + upgrade1Cost + ", Upgrades: " + upgrade1Count + ", Mult: " + clickMult).ToString();
            countTxt.text = influenceCount.ToString();
        }
    }
    public void onUpgrade2() // mind control
    {
        if (influenceCount >= upgrade2Cost)
        {
            influenceCount -= upgrade2Cost;
            upgrade2E += 1;
            upgrade2Cost += (100 * (1 + (upgrade2E / 2)));
            countTxt.text = influenceCount.ToString();
            upgrade2Txt.text = ("Cost: " + upgrade2Cost + ", Upgrades: " + upgrade2E + ", Influence: " + upgrade2F + ", Infamy: " + upgrade2Infamy).ToString();
        }
    }
    public void onUpgrade2Sac()
    {
        infamyCount -= upgrade2Infamy;
        influenceCount += upgrade2F;
        upgrade2F = 0;
        upgrade2Infamy = 0;
        upgrade2Cost = 100;
        upgrade2E = 0;
        countTxt.text = influenceCount.ToString();
        upgrade2Txt.text = ("Cost: " + upgrade2Cost + ", Upgrades: " + upgrade2E + ", Influence: " + upgrade2F + ", Infamy: " + upgrade2Infamy).ToString();
    }

    public void onUpgrade3() // mind control
    {
        if (influenceCount >= upgrade3Cost)
        {
            influenceCount -= upgrade3Cost;
            upgrade3E += 1;
            upgrade3Cost += (125 * (1 + (upgrade3E / 2)));
            countTxt.text = influenceCount.ToString();
            upgrade3Txt.text = ("Cost: " + upgrade3Cost + ", Upgrades: " + upgrade3E + ", Influence: " + upgrade3F + ", Infamy: " + upgrade3Infamy).ToString();
        }
    }
    public void onUpgrade3Sac()
    {
        infamyCount -= upgrade3Infamy;
        influenceCount += upgrade3F;
        upgrade3F = 0;
        upgrade3Infamy = 0;
        upgrade3Cost = 125;
        upgrade3E = 0;
        countTxt.text = influenceCount.ToString();
        upgrade3Txt.text = ("Cost: " + upgrade3Cost + ", Upgrades: " + upgrade3E + ", Influence: " + upgrade3F + ", Infamy: " + upgrade3Infamy).ToString();
    }
    public void onClick()
    {
        if (upgrade1Count != 0)
        {
            influenceCount += (1 + clickMult) / (1 + (infamyCount / 10));
        }
        else if (upgrade1Count == 0 )
        {
            influenceCount += 1 / (1 + (infamyCount/10));
        }
        countTxt.text = influenceCount.ToString();
    }
}
