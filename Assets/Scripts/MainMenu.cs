using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuContent;
    [SerializeField] private GameObject gameChooseMenuContent;
    [SerializeField] private GameObject InfoCanvas;
    [SerializeField] private GameObject InfoCanvas2;
    [SerializeField] private GameObject InfoCanvas3;
    [SerializeField] private GameObject Game1;
    [SerializeField] private GameObject Game2;
    [SerializeField] private GameObject Game3;
    [SerializeField] private GameObject levelsMenuContent;

    [SerializeField] private GameObject startLevelButton;


    public void ShowMainMenu()
    {
        gameChooseMenuContent.SetActive(false);
        levelsMenuContent.SetActive(false);
        mainMenuContent.SetActive(true);
        InfoCanvas.SetActive(false);
        InfoCanvas2.SetActive(false);
        InfoCanvas3.SetActive(false);
        Game1.SetActive(false);
        Game2.SetActive(false);
        Game3.SetActive(false);
    }
    public void ShowLevelsMenu()
    {
        gameChooseMenuContent.SetActive(false);
        mainMenuContent.SetActive(false);
        levelsMenuContent.SetActive(true);
        InfoCanvas.SetActive(false);
        InfoCanvas2.SetActive(false);
        InfoCanvas3.SetActive(false);
        Game1.SetActive(false);
        Game2.SetActive(false);
        Game3.SetActive(false);
    }

    public void ShowAboutAppMenu1()
    {
        gameChooseMenuContent.SetActive(false);
        mainMenuContent.SetActive(false);
        levelsMenuContent.SetActive(false);
        InfoCanvas.SetActive(true);
        InfoCanvas2.SetActive(false);
        InfoCanvas3.SetActive(false);
    }

    public void ShowAboutAppMenu2()
    {
        gameChooseMenuContent.SetActive(false);
        mainMenuContent.SetActive(false);
        levelsMenuContent.SetActive(false);
        InfoCanvas.SetActive(false);
        InfoCanvas2.SetActive(true);
        InfoCanvas3.SetActive(false);
        Game1.SetActive(false);
        Game2.SetActive(false);
        Game3.SetActive(false);
    }

    public void ShowAboutAppMenu3()
    {
        gameChooseMenuContent.SetActive(false);
        mainMenuContent.SetActive(false);
        levelsMenuContent.SetActive(false);
        InfoCanvas.SetActive(false);
        InfoCanvas2.SetActive(false);
        InfoCanvas3.SetActive(true);
        Game1.SetActive(false);
        Game2.SetActive(false);
        Game3.SetActive(false);

    }


    public void ShowGameChooseMenu()
    {
        gameChooseMenuContent.SetActive(true);
        mainMenuContent.SetActive(false);
        levelsMenuContent.SetActive(false);
        InfoCanvas.SetActive(false);
        InfoCanvas2.SetActive(false);
        InfoCanvas3.SetActive(false);
        Game1.SetActive(false);
        Game2.SetActive(false);
        Game3.SetActive(false);
    }

    public void ShowGame1()
    {
        gameChooseMenuContent.SetActive(false);
        mainMenuContent.SetActive(false);
        levelsMenuContent.SetActive(false);
        InfoCanvas.SetActive(false);
        InfoCanvas2.SetActive(false);
        InfoCanvas3.SetActive(false);
        Game1.SetActive(true);
        Game2.SetActive(false);
        Game3.SetActive(false);
    }

    public void ShowGame2()
    {
        gameChooseMenuContent.SetActive(false);
        mainMenuContent.SetActive(false);
        levelsMenuContent.SetActive(false);
        InfoCanvas.SetActive(false);
        InfoCanvas2.SetActive(false);
        InfoCanvas3.SetActive(false);
        Game1.SetActive(false);
        Game2.SetActive(true);
        Game3.SetActive(false);
    }

    public void ShowGame3()
    {
        gameChooseMenuContent.SetActive(false);
        mainMenuContent.SetActive(false);
        levelsMenuContent.SetActive(false);
        InfoCanvas.SetActive(false);
        InfoCanvas2.SetActive(false);
        InfoCanvas3.SetActive(false);
        Game1.SetActive(false);
        Game2.SetActive(false);
        Game3.SetActive(true);
    }

    public void LaunchCollectorGame()
    {
        Program.LaunchCollectorGame();
    }

    public void LaunchCopycatGame()
    {
        Program.LaunchCopycatGame();
    }

    public void LaunchFlappyBirdGame()
    {
        Program.LaunchFlappyBirdGame();
    }

    public void ExitApp()
    {
        Program.Quit();
    }
}
