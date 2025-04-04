using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watcher;
using RWCustom;
using UnityEngine;

namespace ToyTweaks
{
    public class ItemSymbolHooks
    {
        public static void Hooks()
        {
            On.ItemSymbol.SpriteNameForItem += ItemSymbol_SpriteNameForItem;
            On.ItemSymbol.ColorForItem += ItemSymbol_ColorForItem;
        }     

        private static string ItemSymbol_SpriteNameForItem(On.ItemSymbol.orig_SpriteNameForItem orig, AbstractPhysicalObject.AbstractObjectType itemType, int intData)
        {
            string result = orig.Invoke(itemType, intData);
            Futile.atlasManager.LoadAtlas("atlases/Symbol_SpinToy");
            Futile.atlasManager.LoadAtlas("atlases/Symbol_SoftToy");
            Futile.atlasManager.LoadAtlas("atlases/Symbol_BallToy");
            Futile.atlasManager.LoadAtlas("atlases/Symbol_WeirdToy");
            if (itemType == WatcherEnums.AbstractObjectType.SpinToy)
            {
                return "Symbol_SpinToy";
            }
            else
            {
                if(itemType == WatcherEnums.AbstractObjectType.SoftToy)
                {
                    return "Symbol_SoftToy";
                }
                if(itemType == WatcherEnums.AbstractObjectType.BallToy)
                {
                    return "Symbol_BallToy";
                }
                if (itemType == WatcherEnums.AbstractObjectType.WeirdToy)
                {
                    return "Symbol_WeirdToy";
                }
            }
            return result;
        }

        private static UnityEngine.Color ItemSymbol_ColorForItem(On.ItemSymbol.orig_ColorForItem orig, AbstractPhysicalObject.AbstractObjectType itemType, int intData)
        {
            UnityEngine.Color result = orig.Invoke(itemType, intData);
            if (itemType == WatcherEnums.AbstractObjectType.SpinToy)
            {
                return new Color(0.94117647059f, 0.94117647059f, 0.96078431373f);
            }
            else
            {
                if (itemType == WatcherEnums.AbstractObjectType.SoftToy)
                {
                    return new Color(0.6f, 0.2f, 0.49803921569f);
                }
                if (itemType == WatcherEnums.AbstractObjectType.BallToy)
                {
                    return new Color(0.74117647059f, 0.45882352941f, 0.6f);
                }
                if (itemType == WatcherEnums.AbstractObjectType.WeirdToy)
                {
                    return new Color(0.77647058824f, 0.72549019608f, 0.62352941176f);
                }
            }
            return result;
        }
    }
}
