#if BIE
using System.Reflection;
using BepInEx;
using BepInEx.Logging;
using BepInEx.Unity.IL2CPP;
using UnityEngine;
using UniversalBasePlugin.Loader.Common;
using UniversalBasePlugin.Loader.Common.Configuration;

namespace UniversalBasePlugin.Loader.BepInEx
{
    [BepInPlugin(UPlugin.GUID, UPlugin.NAME, UPlugin.VERSION)]
    public class UniversalBepInPlugin : BasePlugin, ILoader
    {
        private static readonly HarmonyLib.Harmony s_harmony = new(UPlugin.GUID);

        public ManualLogSource LogSource => Log;

        public HarmonyLib.Harmony HarmonyInstance => s_harmony;
        public ELoaderType LoaderType => ELoaderType.BepInEx;

        public ConfigHandler ConfigHandler => _configHandler;

        public Action<object> OnLogMessage => LogSource.LogMessage;
        public Action<object> OnLogWarning => LogSource.LogWarning;
        public Action<object> OnLogError => LogSource.LogError;

        public override void Load()
        {
            ULogger.CreateLogger(this);
            if (UPlugin.USE_CONFIG)
            {
                _configHandler = new BepInExConfigHandler(Config);
                ConfigManager.Init(_configHandler);    
            }
            var plugin = new UPlugin(this);
            HarmonyInstance.PatchAll(Assembly.GetExecutingAssembly());
        }

        private BepInExConfigHandler _configHandler;
    }
}
#endif