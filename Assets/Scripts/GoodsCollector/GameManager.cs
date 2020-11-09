using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool GameIsPaused { get; private set; }
    public void PauseGame()
    {
        GameIsPaused = true;
    }
    public void ResumeGame()
    {
        GameIsPaused = false;
    }
}
