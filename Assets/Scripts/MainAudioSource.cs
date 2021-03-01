using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PhysRehab
{
    public class MainAudioSource : MonoBehaviour
    {
        public static MainAudioSource Instance { get; private set; }
        private AudioSource _audioSource;

        private void Awake()
        {
            Instance = this;
            _audioSource = GetComponent<AudioSource>();

            Debug.Log("Main audio source is awaken");
        }

        public void PlaySound(AudioClip audioClip)
        {
            _audioSource.PlayOneShot(audioClip);
        }

        public void OnDestroy()
        {
            Debug.LogWarning("Main audio source destroyed");
        }
    } 
}
