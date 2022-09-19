using Broccoli.Factory;
using Broccoli.Pipe;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.MMO.Scripts.Broccoli
{
    public class SeasonsManager : MonoBehaviour
    {
        private TreeFactory treeFactory;
        private Pipeline pipeline;
        public EnviroSeasons.Seasons CurrentSeason;
        public SeasonDefinition[] seasonDefinitions;
        public IEnumerable<SeasonDefinition> currentSeasonDefinition;

        //private string[] sproutMapperKeyNames = new string[] { "Autumn", "Green" };
        private List<string> sproutMapperKeyNames;
        private int sproutMapperSelected = 0;

        private void Awake()
        {
            treeFactory = GetComponent<TreeFactory>();
            pipeline = treeFactory.localPipeline;
        }

        private void Start()
        {
            CurrentSeason = EnviroSkyMgr.instance.GetCurrentSeason();
            SetSeason(CurrentSeason);

            EnviroSkyMgr.instance.OnSeasonChanged += (EnviroSeasons.Seasons season) =>
            {
                SetSeason(season);
                Debug.Log("Season changed");
            };

            
        }


        public void SetSeason(EnviroSeasons.Seasons season)
        {
            if (treeFactory)
            {
                if (pipeline != null && pipeline.IsValid())
                {
                    switch (season)
                    {
                        case EnviroSeasons.Seasons.Spring:
                            {
                                break;
                            }
                        case EnviroSeasons.Seasons.Summer:
                            {
                                break;
                            }
                        case EnviroSeasons.Seasons.Autumn:
                            {
                                break;
                            }
                        case EnviroSeasons.Seasons.Winter:
                            {
                                break;
                            }
                    }
                    SetSproutMapperKeyNames(season);
                    treeFactory.ProcessPipelinePreview(null, true);
                    CurrentSeason = EnviroSkyMgr.instance.GetCurrentSeason();
                }
            }
        }

        private void SetSproutMapperKeyNames(EnviroSeasons.Seasons newSeason)
        {
            //Get The New Season
            IEnumerable<SeasonDefinition> updatedSeason = from SeasonDefinition s in seasonDefinitions
                                                          where s.EnviroSeason == newSeason
                                                          select s;

            currentSeasonDefinition = from SeasonDefinition season in seasonDefinitions
                                      where season.EnviroSeason == CurrentSeason
                                      select season;

            if (updatedSeason.First().SproutMapperKeyName != currentSeasonDefinition.First().SproutMapperKeyName)
            {
                //Replace the CurrentSeasonDefinition with the updated one.
                pipeline.ReplaceElements(currentSeasonDefinition.First().SproutMapperKeyName, updatedSeason.First().SproutMapperKeyName);
            }
            else
            {
                //get different SproutMapperKeyName
                IEnumerable<SeasonDefinition> differentSeason = from SeasonDefinition s in seasonDefinitions
                                                                where s.SproutMapperKeyName != updatedSeason.First().SproutMapperKeyName
                                                                select s;
                pipeline.ReplaceElements(differentSeason.First().SproutMapperKeyName, updatedSeason.First().SproutMapperKeyName);
            }
            //Set the CurrentSeadonDefinition to the updated
            currentSeasonDefinition = updatedSeason;
        }
    }
}