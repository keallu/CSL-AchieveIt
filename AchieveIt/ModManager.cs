using ColossalFramework;
using ColossalFramework.UI;
using System;
using UnityEngine;

namespace AchieveIt
{
    class ModManager : MonoBehaviour
    {
        private bool _initialized;

        private UnlockingPanel _unlockingPanel;
        private UITabstrip _tabstrip;
        private UIButton _achievements;

        public void Start()
        {
            try
            {
                _unlockingPanel = GameObject.Find("UnlockingPanel").GetComponent<UnlockingPanel>();
                _tabstrip = _unlockingPanel.Find("Tabstrip").GetComponent<UITabstrip>();
                _achievements = _tabstrip.Find("Achievements").GetComponent<UIButton>();
            }
            catch (Exception e)
            {
                Debug.Log("[Achieve It!] ModManager:Start -> Exception: " + e.Message);
            }
        }

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

                if (_achievements != null)
                {
                    _achievements.isEnabled = ModConfig.Instance.Enabled;
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Achieve It!] ModManager:ToggleAchievements -> Exception: " + e.Message);
            }
        }
    }
}
