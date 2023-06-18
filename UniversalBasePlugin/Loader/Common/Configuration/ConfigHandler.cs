﻿namespace UniversalBasePlugin.Loader.Common.Configuration;

public abstract class ConfigHandler
{
    public abstract void RegisterConfigElement<T>(ConfigElement<T> element);

    public abstract void SetConfigValue<T>(ConfigElement<T> element, T value);

    public abstract T GetConfigValue<T>(ConfigElement<T> element);

    public abstract void Init();

    public abstract void LoadConfig();

    public abstract void ReloadFile();

    public abstract void SaveConfig();

    public virtual void OnAnyConfigChanged()
    { }
    
    public abstract string ConfigPath { get; }
}