using ColossalFramework;
using ColossalFramework.Globalization;
using ColossalFramework.Plugins;
using ColossalFramework.UI;
using Harmony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using UnityEngine;

namespace AchieveIt
{
    [HarmonyPatch(typeof(LoadPanel), "OnListingSelectionChanged")]
    public static class LoadPanelPatch
    {
        static void Postfix(UIComponent comp, int sel)
        {
            try
            {
                if (ModConfig.Instance.Enabled)
                {
                    UISprite m_AchNope = comp.parent.Find<UISprite>("AchNope");
                    UIComponent m_Ach = comp.parent.Find("Ach");
                    UIComponent m_AchAvLabel = comp.parent.Find("AchAvLabel");
                                
                    m_AchNope.isVisible = false;
                    string tooltip = string.Empty;

                    tooltip = Locale.Get("LOADPANEL_ACHSTATUS_ENABLED");
                    tooltip += "<color #50869a>";
                    if (Singleton<PluginManager>.instance.enabledModCountNoOverride > 0)
                    {
                        tooltip += Environment.NewLine;
                        tooltip += LocaleFormatter.FormatGeneric("LOADPANEL_ACHSTATUS_MODSACTIVE", Singleton<PluginManager>.instance.enabledModCount);
                    }
                    tooltip += "</color>";

                    m_Ach.tooltip = tooltip;
                    m_AchAvLabel.tooltip = tooltip;
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Achieve It!] LoadPanelPatch:Postfix -> Exception: " + e.Message);
            }
        }
    }

    [HarmonyPatch(typeof(UnlockingPanel), "MilestoneUpdated")]
    public static class UnlockingPanelPatch
    {
        static void Postfix()
        {
            try
            {
                if (ModConfig.Instance.Enabled)
                {
                    UIButton button = GameObject.Find("Achievements").GetComponent<UIButton>();
                    button.isEnabled = true;
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Achieve It!] UnlockingPanelPatch:Postfix -> Exception: " + e.Message);
            }
        }
    }
}
