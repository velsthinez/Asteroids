using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScorePanel : MonoBehaviour
{
    public int Score = 0;
    public TMP_Text Text;

    public void UpdateScore(int score)
    {
        Score += score;
        Text.text = Score.ToString();
    }
}
