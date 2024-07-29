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
        public static class Rifle
        {
            public static class Attack
            {
                public static SoundEffectInstance audio;
                public static void LoadContent(ContentManager content)
                {
                    SoundEffect sound = content.Load<SoundEffect>("Sounds/Rifle Sound");
                    audio = sound.CreateInstance();
                    audio.IsLooped = false;
                    audio.Volume = 0.1f;
                }
            }
            public static class Reload
            {
                public static SoundEffectInstance audio;
                public static void LoadContent(ContentManager content)
                {
                    SoundEffect sound = content.Load<SoundEffect>("Sounds/Rifle Reload Sound");
                    audio = sound.CreateInstance();
                    audio.IsLooped = false;
                    audio.Volume = 0.025f;
                }
            }
        }




        public static class Pistol
        {
            public static class Attack
            {
                public static SoundEffectInstance audio;
                public static void LoadContent(ContentManager content)
                {
                    SoundEffect sound = content.Load<SoundEffect>("Sounds/Pistol Sound");
                    audio = sound.CreateInstance();
                    audio.IsLooped = false;
                    audio.Volume = 0.1f;
                }
            }

            public static class Reload
            {
                public static SoundEffectInstance audio;
                public static void LoadContent(ContentManager content)
                {
                    SoundEffect sound = content.Load<SoundEffect>("Sounds/Pistol Reload Sound");
                    audio = sound.CreateInstance();
                    audio.IsLooped = false;
                    audio.Volume = 0.025f;
                }
            }
        }


        public static class Shotgun
        {
            public static class Attack
            {
                public static SoundEffectInstance audio;
                public static void LoadContent(ContentManager content)
                {
                    SoundEffect sound = content.Load<SoundEffect>("Sounds/Shotgun Sound");
                    audio = sound.CreateInstance();
                    audio.IsLooped = false;
                    audio.Volume = 0.1f;
                }
            }
            public static class Reload
            {
                public static SoundEffectInstance audio;
                public static void LoadContent(ContentManager content)
                {
                    SoundEffect sound = content.Load<SoundEffect>("Sounds/Pistol Reload Sound");
                    audio = sound.CreateInstance();
                    audio.IsLooped = false;
                    audio.Volume = 0.025f;
                }
            }
        }


        public static class Knife
        {
            public static class Attack
            {
                public static SoundEffectInstance audio;
                public static void LoadContent(ContentManager content)
                {
                    SoundEffect sound = content.Load<SoundEffect>("Sounds/Knife Sound");
                    audio = sound.CreateInstance();
                    audio.IsLooped = false;
                    audio.Volume = 0.1f;
                }
            }
        }

        public static class Zombie
        {
            public static SoundEffectInstance audio;
            public static void LoadContent(ContentManager content)
            {
                SoundEffect sound = content.Load<SoundEffect>("Sounds/Zombie Sound");
                audio = sound.CreateInstance();
                audio.IsLooped = true;
                audio.Volume = 0.04f;
            }
            public static class Attack
            {
                public static SoundEffectInstance audio;
                public static void LoadContent(ContentManager content)
                {
                    SoundEffect sound = content.Load<SoundEffect>("Sounds/Zombie Attack Sound");
                    audio = sound.CreateInstance();
                    audio.IsLooped = false;
                    audio.Volume = 0.1f;
                }
            }
        }


        public static class Background
        {
            public static SoundEffectInstance audio;
            public static void LoadContent(ContentManager content)
            {
                SoundEffect sound = content.Load<SoundEffect>("Sounds/Background Sound");
                audio = sound.CreateInstance();
                audio.IsLooped = true;
                audio.Volume = 0.01f;
            }
        }
        public static class Helicopter
        {
            public static SoundEffectInstance audio;
            public static void LoadContent(ContentManager content)
            {
                SoundEffect sound = content.Load<SoundEffect>("Sounds/Helicopter Sound");
                audio = sound.CreateInstance();
                audio.IsLooped = false;
                audio.Volume = 1f;
            }

        }
    }
}
