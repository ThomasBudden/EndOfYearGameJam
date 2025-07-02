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
    public float cultistsCount;
    public TMP_Text cultistsCountTxt;
    public TMP_Text countTxt;
    public TMP_Text infamyCountTxt;
    public TMP_Text onClickTxt;

    private float timer;
    [SerializeField] private float saveTimer;
    [SerializeField] private GameObject saveInd;

    public float upgrade1Count;
    public float upgrade1Cost;
    public TMP_Text upgrade1Txt;
    public float clickMult;

    [SerializeField] private GameObject winCondition;
    [SerializeField] private bool winGame;

    [SerializeField] private GameObject winCondition2;
    [SerializeField] private bool winGame2;

    public int battlesWon;
    [SerializeField] private GameObject winCondition3;
    [SerializeField] private bool winGame3;

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

    [Header("Upgrade4: indoctronation")]
    public float upgrade4E; //Upgrade2 = indoctronation
    public float upgrade4F; //Mind con influence
    public float upgrade4I; //Mind con infamy
    public float upgrade4L; //Mind con loyalty
    public float upgrade4C; //Mind con cultists
    public float upgrade4A;
    public float upgrade4Cost;
    public float upgrade4Infamy;
    public float upgrade4Time;
    public TMP_Text upgrade4Txt;

    [Header("Upgrade5: leaflets")]
    public float upgrade5E; //Upgrade2 = leaflets
    public float upgrade5F; //Mind con influence
    public float upgrade5I; //Mind con infamy
    public float upgrade5L; //Mind con loyalty
    public float upgrade5C; //Mind con cultists
    public float upgrade5A;
    public float upgrade5Cost;
    public float upgrade5Infamy;
    public float upgrade5Time;
    public TMP_Text upgrade5Txt;

    [Header("Upgrade6: kidnapping")]
    public float upgrade6E; //Upgrade2 = kidnapping
    public float upgrade6F; //Mind con influence
    public float upgrade6I; //Mind con infamy
    public float upgrade6L; //Mind con loyalty
    public float upgrade6C; //Mind con cultists
    public float upgrade6A;
    public float upgrade6Cost;
    public float upgrade6Infamy;
    public float upgrade6Time;
    public TMP_Text upgrade6Txt;

    // Start is called before the first frame update
    void Start()
    {
        upgrade2Time = Time.time - 10;
        LoadGame();
    }

    // Update is called once per frame
    void Update()
    {
        saveTimer += Time.deltaTime;
        timer += Time.deltaTime;

        if (upgrade2Time + 10 < Time.time && upgrade2E > 0) //mind control
        {
            upgrade2Time = Time.time;
            upgrade2F += (upgrade2L * (upgrade2E + (upgrade2C / 2 * ((2 * upgrade2E) + (upgrade2C - 1)))));
            infamyCount += upgrade2I;
            influenceCount += 5;
            countTxt.text = influenceCount.ToString();
            upgrade2Infamy += upgrade2I;
            upgrade2Txt.text = ("Cost: " + upgrade2Cost + ", Upgrades: " + upgrade2E + ", Influence: " + upgrade2F + ", Infamy: " + upgrade2Infamy).ToString();
        }

        if (upgrade3Time + 10 < Time.time && upgrade3E > 0) //social media
        {
            upgrade3Time = Time.time;
            upgrade3F += (upgrade3L * (upgrade3E + (upgrade3C / 2 * ((2 * upgrade3E) + (upgrade3C - 1)))));
            infamyCount += upgrade3I;
            influenceCount += 7;
            countTxt.text = influenceCount.ToString();
            upgrade3Infamy += upgrade3I;
            upgrade3Txt.text = ("Cost: " + upgrade3Cost + ", Upgrades: " + upgrade3E + ", Influence: " + upgrade3F + ", Infamy: " + upgrade3Infamy).ToString();
        }

        if (upgrade4Time + 10 < Time.time && upgrade4E > 0) //indoctronation
        {
            upgrade4Time = Time.time;
            upgrade4F += (upgrade4L * (upgrade4E + (upgrade4C / 2 * ((2 * upgrade4E) + (upgrade4C - 1)))));
            infamyCount += upgrade4I;
            influenceCount += 10;
            countTxt.text = influenceCount.ToString();
            upgrade4Infamy += upgrade4I;
            upgrade4Txt.text = ("Cost: " + upgrade4Cost + ", Upgrades: " + upgrade4E + ", Influence: " + upgrade4F + ", Infamy: " + upgrade4Infamy).ToString();
        }

        if (upgrade5Time + 10 < Time.time && upgrade5E > 0) //leaflets
        {
            upgrade5Time = Time.time;
            upgrade5F += (upgrade5L * (upgrade5E + (upgrade5C / 2 * ((2 * upgrade5E) + (upgrade5C - 1)))));
            infamyCount += upgrade5I;
            influenceCount += 12;
            countTxt.text = influenceCount.ToString();
            upgrade5Infamy += upgrade5I;
            upgrade5Txt.text = ("Cost: " + upgrade5Cost + ", Upgrades: " + upgrade5E + ", Influence: " + upgrade5F + ", Infamy: " + upgrade5Infamy).ToString();
        }

        if (upgrade6Time + 10 < Time.time && upgrade6E > 0) //kidnapping
        {
            upgrade6Time = Time.time;
            upgrade6F += (upgrade6L * (upgrade6E + (upgrade6C / 2 * ((2 * upgrade6E) + (upgrade6C - 1)))));
            infamyCount += upgrade6I;
            influenceCount += 15;
            countTxt.text = influenceCount.ToString();
            upgrade6Infamy += upgrade6I;
            upgrade6Txt.text = ("Cost: " + upgrade6Cost + ", Upgrades: " + upgrade6E + ", Influence: " + upgrade6F + ", Infamy: " + upgrade6Infamy).ToString();
        }

        if(timer > 15)
        {
            infamyCount += upgrade1Count;
            timer = 0;
        }

        if(saveTimer >= 30)
        {
            SaveGame();
            saveTimer = 0;
        }

        onClickTxt.text = ("On click: " + ((1 + clickMult) / (1 + (infamyCount / 10)))).ToString();
        infamyCountTxt.text = infamyCount.ToString();

        if(influenceCount >= 1000 || winGame == true)
        {
            winGame = true;
            PlayerPrefs.SetInt("Win1", 1);
            winCondition.SetActive(true);
        }
        else
        {
            winCondition.SetActive(false);
        }

        if (influenceCount >= 10000 || winGame2 == true)
        {
            winGame2 = true;
            PlayerPrefs.SetInt("Win2", 1);
            winCondition2.SetActive(true);
        }
        else
        {
            winCondition2.SetActive(false);
        }

        if (battlesWon >= 5 || winGame3 == true)
        {
            winGame3 = true;
            PlayerPrefs.SetInt("Win2", 1);
            winCondition3.SetActive(true);
        }
        else
        {
            winCondition3.SetActive(false);
        }

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
            upgrade2C += 1;
            upgrade2L += 3;
            cultistsCount += upgrade2C;
            cultistsCountTxt.text = cultistsCount.ToString();  
            upgrade2Cost += (100 * (1 + (upgrade2E / 2)));
            countTxt.text = influenceCount.ToString();
            upgrade2Txt.text = ("Cost: " + upgrade2Cost + ", Upgrades: " + upgrade2E + ", Influence: " + upgrade2F + ", Infamy: " + upgrade2Infamy).ToString();
        }
    }
    public void onUpgrade2Sac()
    {
        infamyCount -= upgrade2Infamy;
        if(infamyCount < 0)
        {
            infamyCount = 0;
        }
        influenceCount += upgrade2F;
        upgrade2F = 0;
        upgrade2Infamy = 0;
        upgrade2Cost = 100;
        upgrade2E = 0;
        upgrade2C = 0;
        upgrade2L = 0;
        countTxt.text = influenceCount.ToString();
        upgrade2Txt.text = ("Cost: " + upgrade2Cost + ", Upgrades: " + upgrade2E + ", Influence: " + upgrade2F + ", Infamy: " + upgrade2Infamy).ToString();
    }

    public void onUpgrade3() // social media
    {
        if (influenceCount >= upgrade3Cost)
        {
            influenceCount -= upgrade3Cost;
            upgrade3E += 1;
            upgrade3C += 3;
            upgrade3L += 1;
            cultistsCount += upgrade3C;
            cultistsCountTxt.text = cultistsCount.ToString();
            upgrade3Cost += (125 * (1 + (upgrade3E / 2)));
            countTxt.text = influenceCount.ToString();
            upgrade3Txt.text = ("Cost: " + upgrade3Cost + ", Upgrades: " + upgrade3E + ", Influence: " + upgrade3F + ", Infamy: " + upgrade3Infamy).ToString();
        }
    }
    public void onUpgrade3Sac()
    {
        infamyCount -= upgrade3Infamy;
        if (infamyCount < 0)
        {
            infamyCount = 0;
        }
        influenceCount += upgrade3F;
        upgrade3F = 0;
        upgrade3Infamy = 0;
        upgrade3Cost = 125;
        upgrade3E = 0;
        upgrade3C = 0;
        upgrade3L = 0;
        countTxt.text = influenceCount.ToString();
        upgrade3Txt.text = ("Cost: " + upgrade3Cost + ", Upgrades: " + upgrade3E + ", Influence: " + upgrade3F + ", Infamy: " + upgrade3Infamy).ToString();
    }

    public void onUpgrade4() // indoctronation
    {
        if (influenceCount >= upgrade4Cost)
        {
            influenceCount -= upgrade4Cost;
            upgrade4E += 1;
            upgrade4C += 2;
            upgrade4L += 3;
            cultistsCount += upgrade4C;
            cultistsCountTxt.text = cultistsCount.ToString();
            upgrade4Cost += (150 * (1 + (upgrade4E / 2)));
            countTxt.text = influenceCount.ToString();
            upgrade4Txt.text = ("Cost: " + upgrade4Cost + ", Upgrades: " + upgrade4E + ", Influence: " + upgrade4F + ", Infamy: " + upgrade4Infamy).ToString();
        }
    }
    public void onUpgrade4Sac()
    {
        infamyCount -= upgrade4Infamy;
        if (infamyCount < 0)
        {
            infamyCount = 0;
        }
        influenceCount += upgrade4F;
        upgrade4F = 0;
        upgrade4Infamy = 0;
        upgrade4Cost = 150;
        upgrade4E = 0;
        upgrade4C = 0;
        upgrade4L = 0;
        countTxt.text = influenceCount.ToString();
        upgrade4Txt.text = ("Cost: " + upgrade4Cost + ", Upgrades: " + upgrade4E + ", Influence: " + upgrade4F + ", Infamy: " + upgrade4Infamy).ToString();
    }

    public void onUpgrade5() // leaflets
    {
        if (influenceCount >= upgrade5Cost)
        {
            influenceCount -= upgrade5Cost;
            upgrade5E += 1;
            upgrade5C += 2;
            upgrade5L += 2;
            cultistsCount += upgrade5C;
            cultistsCountTxt.text = cultistsCount.ToString();
            upgrade5Cost += (175 * (1 + (upgrade5E / 2)));
            countTxt.text = influenceCount.ToString();
            upgrade5Txt.text = ("Cost: " + upgrade5Cost + ", Upgrades: " + upgrade5E + ", Influence: " + upgrade5F + ", Infamy: " + upgrade5Infamy).ToString();
        }
    }
    public void onUpgrade5Sac()
    {
        infamyCount -= upgrade5Infamy;
        if (infamyCount < 0)
        {
            infamyCount = 0;
        }
        influenceCount += upgrade5F;
        upgrade5F = 0;
        upgrade5Infamy = 0;
        upgrade5Cost = 175;
        upgrade5E = 0;
        upgrade5C = 0;
        upgrade5L = 0;
        countTxt.text = influenceCount.ToString();
        upgrade5Txt.text = ("Cost: " + upgrade5Cost + ", Upgrades: " + upgrade5E + ", Influence: " + upgrade5F + ", Infamy: " + upgrade5Infamy).ToString();
    }

    public void onUpgrade6() // kidnapping
    {
        if (influenceCount >= upgrade6Cost)
        {
            influenceCount -= upgrade6Cost;
            upgrade6E += 1;
            upgrade6C += 2;
            upgrade6L += 1;
            cultistsCount += upgrade6C;
            cultistsCountTxt.text = cultistsCount.ToString();
            upgrade6Cost += (200 * (1 + (upgrade6E / 2)));
            countTxt.text = influenceCount.ToString();
            upgrade6Txt.text = ("Cost: " + upgrade6Cost + ", Upgrades: " + upgrade6E + ", Influence: " + upgrade6F + ", Infamy: " + upgrade6Infamy).ToString();
        }
    }
    public void onUpgrade6Sac()
    {
        infamyCount -= upgrade6Infamy;
        if (infamyCount < 0)
        {
            infamyCount = 0;
        }
        influenceCount += upgrade6F;
        upgrade6F = 0;
        upgrade6Infamy = 0;
        upgrade6Cost = 200;
        upgrade6E = 0;
        upgrade6C = 0;
        upgrade6L = 0;
        countTxt.text = influenceCount.ToString();
        upgrade6Txt.text = ("Cost: " + upgrade6Cost + ", Upgrades: " + upgrade6E + ", Influence: " + upgrade6F + ", Infamy: " + upgrade6Infamy).ToString();
    }

    public void onClick()
    {
        if (upgrade1Count != 0)
        {
            influenceCount += (1 + clickMult) / (1 + (infamyCount / 20));
        }
        else if (upgrade1Count == 0 )
        {
            influenceCount += 1 / (1 + (infamyCount/10));
        }
        countTxt.text = influenceCount.ToString();
    }

    public void UpdateTxt()
    {
        infamyCountTxt.text = infamyCount.ToString();
        countTxt.text = influenceCount.ToString();
        cultistsCountTxt.text = cultistsCount.ToString();
    }

    public void UpdateTxt1()
    {
        upgrade1Txt.text = ("Cost: " + upgrade1Cost + ", Upgrades: " + upgrade1Count + ", Mult: " + clickMult).ToString();
    }

    public void UpdateTxt2()
    {
        upgrade2Txt.text = ("Cost: " + upgrade2Cost + ", Upgrades: " + upgrade2E + ", Influence: " + upgrade2F + ", Infamy: " + upgrade2Infamy).ToString();
    }

    public void UpdateTxt3()
    {
        upgrade3Txt.text = ("Cost: " + upgrade3Cost + ", Upgrades: " + upgrade3E + ", Influence: " + upgrade3F + ", Infamy: " + upgrade3Infamy).ToString();
    }

    public void UpdateTxt4()
    {
        upgrade4Txt.text = ("Cost: " + upgrade4Cost + ", Upgrades: " + upgrade4E + ", Influence: " + upgrade4F + ", Infamy: " + upgrade4Infamy).ToString();
    }

    public void UpdateTxt5()
    {
        upgrade5Txt.text = ("Cost: " + upgrade5Cost + ", Upgrades: " + upgrade5E + ", Influence: " + upgrade5F + ", Infamy: " + upgrade5Infamy).ToString();
    }

    public void UpdateTxt6()
    {
        upgrade6Txt.text = ("Cost: " + upgrade6Cost + ", Upgrades: " + upgrade6E + ", Influence: " + upgrade6F + ", Infamy: " + upgrade6Infamy).ToString();
    }

    void Disappear()
    {
        saveInd.SetActive(false);
    }


    void SaveGame()
    {
        saveInd.SetActive(true);
        Invoke("Disappear", 1);

        PlayerPrefs.SetFloat("Influence", influenceCount);
        PlayerPrefs.SetFloat("Infamy", infamyCount);
        PlayerPrefs.SetFloat("Cultists", cultistsCount);

        PlayerPrefs.SetFloat("upgrade1Count", upgrade1Count);
        PlayerPrefs.SetFloat("upgrade1Cost", upgrade1Cost);
        PlayerPrefs.SetFloat("clickMult", clickMult);

        PlayerPrefs.SetFloat("upgrade2E", upgrade2E);
        PlayerPrefs.SetFloat("upgrade2F", upgrade2F);
        PlayerPrefs.SetFloat("upgrade2I", upgrade2Infamy);
        PlayerPrefs.SetFloat("upgrade2L", upgrade2L);
        PlayerPrefs.SetFloat("upgrade2C", upgrade2C);
        PlayerPrefs.SetFloat("upgrade2A", upgrade2A);
        PlayerPrefs.SetFloat("upgrade2Cost", upgrade2Cost);

        PlayerPrefs.SetFloat("upgrade3E", upgrade3E);
        PlayerPrefs.SetFloat("upgrade3F", upgrade3F);
        PlayerPrefs.SetFloat("upgrade3I", upgrade3Infamy);
        PlayerPrefs.SetFloat("upgrade3L", upgrade3L);
        PlayerPrefs.SetFloat("upgrade3C", upgrade3C);
        PlayerPrefs.SetFloat("upgrade3A", upgrade3A);
        PlayerPrefs.SetFloat("upgrade3Cost", upgrade3Cost);

        PlayerPrefs.SetFloat("upgrade4E", upgrade4E);
        PlayerPrefs.SetFloat("upgrade4F", upgrade4F);
        PlayerPrefs.SetFloat("upgrade4I", upgrade4Infamy);
        PlayerPrefs.SetFloat("upgrade4L", upgrade4L);
        PlayerPrefs.SetFloat("upgrade4C", upgrade4C);
        PlayerPrefs.SetFloat("upgrade4A", upgrade4A);
        PlayerPrefs.SetFloat("upgrade4Cost", upgrade4Cost);

        PlayerPrefs.SetFloat("upgrade5E", upgrade5E);
        PlayerPrefs.SetFloat("upgrade5F", upgrade5F);
        PlayerPrefs.SetFloat("upgrade5I", upgrade5Infamy);
        PlayerPrefs.SetFloat("upgrade5L", upgrade5L);
        PlayerPrefs.SetFloat("upgrade5C", upgrade5C);
        PlayerPrefs.SetFloat("upgrade5A", upgrade5A);
        PlayerPrefs.SetFloat("upgrade5Cost", upgrade5Cost);

        PlayerPrefs.SetFloat("upgrade6E", upgrade6E);
        PlayerPrefs.SetFloat("upgrade6F", upgrade6F);
        PlayerPrefs.SetFloat("upgrade6I", upgrade6Infamy);
        PlayerPrefs.SetFloat("upgrade6L", upgrade6L);
        PlayerPrefs.SetFloat("upgrade6C", upgrade6C);
        PlayerPrefs.SetFloat("upgrade6A", upgrade6A);
        PlayerPrefs.SetFloat("upgrade6Cost", upgrade6Cost);

    }

    void LoadGame()
    {
        influenceCount = PlayerPrefs.GetFloat("Influence");
        infamyCount = PlayerPrefs.GetFloat("Infamy");
        cultistsCount = PlayerPrefs.GetFloat("Cultists");

        if (PlayerPrefs.GetInt("Win1") == 1)
        {
            winGame = true;
        }
        else
        {
            {
                winGame = false;
            }
        }
        if (PlayerPrefs.GetInt("Win2") == 1)
        {
            winGame2 = true;
        }
        else
        {
            {
                winGame2 = false;
            }
        }
        if (PlayerPrefs.GetInt("Win3") == 1)
        {
            winGame3 = true;
        }
        else
        {
            {
                winGame3 = false;
            }
        }

        upgrade1Count = PlayerPrefs.GetFloat("upgrade1Count");
        if (PlayerPrefs.GetFloat("upgrade1Cost") != 0)
        {
            upgrade1Cost = PlayerPrefs.GetFloat("upgrade1Cost");
        }
        clickMult = PlayerPrefs.GetFloat("clickMult");

        upgrade2E = PlayerPrefs.GetFloat("upgrade2E");
        upgrade2F = PlayerPrefs.GetFloat("upgrade2F");
        upgrade2Infamy = PlayerPrefs.GetFloat("upgrade2I");
        upgrade2L = PlayerPrefs.GetFloat("upgrade2L");
        upgrade2C = PlayerPrefs.GetFloat("upgrade2C");
        upgrade2A = PlayerPrefs.GetFloat("upgrade2A");
        if (PlayerPrefs.GetFloat("upgrade2Cost") != 0)
        {
            upgrade2Cost = PlayerPrefs.GetFloat("upgrade2Cost");
        }

        upgrade3E = PlayerPrefs.GetFloat("upgrade3E");
        upgrade3F = PlayerPrefs.GetFloat("upgrade3F");
        upgrade3Infamy = PlayerPrefs.GetFloat("upgrade3I");
        upgrade3L = PlayerPrefs.GetFloat("upgrade3L");
        upgrade3C = PlayerPrefs.GetFloat("upgrade3C");
        upgrade3A = PlayerPrefs.GetFloat("upgrade3A");
        if (PlayerPrefs.GetFloat("upgrade3Cost") != 0)
        {
            upgrade3Cost = PlayerPrefs.GetFloat("upgrade3Cost");
        }

        upgrade4E = PlayerPrefs.GetFloat("upgrade4E");
        upgrade4F = PlayerPrefs.GetFloat("upgrade4F");
        upgrade4Infamy = PlayerPrefs.GetFloat("upgrade4I");
        upgrade4L = PlayerPrefs.GetFloat("upgrade4L");
        upgrade4C = PlayerPrefs.GetFloat("upgrade4C");
        upgrade4A = PlayerPrefs.GetFloat("upgrade4A");
        if (PlayerPrefs.GetFloat("upgrade4Cost") != 0)
        {
            upgrade4Cost = PlayerPrefs.GetFloat("upgrade4Cost");
        }

        upgrade5E = PlayerPrefs.GetFloat("upgrade5E");
        upgrade5F = PlayerPrefs.GetFloat("upgrade5F");
        upgrade5Infamy = PlayerPrefs.GetFloat("upgrade5I");
        upgrade5L = PlayerPrefs.GetFloat("upgrade5L");
        upgrade5C = PlayerPrefs.GetFloat("upgrade5C");
        upgrade5A = PlayerPrefs.GetFloat("upgrade5A");
        if (PlayerPrefs.GetFloat("upgrade5Cost") != 0)
        {
            upgrade5Cost = PlayerPrefs.GetFloat("upgrade5Cost");
        }

        upgrade6E = PlayerPrefs.GetFloat("upgrade6E");
        upgrade6F = PlayerPrefs.GetFloat("upgrade6F");
        upgrade6Infamy = PlayerPrefs.GetFloat("upgrade6I");
        upgrade6L = PlayerPrefs.GetFloat("upgrade6L");
        upgrade6C = PlayerPrefs.GetFloat("upgrade6C");
        upgrade6A = PlayerPrefs.GetFloat("upgrade6A");
        if (PlayerPrefs.GetFloat("upgrade6Cost") != 0)
        {
            upgrade6Cost = PlayerPrefs.GetFloat("upgrade6Cost");
        }

        countTxt.text = influenceCount.ToString();
        infamyCountTxt.text = infamyCount.ToString();
        cultistsCountTxt.text += cultistsCount.ToString();

        upgrade6Txt.text = ("Cost: " + upgrade6Cost + ", Upgrades: " + upgrade6E + ", Influence: " + upgrade6F + ", Infamy: " + upgrade6Infamy).ToString();
        upgrade5Txt.text = ("Cost: " + upgrade5Cost + ", Upgrades: " + upgrade5E + ", Influence: " + upgrade5F + ", Infamy: " + upgrade5Infamy).ToString();
        upgrade4Txt.text = ("Cost: " + upgrade4Cost + ", Upgrades: " + upgrade4E + ", Influence: " + upgrade4F + ", Infamy: " + upgrade4Infamy).ToString();
        upgrade3Txt.text = ("Cost: " + upgrade3Cost + ", Upgrades: " + upgrade3E + ", Influence: " + upgrade3F + ", Infamy: " + upgrade3Infamy).ToString();
        upgrade2Txt.text = ("Cost: " + upgrade2Cost + ", Upgrades: " + upgrade2E + ", Influence: " + upgrade2F + ", Infamy: " + upgrade2Infamy).ToString();
        upgrade1Txt.text = ("Cost: " + upgrade1Cost + ", Upgrades: " + upgrade1Count + ", Mult: " + clickMult).ToString();

        onClickTxt.text = ("On click: " + ((1 + clickMult) / (1 + (infamyCount / 10)))).ToString();
    }
}
