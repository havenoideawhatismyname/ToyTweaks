using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watcher;

namespace ToyTweaks
{
    public class AbstractPhysicalObjectHooks
    {
        public static void Hooks()
        {
            On.AbstractPhysicalObject.UsesAPersistantTracker += AbstractPhysicalObject_UsesAPersistantTracker;
        }

        private static bool AbstractPhysicalObject_UsesAPersistantTracker(On.AbstractPhysicalObject.orig_UsesAPersistantTracker orig, AbstractPhysicalObject abs)
        {
            bool result = orig.Invoke(abs);
            if (ModManager.Watcher)
            {
                if (abs.type == WatcherEnums.AbstractObjectType.SpinToy)
                {
                    return true;
                }
                else
                {
                    if (abs.type == WatcherEnums.AbstractObjectType.WeirdToy)
                    {
                        return true;
                    }
                    if (abs.type == WatcherEnums.AbstractObjectType.SoftToy)
                    {
                        return true;
                    }
                    if (abs.type == WatcherEnums.AbstractObjectType.BallToy)
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
    }
}
