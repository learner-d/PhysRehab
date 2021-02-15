using PhysRehab.Scenes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PhysRehab.Collector
{
    [RequireComponent(typeof(AudioSource))]
    public class CollectorSfx : MonoBehaviour
    {
        [SerializeField] private AudioClip _normalPickupCollectSound;
        [SerializeField] private AudioClip _bigScorePickupCollectSound;


        private AudioSource _audioSource;
        private PickupObserver _pickupObserver;
        private void OnEnable()
        {
            if(_audioSource == null)
                _audioSource = GetComponent<AudioSource>();

            if(_pickupObserver == null)
            {
                _pickupObserver = FindObjectOfType<PickupObserver>();
                Debug.Assert(_pickupObserver);
            }

            _pickupObserver.PickupCollected += OnPickupCollected;
        }

        private void OnDisable()
        {
            _pickupObserver.PickupCollected -= OnPickupCollected;
        }

        private void OnPickupCollected(Pickup pickup)
        {
            AudioClip collectSound;

            if (pickup.PickupType == PickupType.Normal)
                collectSound = _normalPickupCollectSound;
            else
                collectSound = _bigScorePickupCollectSound;

            _audioSource.PlayOneShot(collectSound);
        }
    }
}
