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
                if (testObj is UrbanToys.SpinToy)
                {
                    return true;
                }
                else
                {
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
                if (obj is UrbanToys.SpinToy)
                {
                    if ((obj as UrbanToys.SpinToy).spinTimer.isFinished || obj.grabbedBy.Count != 0)
                    {
                        return Player.ObjectGrabability.OneHand;
                    }
                    return Player.ObjectGrabability.CantGrab;
                }
                else
                {
                    if (obj is UrbanToys.SoftToy)
                    {
                        return Player.ObjectGrabability.BigOneHand;
                    }
                    if (obj is UrbanToys.WeirdToy)
                    {
                        return Player.ObjectGrabability.BigOneHand;
                    }
                    return result;
                }                
            }
            else
            {
                return result;
            }
        }
    }
}
