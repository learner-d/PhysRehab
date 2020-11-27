using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuContent;
    [SerializeField] private GameObject gameChooseMenuContent;
    [SerializeField] private GameObject aboutAppMenuContent;
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
        aboutAppMenuContent.SetActive(false);
    }
    public void ShowLevelsMenu()
    {
        gameChooseMenuContent.SetActive(false);
        mainMenuContent.SetActive(false);
        levelsMenuContent.SetActive(true);
        aboutAppMenuContent.SetActive(false);
    }

    public void ShowAboutAppMenu()
    {
        gameChooseMenuContent.SetActive(false);
        mainMenuContent.SetActive(false);
        levelsMenuContent.SetActive(false);
        aboutAppMenuContent.SetActive(true);
    }

    public void ShowGameChooseMenu()
    {
        gameChooseMenuContent.SetActive(true);
        mainMenuContent.SetActive(false);
        levelsMenuContent.SetActive(false);
        aboutAppMenuContent.SetActive(false);
    }
}
