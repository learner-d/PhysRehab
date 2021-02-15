using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PhysRehab.Copycat
{
    public class PosePlaybackSfx : MonoBehaviour
    {
        private AudioSource _audioSource;
        [SerializeField]
        private AudioClip _posePlaybackMusic;

        [SerializeField]
        private AudioClip _poseMatchSound;

        private PosePlayback _posePlayback;
        private PoseComparer _poseComparer;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            Debug.Assert(_audioSource != null);
            Debug.Assert(_posePlaybackMusic != null);
            _audioSource.clip = _posePlaybackMusic;

            _posePlayback = FindObjectOfType<PosePlayback>();
            Debug.Assert(_posePlayback != null);

            _poseComparer = FindObjectOfType<PoseComparer>();
            Debug.Assert(_poseComparer != null);

            Debug.Assert(_poseMatchSound != null);
        }

        private void OnEnable()
        {
            _posePlayback.PlaybackStarted += OnPlaybackStarted;
            _posePlayback.PlaybackPaused += OnPlaybackPaused;
            _posePlayback.PlaybackResumed += OnPlaybackResumed;
            _posePlayback.PlaybackFinished += OnPlaybackFinished;

            _poseComparer.PoseMatch += OnPoseMatch;
        }

        private void OnPoseMatch()
        {
            if (true)
            {

            }
        }

        private void OnDisable()
        {
            _posePlayback.PlaybackStarted -= OnPlaybackStarted;
            _posePlayback.PlaybackPaused -= OnPlaybackPaused;
            _posePlayback.PlaybackResumed -= OnPlaybackResumed;
            _posePlayback.PlaybackFinished -= OnPlaybackFinished;
        }

        private void OnPlaybackStarted()
        {
            _audioSource.Play();
        }
        private void OnPlaybackPaused()
        {
            _audioSource.Pause();
        }
        private void OnPlaybackResumed()
        {
            _audioSource.UnPause();
        }
        private void OnPlaybackFinished()
        {
            _audioSource.Stop();
        }
    } 
}
