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


    public void OnClick()
    {
        infoPanel.SetActive(true);
        infotxt.text = infoText;
        thisCardImage.SetActive(true);
    }
}
