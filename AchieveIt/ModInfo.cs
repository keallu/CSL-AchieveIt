using Harmony;
using ICities;
using System.Reflection;

namespace AchieveIt
{
    public class ModInfo : IUserMod
    {
        private readonly string _harmonyId = "com.github.keallu.csl.achieveit";

        public string Name => "Achieve It!";
        public string Description => "Enables achievements while also playing with mods.";

        public HarmonyInstance Harmony;

        public void OnEnabled()
        {
            Harmony = HarmonyInstance.Create(_harmonyId);

            if (Harmony != null)
            {
                Harmony.PatchAll(Assembly.GetExecutingAssembly());
            }

            ModConfig.Instance.Enabled = true;
        }

        public void OnDisabled()
        {
            if (Harmony != null)
            {
                Harmony.UnpatchAll(_harmonyId);
                Harmony = null;
            }

            ModConfig.Instance.Enabled = false;
        }

        public void OnSettingsUI(UIHelperBase helper)
        {
            UIHelperBase group = helper.AddGroup(Name);

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