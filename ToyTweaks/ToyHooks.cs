using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watcher;
using MoreSlugcats;

namespace ToyTweaks
{
    public class ToyHooks
    {
        public static void Hooks()
        {
            On.Watcher.UrbanToys.SpinToy.DrawSprites += SpinToy_DrawSprites;
            On.Watcher.UrbanToys.SpinToy.Update += SpinToy_Update;
            On.Watcher.UrbanToys.BallToy.DrawSprites += BallToy_DrawSprites;
            On.Watcher.UrbanToys.SoftToy.DrawSprites += SoftToy_DrawSprites;
            On.Watcher.UrbanToys.WeirdToy.DrawSprites += WeirdToy_DrawSprites;
        }

        private static void SpinToy_Update(On.Watcher.UrbanToys.SpinToy.orig_Update orig, UrbanToys.SpinToy self, bool eu)
        {
            orig.Invoke(self, eu);            
            /*if (self.grabbedBy.Count > 0)
            {
                if (ModManager.MMF && MMF.cfgKeyItemTracking.Value && self.room.game.session is StoryGameSession && AbstractPhysicalObject.UsesAPersistantTracker(self.abstractPhysicalObject))
                {
                    (self.room.game.session as StoryGameSession).AddNewPersistentTracker(self.abstractPhysicalObject);
                }
            }*/
        }

        private static void SpinToy_DrawSprites(On.Watcher.UrbanToys.SpinToy.orig_DrawSprites orig, UrbanToys.SpinToy self, RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, float timeStacker, UnityEngine.Vector2 camPos)
        {
            orig.Invoke(self, sLeaser, rCam, timeStacker, camPos);
            if (self.slatedForDeletetion || self.room != rCam.room)
            {
                sLeaser.CleanSpritesAndRemove();
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

        private static void SoftToy_DrawSprites(On.Watcher.UrbanToys.SoftToy.orig_DrawSprites orig, UrbanToys.SoftToy self, RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, float timeStacker, UnityEngine.Vector2 camPos)
        {
            orig.Invoke(self, sLeaser, rCam, timeStacker, camPos);
            if (self.slatedForDeletetion || self.room != rCam.room)
            {
                sLeaser.CleanSpritesAndRemove();
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
    }
}
