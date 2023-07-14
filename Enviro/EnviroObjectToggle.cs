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

        private MeshRenderer _meshRenderer;

        private void Start()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
        }

        // Update is called once per frame
        void Update()
        {
            
            if (IsNight())
            {
                //Enable the MeshRenderer if it's night time and the _NightTimeEnabled property has been set to true
                _meshRenderer.enabled = _NightTimeEnabled;
            }
            else 
            {
                //Enable the MeshRenderer if it's Day time and the _DayTimeEnabled property has been set to true
                _meshRenderer.enabled = _DayTimeEnabled;
                
            }
            
        }

    }
}