using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    private static GameObject UiScoreCounter_obj = null;
    private static Text UiScoreCounter_text = null;

    public static void SetScoreCounterValue(int value)
    {
        if (UiScoreCounter_text != null)
        {
            UiScoreCounter_text.text = $"Рахунок: {value}"; 
        }
    }

    private void Awake()
    {
        UiScoreCounter_obj = GameObject.Find("UiScoreCounter");
        UiScoreCounter_text = UiScoreCounter_obj?.GetComponent<Text>();
    }
}
