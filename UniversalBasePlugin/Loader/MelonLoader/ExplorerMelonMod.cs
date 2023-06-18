#if ML
using MelonLoader;
using UniversalBasePlugin;
using UniversalBasePlugin.Loader.Common;
using UniversalBasePlugin.Loader.Common.Configuration;
using UniversalBasePlugin.Loader.MelonLoader;

[assembly: MelonInfo(typeof(UniversalMelonMod), UPlugin.NAME, UPlugin.VERSION, UPlugin.AUTHOR)]
[assembly: MelonGame]
[assembly: MelonColor(255, UPlugin.CONSOLE_R, UPlugin.CONSOLE_G, UPlugin.CONSOLE_B)]

namespace UniversalBasePlugin.Loader.MelonLoader
{
    public class UniversalMelonMod : MelonMod, ILoader
    {
        public MelonLoaderConfigHandler _configHandler;
        public ELoaderType LoaderType => ELoaderType.MelonLoader;

        public ConfigHandler ConfigHandler => _configHandler;

        public Action<object> OnLogMessage => LoggerInstance.Msg;
        public Action<object> OnLogWarning => LoggerInstance.Warning;
        public Action<object> OnLogError => LoggerInstance.Error;

        public override void OnInitializeMelon()
        {
            ULogger.CreateLogger(this);
            if (UPlugin.USE_CONFIG)
            {
                _configHandler = new MelonLoaderConfigHandler();
                ConfigManager.Init(_configHandler);    
            }
            var plugin = new UPlugin(this);
        }
    }
}
#endif