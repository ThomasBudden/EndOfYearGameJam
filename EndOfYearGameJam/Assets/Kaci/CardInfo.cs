using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CardInfo : MonoBehaviour
{
    [SerializeField] private GameObject infoPanel;
    [SerializeField] private string infoText;
    [SerializeField] private GameObject thisCardImage;
    [SerializeField] private TMP_Text infotxt;

    [SerializeField] private GameObject upgradeBtn;
    [SerializeField] private GameObject sacraficeBtn;
    [SerializeField] private GameObject upgradeTxt;


    public void OnClick()
    {
        infoPanel.SetActive(true);
        infotxt.text = infoText;
        thisCardImage.SetActive(true);
        upgradeBtn.SetActive(true);
        sacraficeBtn.SetActive(true);
        upgradeTxt.SetActive(true);
    }
}
