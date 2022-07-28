using MultiplayerARPG;
using UnityEngine;

namespace Runningbird.Scripts
{
    public class MaterialSwitcher : MonoBehaviour
    {
        public Material DayTimeMaterial;
        public Material NightTimeMaterial;

        public float MorningStartingHour = 6;
        public float EveningStartingHour = 18;

        private void Update()
        {
            float timeOfDay = GameInstance.Singleton.DayNightTimeUpdater.TimeOfDay;

            if (GetComponent<Renderer>())
            {

                Material localMaterial = GetComponent<Renderer>().material;

                if (timeOfDay >= EveningStartingHour || timeOfDay <= MorningStartingHour)
                {
                    if (localMaterial != NightTimeMaterial) //checks to see if the material is already set to the Nighttime material if not then it sets it
                    {
                        GetComponent<MeshRenderer>().material = NightTimeMaterial;
                    }
                }
                else
                {
                    if (localMaterial != DayTimeMaterial) //checks to see if the material is already set to the DayTime material if not then it sets it
                    {
                        GetComponent<MeshRenderer>().material = DayTimeMaterial;
                    }
                }
            }
        }
    }
}