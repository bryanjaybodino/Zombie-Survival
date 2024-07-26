using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Zombie_Survival.Sounds
{
    public class SoundEffects
    {
        public static class RifleAttack
        {
            public static SoundEffect audio;
            public static void LoadContent(ContentManager content)
            {
                audio = content.Load<SoundEffect>("Sounds/Rifle Sound");
            }
        }
        public static class PistolAttack
        {
            public static SoundEffect audio;
            public static void LoadContent(ContentManager content)
            {
                audio = content.Load<SoundEffect>("Sounds/Pistol Sound");
            }
        }
        public static class KnifeAttack
        {
            public static SoundEffect audio;
            public static void LoadContent(ContentManager content)
            {
                audio = content.Load<SoundEffect>("Sounds/Knife Sound");
            }
        }

        public static class ShotgunAttack
        {
            public static SoundEffect audio;
            public static void LoadContent(ContentManager content)
            {
                audio = content.Load<SoundEffect>("Sounds/Shotgun Sound");
            }
        }
    }
}
