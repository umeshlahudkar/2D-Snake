using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpecialPowerDisplay : MonoBehaviour
{
    TextMeshProUGUI Scoredisplay;
    [SerializeField] GameObject ShieldDisplay;
    TextMeshProUGUI shieldDisplay;

    private void Start()
    {
        Scoredisplay = gameObject.GetComponent<TextMeshProUGUI>();
        shieldDisplay = ShieldDisplay.GetComponent<TextMeshProUGUI>();
        ScoreEmptyDisplay();
        ShieldEmptyDisplay();
    }

    public void ScoreBoosterPower(int time)
    {
        Scoredisplay.text = "ScoreBooster Active :" + time;
    }

    public void ShieldPower(int time)
    {
        shieldDisplay.text = "Shield Active :" + time;
    }

    public void ScoreEmptyDisplay()
    {
        Scoredisplay.text = " ";
    }
    public void ShieldEmptyDisplay()
    {
        shieldDisplay.text = " ";
    }
}
