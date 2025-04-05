using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using RWCustom;
using Menu.Remix.MixedUI;
using Mono.WebBrowser.DOM;

namespace ToyTweaks
{
    public class RemixMenu : OptionInterface
    {
        // 总选单
        public readonly Configurable<bool> keyItemAllToys;
        public readonly Configurable<bool> customIcons;
        public readonly Configurable<bool> oneHandAllToys;
        public readonly Configurable<bool> canSwallowAllToys;
        // 毛绒
        public readonly Configurable<bool> canSwallowSoftToy;
        public readonly Configurable<bool> oneHandSoftToy;
        public FSprite SpinToyIcon;
        // 球
        public readonly Configurable<bool> canSwallowBallToy;
        public readonly Configurable<bool> oneHandBallToy;
        public FSprite BallToyIcon;
        // 陀螺
        public readonly Configurable<bool> canSwallowSpinToy;
        public readonly Configurable<bool> oneHandSpinToy;
        public FSprite SoftToyIcon;
        // 奇怪
        public readonly Configurable<bool> canSwallowWeirdToy;
        public readonly Configurable<bool> oneHandWeirdToy;
        public FSprite WeirdToyIcon;

        public RemixMenu(Plugin toyTweaks)
        {
            // 总选单
            keyItemAllToys = config.Bind("ToyTweaks_Bool_KeyItemAllToys", true);
            customIcons = config.Bind("ToyTweaks_Bool_CustomIcons", true);
            oneHandAllToys = config.Bind("ToyTweaks_Bool_OneHandAllToys", false);
            canSwallowAllToys = config.Bind("ToyTweaks_Bool_CanSwallowAllToy", false);
            // 毛绒
            canSwallowSoftToy = config.Bind("ToyTweaks_Bool_CanSwallowSoftToy", false);
            oneHandSoftToy = config.Bind("ToyTweaks_Bool_OneHandSoftToy", false);
            // 球
            canSwallowBallToy = config.Bind("ToyTweaks_Bool_CanSwallowBallToy", false);
            oneHandBallToy = config.Bind("ToyTweaks_Bool_OneHandBallToy", true);
            // 陀螺
            canSwallowSpinToy = config.Bind("ToyTweaks_Bool_CanSwallowSpinToy", true);
            oneHandSpinToy = config.Bind("ToyTweaks_Bool_OneHandSpinToy", true);
            // 奇怪
            canSwallowWeirdToy = config.Bind("ToyTweaks_Bool_CanSwallowWeirdToy", false);
            oneHandWeirdToy = config.Bind("ToyTweaks_Bool_OneHandWeirdToy", true);
        }

