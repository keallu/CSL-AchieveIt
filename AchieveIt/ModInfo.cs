using CitiesHarmony.API;
using ICities;

namespace AchieveIt
{
    public class ModInfo : IUserMod
    {
        public string Name => "Achieve It!";
        public string Description => "Enables achievements while also playing with mods.";

        //public Harmony Harmony;

        public void OnEnabled()
        {
            //Harmony = new Harmony("com.github.keallu.csl.achieveit");

            //if (Harmony != null)
            //{
            //    Harmony.PatchAll(Assembly.GetExecutingAssembly());
            //}

            HarmonyHelper.DoOnHarmonyReady(() => Patcher.PatchAll());

            ModConfig.Instance.Enabled = true;
        }

        public void OnDisabled()
        {
            //if (Harmony != null)
            //{
            //    Harmony.UnpatchAll();
            //}

            if (HarmonyHelper.IsHarmonyInstalled)
            {
                Patcher.UnpatchAll();
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