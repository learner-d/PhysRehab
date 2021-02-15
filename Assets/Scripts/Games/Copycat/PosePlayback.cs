using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace PhysRehab.Copycat
{
    public class PosePlayback : MonoBehaviour
    {
        public static PosePlayback Instance { get; private set; }

        public event UnityAction PlaybackStarted;
        public event UnityAction PlaybackPaused;
        public event UnityAction PlaybackResumed;
        public event UnityAction PlaybackFinished;

        private bool _isPlaying;
        public bool IsPlaying => _isPlaying;
        private bool _isPaused;
        public bool IsPaused => _isPaused;

        private void Awake()
        {
            _isPlaying = false;
            _isPaused = false;
            Instance = this;
            PlaybackFinished += OnPlaybackFinished;
        }

        private IEnumerator Play()
        {
            IReadOnlyList<PoseInfo> poses = PoseSelector.Instance.GetActivePoses();
            _isPlaying = true;
            PlaybackStarted?.Invoke();
            for (int i = 0; i < poses.Count;)
            {
                if(_isPlaying == false)
                    break;

                if (_isPaused == false)
                {
                    PoseSelector.Instance.ActivePose = poses[i];
                    yield return new WaitForSeconds(poses[i].LifetimeS);
                    i++;
                }
                else
                    yield return new WaitForEndOfFrame();
            }
            _isPlaying = false;
            PlaybackFinished?.Invoke();
        }

        private void OnPlaybackFinished()
        {
            
        }


        public void StartPlayback()
        {
            if(_isPlaying)
                throw new InvalidOperationException();

            StartCoroutine(Play());
        }
        public void Pause()
        {
            if (_isPlaying && _isPaused == false)
            {
                _isPaused = true;
                PlaybackPaused?.Invoke(); 
            }
        }
        public void Resume()
        {
            if (_isPlaying && _isPaused)
            {
                _isPaused = false; 
                PlaybackResumed?.Invoke();
            }
        }
        public void Stop()
        {
            _isPlaying = false;
        }

        public void InvertPlayback()
        {
            if(IsPlaying)
                Stop();
            else
                StartPlayback();
        }
    } 
}
