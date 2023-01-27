using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace oceanofstars.Common.Players
{
    public class MPlayer : ModPlayer
    {
        #region souldecay
        public bool lifeRegenDebuff;

        public override void ResetEffects()
        {
            lifeRegenDebuff = false;
        }
        public override void UpdateBadLifeRegen()
        {
            if (lifeRegenDebuff)
            {
                if (Player.lifeRegen > 0)
                    Player.lifeRegen = 0;
                Player.lifeRegenTime = 0;
                Player.lifeRegen -= 16;
            }
        }
        #endregion
        #region Crystal Hearth
        public bool CrystalHeart;
        public bool died;
        public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            if (CrystalHeart)
            {
                Player.Heal(Player.statLifeMax2);
                died = true;
                genGore = false;
                playSound = false;
                return false;
            } else
            {
                died = false;
            }

            return true;
        }
        
        #endregion
        #region Crystal Curse
        
        #endregion
    }
}

