using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;


namespace oceanofstars.Content.Buffs.Debuffs.NMSCooldown
{
    internal class NMSCooldown : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nightmare Shriek Cooldown");
            Description.SetDefault("Nightmare Shriek is on cooldown");
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = false;

        }
    }
}
