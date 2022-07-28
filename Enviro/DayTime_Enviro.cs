using MultiplayerARPG;
using System.Collections;
using UnityEngine;

namespace Runningbird.Scripts
{
    public class DayTime_Enviro : MonoBehaviour
    {
        private void Update()
        {
            // Update time of day percent while network active only
            if (Application.isPlaying && BaseGameNetworkManager.Singleton.IsNetworkActive)
            {
                EnviroSkyMgr.instance.SetTimeOfDay(GameInstance.Singleton.DayNightTimeUpdater.TimeOfDay);
            }

        }
    }
}