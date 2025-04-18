﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;

namespace ToyTweaks
{

    [BepInPlugin("fanc39cat.toytweaks", "ToyTweaks", "0.1.0")]
    public class Plugin : BaseUnityPlugin
    {
        public static RemixMenu optionsMenuInstance;
        public void OnEnable()
        {
            On.RainWorld.OnModsInit += RainWorld_OnModsInit;            
        }

        private void RainWorld_OnModsInit(On.RainWorld.orig_OnModsInit orig, RainWorld self)
        {
            orig.Invoke(self);
            PlayerHooks.Hooks();
            ToyHooks.Hooks();
            AbstractPhysicalObjectHooks.Hooks();
            ItemSymbolHooks.Hooks();
            // Remix菜单
            optionsMenuInstance = new RemixMenu(this);
            MachineConnector.SetRegisteredOI("fanc39cat.toytweaks", optionsMenuInstance);
        }      
    }
}
