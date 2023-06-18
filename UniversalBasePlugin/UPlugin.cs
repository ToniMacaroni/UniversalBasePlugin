using UniversalBasePlugin.Loader.Common;

namespace UniversalBasePlugin;

public class UPlugin : UPluginBase
{
    public readonly ILoader Loader;

    public UPlugin(ILoader loader)
    {
        Loader = loader;
        ULogger.Log($"Loaded {NAME} for {loader.LoaderType}");
    }

    #region CONSTS

    internal const string NAME = "UniversalBasePlugin";
    internal const string GUID = "com.tonimacaroni.universalbaseplugin"; // BIE
    internal const string VERSION = "1.0.0";
    internal const string AUTHOR = "ToniMacaroni"; // ML

    internal const int CONSOLE_R = 255; // ML - Console log color
    internal const int CONSOLE_G = 0; // ML - Console log color
    internal const int CONSOLE_B = 100; // ML - Console log color
    
    internal const bool USE_CONFIG = true;
    internal const bool ENABLE_CONFIG_WATCHER = false;
    internal const bool SUBSCRIBE_TO_SCENES = true;

    #endregion
}