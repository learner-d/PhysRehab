using System.Collections;
using System.Collections.Generic;
using PhysRehab.UI;
using UnityEngine;

//TODO: remove this script
public class ScoreCounter_old : MonoBehaviour
{
    private int Score_fld;
    public int Score
    {
        get => Score_fld; 
        private set
        {
            Score_fld = value;
           CollectorUI.Instance.HUD.ScoreCounter.Score = value;
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
