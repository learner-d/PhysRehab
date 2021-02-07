using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuContent;
    [SerializeField] private GameObject gameChooseMenuContent;
    [SerializeField] private GameObject aboutAppMenuContent1;
    [SerializeField] private GameObject aboutAppMenuContent2;
    [SerializeField] private GameObject aboutAppMenuContent3;
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
        aboutAppMenuContent1.SetActive(false);
        aboutAppMenuContent2.SetActive(false);
        aboutAppMenuContent3.SetActive(false);
    }
    public void ShowLevelsMenu()
    {
        gameChooseMenuContent.SetActive(false);
        mainMenuContent.SetActive(false);
        levelsMenuContent.SetActive(true);
        aboutAppMenuContent1.SetActive(false);
        aboutAppMenuContent2.SetActive(false);
        aboutAppMenuContent3.SetActive(false);
    }

    public void ShowAboutAppMenu1()
    {
        gameChooseMenuContent.SetActive(false);
        mainMenuContent.SetActive(false);
        levelsMenuContent.SetActive(false);
        aboutAppMenuContent1.SetActive(true);
        aboutAppMenuContent2.SetActive(false);
        aboutAppMenuContent3.SetActive(false);
    }

    public void ShowAboutAppMenu2()
    {
        gameChooseMenuContent.SetActive(false);
        mainMenuContent.SetActive(false);
        levelsMenuContent.SetActive(false);
        aboutAppMenuContent1.SetActive(false);
        aboutAppMenuContent2.SetActive(true);
        aboutAppMenuContent3.SetActive(false);
    }

    public void ShowAboutAppMenu3()
    {
        gameChooseMenuContent.SetActive(false);
        mainMenuContent.SetActive(false);
        levelsMenuContent.SetActive(false);
        aboutAppMenuContent3.SetActive(true);
        aboutAppMenuContent1.SetActive(false);
        aboutAppMenuContent2.SetActive(false);

    }


    public void ShowGameChooseMenu()
    {
        gameChooseMenuContent.SetActive(true);
        mainMenuContent.SetActive(false);
        levelsMenuContent.SetActive(false);
        aboutAppMenuContent1.SetActive(false);
        aboutAppMenuContent2.SetActive(false);
        aboutAppMenuContent3.SetActive(false);
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
