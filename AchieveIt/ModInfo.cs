using CitiesHarmony.API;
using ICities;
using System.Reflection;

namespace AchieveIt
{
    public class ModInfo : IUserMod
    {
        public string Name => "Achieve It!";
        public string Description => "Enables achievements while also playing with mods.";        

        public void OnEnabled()
        {
            HarmonyHelper.DoOnHarmonyReady(() => Patcher.PatchAll());

            ModConfig.Instance.Enabled = true;
        }

        public void OnDisabled()
        {
            if (HarmonyHelper.IsHarmonyInstalled)
            {
                Patcher.UnpatchAll();
            }

            ModConfig.Instance.Enabled = false;
        }

        public void OnSettingsUI(UIHelperBase helper)
        {
            UIHelperBase group;

            AssemblyName assemblyName = Assembly.GetExecutingAssembly().GetName();

            group = helper.AddGroup(Name + " - " + assemblyName.Version.Major + "." + assemblyName.Version.Minor);

            bool selected;
            
            selected = ModConfig.Instance.Enabled;
            group.AddCheckbox("Achievements enabled", selected, sel =>
            {
                ModConfig.Instance.Enabled = sel;
                ModConfig.Instance.Save();
            });
        }
    }
}