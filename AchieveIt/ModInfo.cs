using Harmony;
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
            var harmony = HarmonyInstance.Create("com.github.keallu.csl.achieveit");
            harmony.PatchAll(Assembly.GetExecutingAssembly());

            ModConfig.Instance.Enabled = true;
        }

        public void OnDisabled()
        {
            var harmony = HarmonyInstance.Create("com.github.keallu.csl.achieveit");
            harmony.UnpatchAll();

            ModConfig.Instance.Enabled = false;
        }

        public void OnSettingsUI(UIHelperBase helper)
        {
            UIHelperBase group = helper.AddGroup(Name);

            bool selected;
            
            selected = ModConfig.Instance.Enabled;

            group.AddCheckbox("Achievements enabled (requires reload if you are in-game)", selected, sel =>
            {
                ModConfig.Instance.Enabled = sel;
                ModConfig.Instance.Save();
            });
        }
    }
}