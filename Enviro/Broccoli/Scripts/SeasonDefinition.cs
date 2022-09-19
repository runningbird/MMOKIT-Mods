using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.MMO.Scripts.Broccoli
{
    [CreateAssetMenu(fileName = "BroccoliEnviroSeasonDefinition", menuName = "RunningbirdStudios/Enviro/Brocolli/SeasonDefinition", order = 1)]
    public class SeasonDefinition : ScriptableObject
    {
        public EnviroSeasons.Seasons EnviroSeason;
        public string SproutMapperKeyName;

    }
}
