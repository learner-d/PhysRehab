using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private int Score_fld;
    public int Score
    {
        get => Score_fld; 
        private set
        {
            Score_fld = value;
            GoodsCollectorScene.HudController.SetScoreCounterValue(Score_fld);
        }
    }

    public void AddScore(int score)
    {
        Score += score;
    }

    public void ResetScore()
    {
        Score = 0;
    }

    private void Start()
    {
        ResetScore();
    }
}
