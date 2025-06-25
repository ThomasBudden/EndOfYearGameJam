using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CardInfo : MonoBehaviour
{
    [SerializeField] private string infoText;
    [SerializeField] private Image thisCardImage;

    [SerializeField] private TMP_Text infotxt;
    [SerializeField] private Image cardImage;

    void OnClick()
    {
        infotxt.text = infoText;
        cardImage = thisCardImage;
    }
}