        public override void Initialize()
        {
            var general = new OpTab(this, Custom.rainWorld.inGameTranslator.Translate("General"));
            var specific = new OpTab(this, Custom.rainWorld.inGameTranslator.Translate("Specific"));
            Tabs = new[] { general, specific };

            // 通用选单
            OpContainer generalContainer = new OpContainer(new Vector2(0, 0));
            general.AddItems(generalContainer);
            UIelement[] UIArrayElements = new UIelement[]
            {
                new OpLabel(new Vector2(150f, 520f), new Vector2(300f, 30f), Custom.rainWorld.inGameTranslator.Translate("General Configs"), FLabelAlignment.Center, true, null),
                new OpLabel(new Vector2(150f, 460f), new Vector2(300f, 30f), Custom.ReplaceLineDelimeters(OptionInterface.Translate("The configs below are general settings for all toys.") + Environment.NewLine + OptionInterface.Translate("If you want to change specific options for a particular toy, please go to the Specific tab.")), FLabelAlignment.Center, false, null),
                new OpCheckBox(keyItemAllToys, 100, 400f),
                new OpLabel(140, 400f, Custom.rainWorld.inGameTranslator.Translate("Toys as key items")),
                new OpCheckBox(customIcons, 100, 350f),
                new OpLabel(140, 350f, Custom.rainWorld.inGameTranslator.Translate("Give all toys unique icons")),
                new OpCheckBox(oneHandAllToys, 100, 300f),
                new OpLabel(140, 300f, Custom.rainWorld.inGameTranslator.Translate("Allow player to pick up all toys with one hand")),
                new OpCheckBox(canSwallowAllToys, 100, 250f),
                new OpLabel(140, 250f, Custom.rainWorld.inGameTranslator.Translate("Allow player to swallow all toys")),
            };
            general.AddItems(UIArrayElements);
            // 详情选单
            OpContainer specificContainer = new OpContainer(new Vector2(0, 0));
            specific.AddItems(specificContainer);
            // 贴图
            Futile.atlasManager.LoadAtlas("atlases/Symbol_SpinToy");
            Futile.atlasManager.LoadAtlas("atlases/Symbol_SoftToy");
            Futile.atlasManager.LoadAtlas("atlases/Symbol_BallToy");
            Futile.atlasManager.LoadAtlas("atlases/Symbol_WeirdToy");
            this.SpinToyIcon = new FSprite("Symbol_SpinToy", true)
            {
                x = 80,
                y = 455f,
                color = new Color(0.94117647059f, 0.94117647059f, 0.96078431373f)
            };
            this.SoftToyIcon = new FSprite("Symbol_SoftToy", true)
            {
                x = 360,
                y = 255f,
                color = new Color(0.6f, 0.2f, 0.49803921569f)
            };
            this.BallToyIcon = new FSprite("Symbol_BallToy", true)
            {
                x = 80,
                y = 255f,
                color = new Color(0.74117647059f, 0.45882352941f, 0.6f)
            };
            this.WeirdToyIcon = new FSprite("Symbol_WeirdToy", true)
            {
                x = 340,
                y = 455f,
                color = new Color(0.77647058824f, 0.72549019608f, 0.62352941176f)
            };
            specificContainer.container.AddChild(this.BallToyIcon);
            specificContainer.container.AddChild(this.SpinToyIcon);
            specificContainer.container.AddChild(this.WeirdToyIcon);
            specificContainer.container.AddChild(this.SoftToyIcon);
            UIArrayElements = new UIelement[]
            {
                new OpLabel(new Vector2(150f, 520f), new Vector2(300f, 30f), Custom.rainWorld.inGameTranslator.Translate("Specific Configs"), FLabelAlignment.Center, true, null),
                // 陀螺
                new OpLabel(100, 450f, Custom.rainWorld.inGameTranslator.Translate("~SpinToy~"),true),
                new OpCheckBox(oneHandSpinToy, 70, 400f),
                new OpLabel(110, 400f, Custom.rainWorld.inGameTranslator.Translate("Pick up SpinToy with one hand")),
                new OpCheckBox(canSwallowSpinToy, 70, 350f),
                new OpLabel(110, 350f, Custom.rainWorld.inGameTranslator.Translate("Allow player to swallow SpinToy")),
                // 球
                new OpLabel(100, 250f, Custom.rainWorld.inGameTranslator.Translate("~BallToy~"),true),
                new OpCheckBox(oneHandBallToy, 70, 200f),
                new OpLabel(110, 200f, Custom.rainWorld.inGameTranslator.Translate("Pick up BallToy with one hand")),
                new OpCheckBox(canSwallowBallToy, 70, 150f),
                new OpLabel(110, 150f, Custom.rainWorld.inGameTranslator.Translate("Allow player to swallow BallToy")),
                // 毛绒
                new OpLabel(380, 250f, Custom.rainWorld.inGameTranslator.Translate("~SoftToy~"),true),
                new OpCheckBox(oneHandSoftToy, 350, 200f),
                new OpLabel(390, 200f, Custom.rainWorld.inGameTranslator.Translate("Pick up SoftToy with one hand")),
                new OpCheckBox(canSwallowSoftToy, 350, 150f),
                new OpLabel(390, 150f, Custom.rainWorld.inGameTranslator.Translate("Allow player to swallow SoftToy")),
                // 奇怪
                new OpLabel(360, 450f, Custom.rainWorld.inGameTranslator.Translate("~WeirdToy~"),true),
                new OpCheckBox(oneHandWeirdToy, 350, 400f),
                new OpLabel(390, 400f, Custom.rainWorld.inGameTranslator.Translate("Pick up WeirdToy with one hand")),
                new OpCheckBox(canSwallowWeirdToy, 350, 350f),
                new OpLabel(390, 350f, Custom.rainWorld.inGameTranslator.Translate("Allow player to swallow WeirdToy")),
            };
            specific.AddItems(UIArrayElements);        
        }

        public override void Update()
        {
            base.Update();
            Tabs[0].colorButton = Color.green;
        }
    }
}
