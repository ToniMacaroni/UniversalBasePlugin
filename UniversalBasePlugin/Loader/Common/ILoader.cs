using UniversalBasePlugin.Loader.Common.Configuration;

namespace UniversalBasePlugin.Loader.Common;

public interface ILoader
{
    ConfigHandler ConfigHandler { get; }

    Action<object> OnLogMessage { get; }
    Action<object> OnLogWarning { get; }
    Action<object> OnLogError { get; }

    ELoaderType LoaderType { get; }
}