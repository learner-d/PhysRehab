using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoresManager : MonoBehaviour
{
    private static int Score_fld;
    public static int Score 
    {
        get => Score_fld; 
        private set
        {
            Score_fld = value;
            HUDController.SetScoreCounterValue(Score_fld);
        }
    }

    public static void AddScore(int score)
    {
        Score += score;
    }

    private void Start()
    {
        Score = 0;
    }
}
