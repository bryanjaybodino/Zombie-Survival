using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Zombie_Survival.Characters.Textures;

namespace Zombie_Survival.Bullets
{
    public abstract class Ammunition
    {
        public int Damage { get; protected set; }
        public int MaxBullets { get; protected set; }
        public int CurrentBullets { get; protected set; }
        public int TotalBullets { get; protected set; }

        public Texture2D[] Reload(string currentWeapon)
        {
            if (TotalBullets > 0 && CurrentBullets < MaxBullets)
            {
                int bulletsNeeded = MaxBullets - CurrentBullets;
                if (TotalBullets >= bulletsNeeded)
                {
                    CurrentBullets += bulletsNeeded;
                    TotalBullets -= bulletsNeeded;
                }
                else
                {
                    CurrentBullets += TotalBullets;
                    TotalBullets = 0;
                }

                if (currentWeapon.ToLower() == "rifle")
                {
                    Sounds.SoundEffects.Rifle.Reload.audio.Play();
                    return RifleReload.frames;
                }
                else if (currentWeapon.ToLower() == "pistol")
                {
                    Sounds.SoundEffects.Pistol.Reload.audio.Play();
                    return PistolReload.frames;
                }
                else
                {
                    Sounds.SoundEffects.Shotgun.Reload.audio.Play();
                    return ShotgunReload.frames;
                }
            }
            else
            {

                if (currentWeapon.ToLower() == "rifle")
                {

                    return Rifle.frames;
                }
                else if (currentWeapon.ToLower() == "pistol")
                {
                    return Pistol.frames;
                }
                else
                {
                    return Shotgun.frames;
                }
            }


        }
        public void Shoot()
        {
            if (CurrentBullets > 0)
            {
                CurrentBullets--;
            }
        }
    }

    public class Magazines
    {
        public class Rifle : Ammunition
        {
            public Rifle()
            {
                Damage = 30;
                MaxBullets = 30;
                CurrentBullets = 30;
                TotalBullets = 120;
            }
        }

        public class Pistol : Ammunition
        {
            public Pistol()
            {
                Damage = 20;
                MaxBullets = 15;
                CurrentBullets = 15;
                TotalBullets = 45;
            }
        }

        public class Shotgun : Ammunition
        {
            public Shotgun()
            {
                Damage = 75;
                MaxBullets = 7;
                CurrentBullets = 7;
                TotalBullets = 35;
            }
        }
    }
}
