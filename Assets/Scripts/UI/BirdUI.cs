using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PhysRehab.Bird;
using PhysRehab.Bird.UI;
using PhysRehab.Core;
using PhysRehab.UI;
using PhysRehab.UI.BirdGame;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace PhysRehab.UI
{
    public class BirdUI : VisibleBase
    {
   

        protected override void Awake()
        {
            base.Awake();
           
        }

        public void Initialize()
        {
         
        }

        public void Shutdown()
        {
          
        }


        protected override void UpdateVisibility()
        {
            base.UpdateVisibility();
            if (_visible == false)
            {
             
            }
        }
    }
}
