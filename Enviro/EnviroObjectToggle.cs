using MultiplayerARPG;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Runningbird.Scripts
{
    public class EnviroObjectToggle : BaseEnviroTimeToggle
    {
        public bool _DayTimeEnabled;
        public bool _NightTimeEnabled;
        // Update is called once per frame
        public override void Update()
        {
            base.Update();
            if (IsNight())
            {
                gameObject.SetActive(_NightTimeEnabled);
            }
            else 
            {
                gameObject.SetActive(_DayTimeEnabled);
                
            }
            
        }

    }
}