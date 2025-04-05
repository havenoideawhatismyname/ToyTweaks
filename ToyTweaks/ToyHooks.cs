using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watcher;
using MoreSlugcats;
using System.Globalization;
using UnityEngine;

namespace ToyTweaks
{
    public class ToyHooks
    {
        public static void Hooks()
        {
            On.Watcher.UrbanToys.SpinToy.DrawSprites += SpinToy_DrawSprites;
            On.Watcher.UrbanToys.SpinToy.Update += SpinToy_Update;
            On.Watcher.UrbanToys.BallToy.DrawSprites += BallToy_DrawSprites;
            On.Watcher.UrbanToys.BallToy.Update += BallToy_Update;
            On.Watcher.UrbanToys.SoftToy.DrawSprites += SoftToy_DrawSprites;
            On.Watcher.UrbanToys.SoftToy.Update += SoftToy_Update;
            On.Watcher.UrbanToys.WeirdToy.DrawSprites += WeirdToy_DrawSprites;
            On.Watcher.UrbanToys.WeirdToy.Update += WeirdToy_Update;
        }

        private static void SpinToy_DrawSprites(On.Watcher.UrbanToys.SpinToy.orig_DrawSprites orig, UrbanToys.SpinToy self, RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, float timeStacker, UnityEngine.Vector2 camPos)
        {
            orig.Invoke(self, sLeaser, rCam, timeStacker, camPos);
            if (self.slatedForDeletetion || self.room != rCam.room)
            {
                sLeaser.CleanSpritesAndRemove();
            }         
        }

        private static void SpinToy_Update(On.Watcher.UrbanToys.SpinToy.orig_Update orig, UrbanToys.SpinToy self, bool eu)
        {
            orig.Invoke(self, eu);
            if (self.grabbedBy.Count > 0 || self.interactedWith)
            {
                if (ModManager.MMF && MMF.cfgKeyItemTracking.Value && self.room.game.session is StoryGameSession && AbstractPhysicalObject.UsesAPersistantTracker(self.abstractPhysicalObject) && self.abstractPhysicalObject.type == WatcherEnums.AbstractObjectType.SpinToy && Plugin.optionsMenuInstance.keyItemAllToys.Value)
                {
                    (self.room.game.session as StoryGameSession).AddNewPersistentTracker(self.abstractPhysicalObject);
                }
            }
        }

        private static void BallToy_DrawSprites(On.Watcher.UrbanToys.BallToy.orig_DrawSprites orig, UrbanToys.BallToy self, RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, float timeStacker, UnityEngine.Vector2 camPos)
        {
            orig.Invoke(self, sLeaser, rCam, timeStacker, camPos);
            if (self.slatedForDeletetion || self.room != rCam.room)
            {
                sLeaser.CleanSpritesAndRemove();
            }
        }

        private static void BallToy_Update(On.Watcher.UrbanToys.BallToy.orig_Update orig, UrbanToys.BallToy self, bool eu)
        {
            orig.Invoke(self, eu);
            if (self.grabbedBy.Count > 0 || self.interactedWith)
            {
                if (ModManager.MMF && MMF.cfgKeyItemTracking.Value && self.room.game.session is StoryGameSession && AbstractPhysicalObject.UsesAPersistantTracker(self.abstractPhysicalObject) && self.abstractPhysicalObject.type == WatcherEnums.AbstractObjectType.BallToy && Plugin.optionsMenuInstance.keyItemAllToys.Value)
                {
                    (self.room.game.session as StoryGameSession).AddNewPersistentTracker(self.abstractPhysicalObject);
                }
            }
        }

        private static void SoftToy_DrawSprites(On.Watcher.UrbanToys.SoftToy.orig_DrawSprites orig, UrbanToys.SoftToy self, RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, float timeStacker, UnityEngine.Vector2 camPos)
        {
            orig.Invoke(self, sLeaser, rCam, timeStacker, camPos);
            if (self.slatedForDeletetion || self.room != rCam.room)
            {
                sLeaser.CleanSpritesAndRemove();
            }
        }

        private static void SoftToy_Update(On.Watcher.UrbanToys.SoftToy.orig_Update orig, UrbanToys.SoftToy self, bool eu)
        {
            orig.Invoke(self, eu);
            if (self.grabbedBy.Count > 0 || self.interactedWith)
            {
                if (ModManager.MMF && MMF.cfgKeyItemTracking.Value && self.room.game.session is StoryGameSession && AbstractPhysicalObject.UsesAPersistantTracker(self.abstractPhysicalObject) && self.abstractPhysicalObject.type == WatcherEnums.AbstractObjectType.SoftToy && Plugin.optionsMenuInstance.keyItemAllToys.Value)
                {
                    (self.room.game.session as StoryGameSession).AddNewPersistentTracker(self.abstractPhysicalObject);
                }
            }
        }

        private static void WeirdToy_DrawSprites(On.Watcher.UrbanToys.WeirdToy.orig_DrawSprites orig, UrbanToys.WeirdToy self, RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, float timeStacker, UnityEngine.Vector2 camPos)
        {
            orig.Invoke(self, sLeaser, rCam, timeStacker, camPos);
            if (self.slatedForDeletetion || self.room != rCam.room)
            {
                sLeaser.CleanSpritesAndRemove();
            }
        }

        private static void WeirdToy_Update(On.Watcher.UrbanToys.WeirdToy.orig_Update orig, UrbanToys.WeirdToy self, bool eu)
        {
            orig.Invoke(self, eu);
            if (self.grabbedBy.Count > 0 || self.interactedWith)
            {
                if (ModManager.MMF && MMF.cfgKeyItemTracking.Value && self.room.game.session is StoryGameSession && AbstractPhysicalObject.UsesAPersistantTracker(self.abstractPhysicalObject) && self.abstractPhysicalObject.type == WatcherEnums.AbstractObjectType.WeirdToy && Plugin.optionsMenuInstance.keyItemAllToys.Value)
                {
                    (self.room.game.session as StoryGameSession).AddNewPersistentTracker(self.abstractPhysicalObject);
                }
            }
        }
    }
}
