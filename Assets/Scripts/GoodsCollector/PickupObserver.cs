using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObserver : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _normalPickupCollectSound;
    [SerializeField] private AudioClip _bigScorePickupCollectSound;

    public void Subscribe(Pickup pickup)
    {
        pickup.Collected += OnPickupCollected;
    }


    private void OnPickupCollected(Pickup pickup)
    {
        int score;
        AudioClip collectSound;
        
        if (pickup.PickupType == PickupType.Normal)
        {
            score = 10;
            collectSound = _normalPickupCollectSound;
        }
        else
        {
            score = 25;
            collectSound = _bigScorePickupCollectSound;
        }
        
        _audioSource.PlayOneShot(collectSound);
        Utils.ScoreCounter.AddScore(score);
        
        Destroy(pickup.gameObject);
        Utils.Gameplay.CheckLevelProress();
    }

    private void Awake()
    {
        if(_audioSource == null)
        {
            _audioSource = FindObjectOfType<AudioSource>();
        }
    }
}