using femc.addon.ely.art.Configuration;
using femc.addon.ely.art.Template;
using Reloaded.Hooks.ReloadedII.Interfaces;
using Reloaded.Mod.Interfaces;
using UnrealEssentials.Interfaces;
namespace femc.addon.ely.art
{
    public class Mod : ModBase
    {
        private readonly IModLoader _modLoader;
        private readonly IReloadedHooks? _hooks;
        private readonly ILogger _logger;
        private readonly IMod _owner;
        private Config _configuration;
        private readonly IModConfig _modConfig;

        public Mod(ModContext context)
        {
            _modLoader = context.ModLoader;
            _hooks = context.Hooks;
            _logger = context.Logger;
            _owner = context.Owner;
            _configuration = context.Configuration;
            _modConfig = context.ModConfig;
            var unrealEssentials = GetDependency<IUnrealEssentials>("Unreal Essentials");
            LoadEnabledStuff(unrealEssentials);
        }
        private IControllerType GetDependency<IControllerType>(string modName) where IControllerType : class
        {
            var controller = _modLoader.GetController<IControllerType>();
            if (controller == null || !controller.TryGetTarget(out var target))
                throw new Exception($"[{_modConfig.ModName}] Could not get controller for \"{modName}\". This depedency is likely missing.");
            return target;

        }
        private void LoadEnabledStuff(IUnrealEssentials unrealEssentials)
        {
            string path = _modLoader.GetDirectoryForModId(_modConfig.ModId);
            if (_configuration.cutin)
                unrealEssentials.AddFromFolder(Path.Combine(path, "CutIn"));
            if (_configuration.allout)
                unrealEssentials.AddFromFolder(Path.Combine(path, "AllOut"));
            if (_configuration.camp)
                unrealEssentials.AddFromFolder(Path.Combine(path, "Camp"));
            if (_configuration.bustup)
                unrealEssentials.AddFromFolder(Path.Combine(path, "BustUp"));
            if (_configuration.lvlup)
                unrealEssentials.AddFromFolder(Path.Combine(path, "LvlUp"));
            if (_configuration.title)
                unrealEssentials.AddFromFolder(Path.Combine(path, "Title"));
        }
        #region Standard Overrides
        public override void ConfigurationUpdated(Config configuration)
        {
            // Apply settings from configuration.
            // ... your code here.
            _configuration = configuration;
            _logger.WriteLine($"[{_modConfig.ModId}] Config Updated: Applying, All addons using unreal essentials will not be added/updated until you restart the game.");
        }
        #endregion
        #region For Exports, Serialization etc.
        #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Mod() { }
        #pragma warning restore CS8618
        #endregion
    }
}