using femc.addon.ely.art.Template.Configuration;
using System.ComponentModel;
namespace femc.addon.ely.art.Configuration
{
    public class Config : Configurable<Config>
    {
        [DisplayName("Ely's Cut-In")]
        [Category("")]
        [Description("Enable Ely's Cut-in?")]
        [DefaultValue(true)]
        public bool cutin { get; set; } = true;

        [DisplayName("Ely's Level Up Screen")]
        [Category("")]
        [Description("Enable Ely's Level up screen?")]
        [DefaultValue(true)]
        public bool lvlup { get; set; } = true;

        [DisplayName("Ely's Title Screen for NG+")]
        [Category("")]
        [Description("Enable Ely's Title Screen?")]
        [DefaultValue(true)]
        public bool title { get; set; } = true;

        [DisplayName("Ely's All Out Attack Screen")]
        [Category("")]
        [Description("Enable Ely's All out attack?")]
        [DefaultValue(true)]
        public bool allout { get; set; } = true;

        [DisplayName("Ely's Camp Menu")]
        [Category("")]
        [Description("Enable Ely's Camp menu?")]
        [DefaultValue(true)]
        public bool camp { get; set; } = true;

        [DisplayName("Ely's Bust-Up")]
        [Category("")]
        [Description("Enable Ely's Bust-Up?")]
        [DefaultValue(true)]
        public bool bustup { get; set; } = true;
    }
    public class ConfiguratorMixin : ConfiguratorMixinBase
    {
        // 
    }
}
