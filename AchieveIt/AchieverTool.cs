using ColossalFramework;
using ColossalFramework.UI;
using System;
using UnityEngine;

namespace AchieveIt
{
    class AchieverTool : MonoBehaviour
    {
        private bool _initialized;

        private void Awake()
        {
            try
            {

            }
            catch (Exception e)
            {
                Debug.Log("[Achieve It!] AchieverTool:Awake -> Exception: " + e.Message);
            }
        }

        private void OnEnable()
        {
            try
            {

            }
            catch (Exception e)
            {
                Debug.Log("[Achieve It!] AchieverTool:OnEnable -> Exception: " + e.Message);
            }
        }

        private void Start()
        {
            try
            {
                
            }
            catch (Exception e)
            {
                Debug.Log("[Achieve It!] AchieverTool:Start -> Exception: " + e.Message);
            }
        }

        private void Update()
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
                Debug.Log("[Achieve It!] AchieverTool:Update -> Exception: " + e.Message);
            }
        }

        private void OnDisable()
        {
            try
            {

            }
            catch (Exception e)
            {
                Debug.Log("[Achieve It!] AchieverTool:OnDisable -> Exception: " + e.Message);
            }
        }

        private void OnDestroy()
        {
            try
            {

            }
            catch (Exception e)
            {
                Debug.Log("[Achieve It!] AchieverTool:OnDestroy -> Exception: " + e.Message);
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
                Debug.Log("[Achieve It!] AchieverTool:ToggleAchievements -> Exception: " + e.Message);
            }
        }
    }
}
