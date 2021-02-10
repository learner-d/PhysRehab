using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PhysRehab.UI.CollectorGame;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace PhysRehab.UI
{
    public class CollectorUIHud : VisibleBase
    {
        public static CollectorUIHud Instance { get; protected set; }

        [SerializeField]
        private ScoreCounter _scoreCounter;
        public ScoreCounter ScoreCounter => _scoreCounter;

        protected override void Awake()
        {
            base.Awake();
            Instance = this;
        }

        public void Btn_Menu_CLick()
        {
            Program.GoToMainMenu();
        }
    }
}