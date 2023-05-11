using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScorePanel : MonoBehaviour
{
    public int Score = 0;
    public TMP_Text Text;

    public GameManager GameManager;

    private void Update()
    {
        if (GameManager.State != GameManager.GameState.Started)
        {
            UpdateScore(-Score);
            Text.gameObject.SetActive(false);
        }
        else
        {
            Text.gameObject.SetActive(true);

        }
    }
    
    public void UpdateScore(int score)
    {

        Score += score;
        Text.text = Score.ToString();
    }
}
