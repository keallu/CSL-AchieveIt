using ColossalFramework;
using ColossalFramework.UI;
using System;
using UnityEngine;

namespace AchieveIt
{
    class ModManager : MonoBehaviour
    {
        private bool _initialized;

        public void Update()
        {
            try
            {
                if (!_initialized || ModConfig.Instance.ConfigUpdated)
                {
                    ToggleAchievements();

                    _initialized = true;
                    ModConfig.Instance.ConfigUpdated = false;
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Achieve It!] ModManager:Update -> Exception: " + e.Message);
            }
        }

        private void ToggleAchievements()
        {
            try
            {
                if (ModConfig.Instance.Enabled)
                {
                    Singleton<SimulationManager>.instance.m_metaData.m_disableAchievements = SimulationMetaData.MetaBool.False;
                }
                else
                {
                    Singleton<SimulationManager>.instance.m_metaData.m_disableAchievements = SimulationMetaData.MetaBool.True;
                }

                UIButton button = GameObject.Find("Achievements").GetComponent<UIButton>();

                if (button != null)
                {
                    button.isEnabled = ModConfig.Instance.Enabled;
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Achieve It!] ModManager:ToggleAchievements -> Exception: " + e.Message);
            }
        }
    }
}
