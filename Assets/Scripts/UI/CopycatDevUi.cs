using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PhysRehab.Copycat;
using PhysRehab.Copycat.UI;
using PhysRehab.Core;
using PhysRehab.UI;
using PhysRehab.UI.CopycatGame;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace PhysRehab.UI
{
    public class CopycatDevUi : VisibleBase
    {
        public static CopycatDevUi Instance { get; protected set; }

        public PoseCapturerUI CapturerUI { get; private set; }
        public MultiCapturingUI MultiCapturingUI { get; private set; }
        
        protected override void Awake()
        {
            base.Awake();
            CapturerUI = GetComponentInChildren<PoseCapturerUI>();
            MultiCapturingUI = GetComponentInChildren<MultiCapturingUI>();

            Instance = this;
        }

        public void Initialize()
        {
            CapturerUI.Initialize();
            MultiCapturingUI.Initialize();

            PosePlayback.Instance.PlaybackStarted += OnPlaybackStarted;
            PosePlayback.Instance.PlaybackPaused += OnPlaybackPaused;
            PosePlayback.Instance.PlaybackResumed += OnPlaybackResumed;
            PosePlayback.Instance.PlaybackFinished += OnPlaybackFinished;
        }

        private void OnPlaybackStarted()
        {
            Hide();
        }

        private void OnPlaybackPaused()
        {
        }

        private void OnPlaybackResumed()
        {
        }

        //TODO: showing capturing ui is unnecessary
        private void OnPlaybackFinished()
        {
            Show();
        }

        public void Shutdown()
        {
            CapturerUI.Shutdown();
            MultiCapturingUI.Shutdown();
        }

        protected override void UpdateVisibility()
        {
            base.UpdateVisibility();
            CapturerUI.Visible = _visible;
            if (_visible == false)
            {
                Dialogs.Instance.PoseSavingPanel.Hide();
                Dialogs.Instance.MultiCapturePanel.Hide();

                MultiCapturingUI.Hide();
            }
        }
    } 
}
