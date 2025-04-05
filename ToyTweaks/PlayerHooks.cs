using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watcher;

namespace ToyTweaks
{
    public class PlayerHooks
    {
        public static void Hooks()
        {
            On.Player.Grabability += Player_Grabability;
            On.Player.CanBeSwallowed += Player_CanBeSwallowed;
        }

        private static bool Player_CanBeSwallowed(On.Player.orig_CanBeSwallowed orig, Player self, PhysicalObject testObj)
        {
            bool result = orig.Invoke(self, testObj);
            if (ModManager.Watcher)
            {
                if (testObj is UrbanToys.SpinToy && (Plugin.optionsMenuInstance.canSwallowSpinToy.Value|| Plugin.optionsMenuInstance.canSwallowAllToys.Value))
                {
                    return true;
                }
                else
                {
                    if (testObj is UrbanToys.SoftToy && (Plugin.optionsMenuInstance.canSwallowSoftToy.Value || Plugin.optionsMenuInstance.canSwallowAllToys.Value))
                    {
                        return true;
                    }
                    if (testObj is UrbanToys.WeirdToy && (Plugin.optionsMenuInstance.canSwallowWeirdToy.Value || Plugin.optionsMenuInstance.canSwallowAllToys.Value))
                    {
                        return true;
                    }
                    if (testObj is UrbanToys.BallToy && (Plugin.optionsMenuInstance.canSwallowBallToy.Value || Plugin.optionsMenuInstance.canSwallowAllToys.Value))
                    {
                        return true;
                    }
                    return result;
                }
            }
            else
            {
                return result;
            }
        }

        public static Player.ObjectGrabability Player_Grabability(On.Player.orig_Grabability orig, Player self, PhysicalObject obj)
        {
            Player.ObjectGrabability result = orig.Invoke(self, obj);
            if (ModManager.Watcher)
            {
                if (obj is UrbanToys.SpinToy && (Plugin.optionsMenuInstance.oneHandSpinToy.Value || Plugin.optionsMenuInstance.oneHandAllToys.Value))
                {
                    if ((obj as UrbanToys.SpinToy).spinTimer.isFinished || obj.grabbedBy.Count != 0)
                    {
                        return Player.ObjectGrabability.OneHand;
                    }
                    return Player.ObjectGrabability.CantGrab;
                }
                else
                {
                    if (obj is UrbanToys.SoftToy && (Plugin.optionsMenuInstance.oneHandSoftToy.Value || Plugin.optionsMenuInstance.oneHandAllToys.Value))
                    {
                        return Player.ObjectGrabability.OneHand;
                    }
                    if(obj is UrbanToys.WeirdToy && (Plugin.optionsMenuInstance.oneHandWeirdToy.Value || Plugin.optionsMenuInstance.oneHandAllToys.Value))
                    {
                        return Player.ObjectGrabability.OneHand;
                    }
                    if (obj is UrbanToys.BallToy && (Plugin.optionsMenuInstance.oneHandBallToy.Value || Plugin.optionsMenuInstance.oneHandAllToys.Value))
                    {
                        return Player.ObjectGrabability.OneHand;
                    }
                    else
                    {
                        return result;
                    }
                }                
            }
            else
            {
                return result;
            }
        }
    }
}
