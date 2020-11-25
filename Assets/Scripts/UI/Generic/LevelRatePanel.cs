using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways]
public class LevelRatePanel : MonoBehaviour
{
    #region Fields
    [SerializeField]
    private Sprite _inactiveStarSprite;
    [SerializeField]
    private Sprite _activeStarSprite;

    private Image[] _stars;

    [SerializeField]
    [Range(0, 3)]
    private int _levelRate;
    #endregion

    #region Methods
    private void Awake()
    {
        _stars = new Image[3];
        _stars[0] = transform.Find("Star1").GetComponent<Image>();
        _stars[1] = transform.Find("Star2").GetComponent<Image>();
        _stars[2] = transform.Find("Star3").GetComponent<Image>();
    }

    private void Update()
    {
        if (!Application.isPlaying)
        {
            for (int i = 0; i < 3; i++)
            {
                if (i < _levelRate)
                    _stars[i].sprite = _activeStarSprite;
                else
                    _stars[i].sprite = _inactiveStarSprite;
            } 
        }
    } 
    #endregion
}
