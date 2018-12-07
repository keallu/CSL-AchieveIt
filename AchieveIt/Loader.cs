using ColossalFramework;
using ICities;
using System;
using UnityEngine;

namespace AchieveIt
{

    public class Loader : LoadingExtensionBase
    {
        private LoadMode _loadMode;

        public override void OnLevelLoaded(LoadMode mode)
        {
            try
            {
                _loadMode = mode;

                if (_loadMode != LoadMode.LoadGame && _loadMode != LoadMode.NewGame && _loadMode != LoadMode.NewGameFromScenario)
                {
                    return;
                }

                if (ModConfig.Instance.Enabled)
                {
                    Singleton<SimulationManager>.instance.m_metaData.m_disableAchievements = SimulationMetaData.MetaBool.False;
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Achieve It!] Loader:OnLevelLoaded -> Exception: " + e.Message);
            }
        }

        public override void OnLevelUnloading()
        {
            try
            {
                if (_loadMode != LoadMode.LoadGame && _loadMode != LoadMode.NewGame && _loadMode != LoadMode.NewGameFromScenario)
                {
                    return;
                }

                if (ModConfig.Instance.Enabled)
                {
                    Singleton<SimulationManager>.instance.m_metaData.m_disableAchievements = SimulationMetaData.MetaBool.True;
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Achieve It!] Loader:OnLevelUnloading -> Exception: " + e.Message);
            }
        }
    }
}