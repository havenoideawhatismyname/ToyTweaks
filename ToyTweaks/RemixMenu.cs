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
        public readonly Configurable<bool> canSwallowAllToy;
        // 毛绒
        public readonly Configurable<bool> canSwallowSoftToy;
        public readonly Configurable<bool> oneHandSoftToy;
        // 球
        public readonly Configurable<bool> canGrabBallToy;
        public readonly Configurable<bool> canSwallowBallToy;
        public readonly Configurable<bool> oneHandBallToy;
        // 陀螺
        public readonly Configurable<bool> canSwallowSpinToy;
        public readonly Configurable<bool> oneHandSpinToy;
        // 奇怪
        public readonly Configurable<bool> canSwallowWeirdToy;
        public readonly Configurable<bool> oneHandWeirdToy;

        public RemixMenu(ToyTweaks toyTweaks)
        {
            // 毛绒
            canSwallowSoftToy = config.Bind("ToyTweaks_Bool_CanSwallowSoftToy", false);
            oneHandSoftToy = config.Bind("ToyTweaks_Bool_OneHandSoftToy", false);
            // 球
            canGrabBallToy = config.Bind("ToyTweaks_Bool_CanGrabBallToy", true);
            canSwallowBallToy = config.Bind("ToyTweaks_Bool_CanSwallowBallToy", false);
            oneHandBallToy = config.Bind("ToyTweaks_Bool_OneHandBallToy", false);
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
            var spinToy = new OpTab(this, Custom.rainWorld.inGameTranslator.Translate("SpinToy"));
            var ballToy = new OpTab(this, Custom.rainWorld.inGameTranslator.Translate("BallToy"));
            var softToy = new OpTab(this, Custom.rainWorld.inGameTranslator.Translate("SoftToy"));
            var weirdToy = new OpTab(this, Custom.rainWorld.inGameTranslator.Translate("WeirdToy"));
            Tabs = new[] { spinToy, ballToy, softToy, weirdToy };

            // 通用选单
            OpContainer generalContainer = new OpContainer(new Vector2(0, 0));
            general.AddItems(generalContainer);
            UIelement[] UIArrayElements = new UIelement[]
            {
                new OpLabel(new Vector2(250f, 535f), new Vector2(100f, 45f), "General Configs", FLabelAlignment.Center, true, null)
            };
            general.AddItems(UIArrayElements);
            // 陀螺选单
            OpContainer spinToyContainer = new OpContainer(new Vector2(0, 0));
            spinToy.AddItems(spinToyContainer);
            UIArrayElements = new UIelement[]
            {
                new OpLabel(new Vector2(250f, 535f), new Vector2(100f, 45f), "SpinToy Configs", FLabelAlignment.Center, true, null)

            };
            spinToy.AddItems(UIArrayElements);
            // 球选单
            OpContainer ballToyContainer = new OpContainer(new Vector2(0, 0));
            ballToy.AddItems(ballToyContainer);
            UIArrayElements = new UIelement[]
            {
                new OpLabel(new Vector2(250f, 535f), new Vector2(100f, 45f), "BallToy Configs", FLabelAlignment.Center, true, null)

            };
            ballToy.AddItems(UIArrayElements);
            // 毛绒选单
            OpContainer softToyContainer = new OpContainer(new Vector2(0, 0));
            softToy.AddItems(softToyContainer);
            UIArrayElements = new UIelement[]
            {
                new OpLabel(new Vector2(250f, 535f), new Vector2(100f, 45f), "SoftToy Configs", FLabelAlignment.Center, true, null)

            };
            softToy.AddItems(UIArrayElements);
            // 奇怪选单
            OpContainer weirdToyContainer = new OpContainer(new Vector2(0, 0));
            weirdToy.AddItems(weirdToyContainer);
            UIArrayElements = new UIelement[]
            {
                new OpLabel(new Vector2(250f, 535f), new Vector2(100f, 45f), "WeirdToy Configs", FLabelAlignment.Center, true, null)

            };
            weirdToy.AddItems(UIArrayElements);
        }

        public override void Update()
        {
            base.Update();
            Tabs[3].colorButton = Color.green;
            Tabs[3].colorCanvas = Color.green;
        }
    }
}
