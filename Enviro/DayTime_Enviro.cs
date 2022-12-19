using MultiplayerARPG;
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
                //Enviro 3
                Enviro.EnviroManager.instance.Time.SetTimeOfDay(GameInstance.Singleton.DayNightTimeUpdater.TimeOfDay);
                //Comment out the above line and uncomment the following if using Older Enviro Weather versions
                //EnviroSkyMgr.instance.SetTimeOfDay(GameInstance.Singleton.DayNightTimeUpdater.TimeOfDay);
            }

        }
    }
}