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
    [SerializeField] private int levelsCount;
    [SerializeField] private GameObject levelsListHolder;
    [SerializeField] private GameObject startLevelButton;



    private void Awake()
    {
        LoadLevelsList();
    }

    private void ClearLevelsList()
    {
        while (levelsListHolder.transform.childCount > 0)
        {
            DestroyImmediate(levelsListHolder.transform.GetChild(0).gameObject);
            
            var b = false;
            if(b) break;
        }
    }

    private void LoadLevelsList()
    {
        ClearLevelsList();
        for (int i = 0; i < levelsCount; i++)
        {
            AddLevelLauncher(i);
        }
    }

    private void AddLevelLauncher(int levelIndex)
    {
        GameObject levelLauncher = Instantiate(startLevelButton, levelsListHolder.transform);
        levelLauncher.transform.Find("LevelNumText").GetComponent<Text>().text = $"{levelIndex + 1}";
    }

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
