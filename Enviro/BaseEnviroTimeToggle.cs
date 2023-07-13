using MultiplayerARPG;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runningbird.Scripts
{
    public class BaseEnviroTimeToggle : MonoBehaviour
    {
        public float MorningStartingHour = 6;
        public float EveningStartingHour = 18;
        public bool _isDayTime;
        public float _timeOfDay;

        // Update is called once per frame
        public virtual void Update()
        {
            _timeOfDay = GameInstance.Singleton.DayNightTimeUpdater.TimeOfDay;
        }

        public bool IsDayTime()
        {

            //Evening
            if (_timeOfDay >= EveningStartingHour || _timeOfDay <= MorningStartingHour)
            {
                _isDayTime = false;
            }
            else //Daytime
            {
                _isDayTime = true;
            }
            return _isDayTime;
        }
    }
}
