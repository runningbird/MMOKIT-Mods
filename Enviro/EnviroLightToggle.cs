// Ignore Spelling: Runningbird

using MultiplayerARPG;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runningbird.Scripts
{
    public class EnviroLightToggle: BaseEnviroTimeToggle
    {
        public Light _light;

        // Start is called before the first frame update
        void Start()
        {
            _light = GetComponent<Light>();
        }

        // Update is called once per frame
        void Update()
        {            
            if (_light != null)
            {
                _light.enabled = IsNight();
            }
        }
    }
}
