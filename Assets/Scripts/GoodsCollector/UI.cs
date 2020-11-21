using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField]
    private GameObject _screenFader;
    [SerializeField]
    private GameObject _mainHud;
    [SerializeField]
    private GameObject _startLevelPanel;
    [SerializeField]
    private GameObject _levelCompletePanel;

    private Text _startLevelPanel_CaptionText;
    private Text _startLevelPanel_ObjectiveText;
    private Text _uiScoreCounter_text;
    private Text _levelCompletePanel_CaptionText;

    public void SetScoreCounterValue(int value)
    {
        _uiScoreCounter_text.text = $"Рахунок: {value}";
    }

    private void SetupStartLevelPanel(int levelIndex, int coinsCount)
    {
        _startLevelPanel_CaptionText.text = $"Рівень {levelIndex}";
        _startLevelPanel_ObjectiveText.text = $"Зберіть {coinsCount} монет.";
    }

    private void ShowStartLevelPanel()
    {
        _screenFader.SetActive(true);
        _startLevelPanel.SetActive(true);
    }

    private void HideStartLevelPanel()
    {
        _startLevelPanel.SetActive(false);
        _screenFader.SetActive(false);
    }

    private void ShowMainHud()
    {
        _mainHud.SetActive(true);
    }

    private void HideMainHud()
    {
        _mainHud.SetActive(false);
    }

    private void SetupLeveCompletePanel(int levelIndex)
    {
        _levelCompletePanel_CaptionText.text = $"Рівень {levelIndex} пройдено!";
    }
    private void ShowLevelCompletePanel()
    {
        _screenFader.SetActive(true);
        _levelCompletePanel.SetActive(true);
    }
    private void HideLevelCompletePanel()
    {
        _levelCompletePanel.SetActive(false);
        _screenFader.SetActive(false);
    }

    private void OnLevelLoaded()
    {
        HideMainHud();
        HideLevelCompletePanel();
        SetupStartLevelPanel(1, 10);
        ShowStartLevelPanel();
    }

    private void OnLevelStarted()
    {
        HideStartLevelPanel();
        ShowMainHud();
    }

    private void OnLevelPassed()
    {
        HideMainHud();
        SetupLeveCompletePanel(1);
        ShowLevelCompletePanel();
    }

    private void SetupUiObjects()
    {
        _startLevelPanel_CaptionText = _startLevelPanel.transform.Find("LevelCaptionText").GetComponent<Text>();
        _startLevelPanel_ObjectiveText = _startLevelPanel.transform.Find("LevelObjectiveText").GetComponent<Text>();
        _uiScoreCounter_text = _mainHud.transform.Find("ScoreCounterText").GetComponent<Text>();
        _levelCompletePanel_CaptionText = _levelCompletePanel.transform.Find("LevelCaptionText").GetComponent<Text>();
    }

    private void SetupUiEvents()
    {
        Utils.Gameplay.LevelLoaded += OnLevelLoaded;
        Utils.Gameplay.LevelStarted += OnLevelStarted;
        Utils.Gameplay.LevelPassed += OnLevelPassed;
    }


    private void Awake()
    {
        SetupUiObjects();
        SetupUiEvents();
    }

    private void OnDestroy()
    {
        Utils.Gameplay.LevelLoaded -= OnLevelLoaded;
        Utils.Gameplay.LevelStarted -= OnLevelStarted;
        Utils.Gameplay.LevelPassed -= OnLevelPassed;
    }
}
