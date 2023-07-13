// Ignore Spelling: Runningbird

using MultiplayerARPG;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runningbird.Scripts
{
    public class EnviroLights : BaseEnviroTimeToggle
    {
        public Light _light;

        // Start is called before the first frame update
        void Start()
        {
            _light = GetComponent<Light>();
        }

        // Update is called once per frame
        public override void Update()
        {
            base.Update();
            
            if (_light != null)
            {
                if (IsDayTime())
                {
                    _light.enabled = false;
                }
                else
                {
                    _light.enabled = IsDayTime();
                }
            }
        }
    }
}
