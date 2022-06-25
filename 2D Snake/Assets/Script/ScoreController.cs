using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    TextMeshProUGUI scoreText;
    static public int score = 0;

    private void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        ScoreDisplay("");
    }

    public void ScoreIncrement(int Score , string Player)
    {
        score += Score;
        ScoreDisplay(Player);
    }

    public void ScoreDisplay(string Player)
    {
        scoreText.text = Player+ "_Score : " + score;
    }
}

