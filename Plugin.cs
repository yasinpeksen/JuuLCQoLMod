using BepInEx;
using HarmonyLib;
using JuuQoLMod.Patches;
using System.Reflection;

namespace JuuQoLMod
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class JuuQoLModBase : BaseUnityPlugin
    {
        private static JuuQoLModBase Instance;

        private readonly Harmony harmony = new Harmony(PluginInfo.PLUGIN_GUID);

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = new JuuQoLModBase();
            }

            // Log
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");

            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}
