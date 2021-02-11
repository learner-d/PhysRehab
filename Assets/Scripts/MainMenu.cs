using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuContent;
    [SerializeField] private GameObject gameChooseMenuContent;
    [SerializeField] private GameObject InfoCanvas;
    [SerializeField] private GameObject Info1st;
    [SerializeField] private GameObject Info2st;
    [SerializeField] private GameObject Info3st;
    [SerializeField] private GameObject GamePanel;
    [SerializeField] private GameObject Game1;
    [SerializeField] private GameObject Game2;
    [SerializeField] private GameObject Game3;

    public void ShowMainMenu()
    {
        gameChooseMenuContent.SetActive(false);
        mainMenuContent.SetActive(true);
        InfoCanvas.SetActive(false);
        Info1st.SetActive(false);
        Info2st.SetActive(false);
        Info3st.SetActive(false);
        GamePanel.SetActive(false);
        Game1.SetActive(false);
        Game2.SetActive(false);
        Game3.SetActive(false);
    }
    public void ShowLevelsMenu()
    {
        gameChooseMenuContent.SetActive(false);
        mainMenuContent.SetActive(false);
        InfoCanvas.SetActive(false);
        Info1st.SetActive(false);
        Info2st.SetActive(false);
        Info3st.SetActive(false);
        GamePanel.SetActive(false);
        Game1.SetActive(false);
        Game2.SetActive(false);
        Game3.SetActive(false);
    }

    public void ShowAboutAppMenu1()
    {
        gameChooseMenuContent.SetActive(false);
        mainMenuContent.SetActive(false);
        InfoCanvas.SetActive(true);
        Info1st.SetActive(true);
        Info2st.SetActive(false);
        Info3st.SetActive(false);
        GamePanel.SetActive(false);
        Game1.SetActive(false);
        Game2.SetActive(false);
        Game3.SetActive(false);
    }

    public void ShowAboutAppMenu2()
    {
        gameChooseMenuContent.SetActive(false);
        mainMenuContent.SetActive(false);
        InfoCanvas.SetActive(true);
        Info1st.SetActive(false);
        Info2st.SetActive(true);
        Info3st.SetActive(false);
        GamePanel.SetActive(false);
        Game1.SetActive(false);
        Game2.SetActive(false);
        Game3.SetActive(false);
    }

    public void ShowAboutAppMenu3()
    {
        gameChooseMenuContent.SetActive(false);
        mainMenuContent.SetActive(false);
        InfoCanvas.SetActive(true);
        Info1st.SetActive(false);
        Info2st.SetActive(false);
        Info3st.SetActive(true);
        GamePanel.SetActive(false);
        Game1.SetActive(false);
        Game2.SetActive(false);
        Game3.SetActive(false);

    }


    public void ShowGameChooseMenu()
    {
        gameChooseMenuContent.SetActive(true);
        mainMenuContent.SetActive(false);
        InfoCanvas.SetActive(false);
        Info1st.SetActive(false);
        Info2st.SetActive(false);
        Info3st.SetActive(false);
        GamePanel.SetActive(true);
        Game1.SetActive(false);
        Game2.SetActive(false);
        Game3.SetActive(false);
    }

    public void ShowGame1()
    {
        gameChooseMenuContent.SetActive(true);
        mainMenuContent.SetActive(false);
        InfoCanvas.SetActive(false);
        Info1st.SetActive(false);
        Info2st.SetActive(false);
        Info3st.SetActive(false);
        GamePanel.SetActive(false);
        Game1.SetActive(true);
        Game2.SetActive(false);
        Game3.SetActive(false);
    }

    public void ShowGame2()
    {
        gameChooseMenuContent.SetActive(true);
        mainMenuContent.SetActive(false);
        InfoCanvas.SetActive(false);
        Info1st.SetActive(false);
        Info2st.SetActive(false);
        Info3st.SetActive(false);
        GamePanel.SetActive(false);
        Game1.SetActive(false);
        Game2.SetActive(true);
        Game3.SetActive(false);
    }

    public void ShowGame3()
    {
        gameChooseMenuContent.SetActive(true);
        mainMenuContent.SetActive(false);
        InfoCanvas.SetActive(false);
        Info1st.SetActive(false);
        Info2st.SetActive(false);
        Info3st.SetActive(false);
        GamePanel.SetActive(false);
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
