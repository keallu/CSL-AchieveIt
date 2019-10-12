using ColossalFramework.UI;
using ICities;
using System;
using UnityEngine;

namespace AchieveIt
{

    public class Loading : LoadingExtensionBase
    {
        private GameObject _modManagerGameObject;

        public override void OnLevelLoaded(LoadMode mode)
        {
            try
            {
                try
                {
                    _modManagerGameObject = new GameObject("AchieveItModManager");
                    _modManagerGameObject.AddComponent<ModManager>();
                }
                catch (Exception e)
                {
                    Debug.Log("[Monitor It!] Loading:OnLevelLoaded -> Exception: " + e.Message);
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
                if (_modManagerGameObject != null)
                {
                    UnityEngine.Object.Destroy(_modManagerGameObject);
                }
            }
            catch (Exception e)
            {
                Debug.Log("[Achieve It!] Loader:OnLevelUnloading -> Exception: " + e.Message);
            }
        }
    }
}