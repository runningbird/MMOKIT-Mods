using MultiplayerARPG;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runningbird.Scripts
{
    public class BaseEnviroTimeToggle : MonoBehaviour
    {

        public bool _isNight;

        public bool IsNight()
        {
            _isNight = Enviro.EnviroManager.instance.isNight;

            return _isNight;
        }
    }
}
