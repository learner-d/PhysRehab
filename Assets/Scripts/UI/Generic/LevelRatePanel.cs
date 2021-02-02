using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways]
public class LevelRatePanel : MonoBehaviour
{
    [SerializeField]
    private Sprite _inactiveStarSprite;
    [SerializeField]
    private Sprite _activeStarSprite;

    private Image[] _stars;

    [SerializeField]
    [Range(0, 3)]
    private int _levelRate;

    [SerializeField]
    [Range(0, 100)]
    private int _percent;


    private void Awake()
    {
        _stars = new Image[3];
        _stars[0] = transform.Find("Star1").GetComponent<Image>();
        _stars[1] = transform.Find("Star2").GetComponent<Image>();
        _stars[2] = transform.Find("Star3").GetComponent<Image>();
    }

    private void Update()
    {
        _levelRate = FromPercent(_percent);

        for (int i = 0; i < 3; i++)
        {
            if (i < _levelRate)
                _stars[i].sprite = _activeStarSprite;
            else
                _stars[i].sprite = _inactiveStarSprite;
        }
    }

    private int FromPercent(int percent)
    {
        Debug.Assert(percent >= 0 && percent <= 100);

        if (percent >= 0 && percent < 33)
            return 0;
        else if (percent >= 33 && percent < 66)
            return 1;
        else if (percent >= 66 && percent < 90)
            return 2;
        else if (percent >= 90)
            return 3;

        return 0;
    } 
    
}
