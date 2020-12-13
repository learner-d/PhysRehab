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
    private Text _levelCompletePanel_InfoText;

    public void SetScoreCounterValue(int value)
    {
        _uiScoreCounter_text.text = $"Рахунок: {value}";
    }

    private void SetupStartLevelPanel(int levelIndex, int coinsCount)
    {
        _startLevelPanel_CaptionText.text = $"Рівень {levelIndex}";
        _startLevelPanel_ObjectiveText.text = $"Зберіть {coinsCount} монет.";
    }

    public void ShowStartLevelPanel()
    {
        _screenFader.SetActive(true);
        _startLevelPanel.SetActive(true);
    }

    public void HideStartLevelPanel()
    {
        _startLevelPanel.SetActive(false);
        _screenFader.SetActive(false);
    }

    public void ShowMainHud()
    {
        _mainHud.SetActive(true);
    }

    public void HideMainHud()
    {
        _mainHud.SetActive(false);
    }

    private void SetupLeveCompletePanel(int levelIndex, int pickupCount, int collectedCount, int score)
    {
        _levelCompletePanel_CaptionText.text = $"Рівень {levelIndex} пройдено!";
        _levelCompletePanel_InfoText.text = $"Рахунок: {score}\nЗібрано {collectedCount}/{pickupCount}";
    }
    public void ShowLevelCompletePanel()
    {
        _screenFader.SetActive(true);
        _levelCompletePanel.SetActive(true);
    }
    public void HideLevelCompletePanel()
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
        SetupLeveCompletePanel(1,
            GoodsCollectorScene.PickupSpawner.TotalPickupsCount, 
            GoodsCollectorScene.PickupSpawner.CollectedPickupsCount,
            GoodsCollectorScene.ScoreCounter.Score);
        ShowLevelCompletePanel();
    }

    private void SetupUiObjects()
    {
        _startLevelPanel_CaptionText = _startLevelPanel.transform.Find("LevelCaptionText").GetComponent<Text>();
        _startLevelPanel_ObjectiveText = _startLevelPanel.transform.Find("LevelObjectiveText").GetComponent<Text>();
        _uiScoreCounter_text = _mainHud.transform.Find("ScoreCounterText").GetComponent<Text>();
        _levelCompletePanel_CaptionText = _levelCompletePanel.transform.Find("LevelCaptionText").GetComponent<Text>();
        _levelCompletePanel_InfoText = _levelCompletePanel.transform.Find("InfoText").GetComponent<Text>();
    }

    private void SetupUiEvents()
    {
        GoodsCollectorScene.Gameplay.LevelLoaded += OnLevelLoaded;
        GoodsCollectorScene.Gameplay.LevelStarted += OnLevelStarted;
        GoodsCollectorScene.Gameplay.LevelPassed += OnLevelPassed; 
    }

    private void Start()
    {
        SetupUiEvents();
    }

    private void Awake()
    {
        SetupUiObjects();
    }
    private void OnDestroy()
    {
        GoodsCollectorScene.Gameplay.LevelLoaded -= OnLevelLoaded;
        GoodsCollectorScene.Gameplay.LevelStarted -= OnLevelStarted;
        GoodsCollectorScene.Gameplay.LevelPassed -= OnLevelPassed;
    }
}
