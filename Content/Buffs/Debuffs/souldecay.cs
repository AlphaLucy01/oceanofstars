using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using oceanofstars.Common.Players;
using oceanofstars.Common.GlobalNPCs;

namespace oceanofstars.Content.Buffs.Debuffs
{
    internal class souldecay : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Soul Decay");
            Description.SetDefault("Your soul is slowly decaying");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = false;
            BuffID.Sets.LongerExpertDebuff[Type] = true;
        }


        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<MPlayer>().lifeRegenDebuff = true;
        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<GNPC>().lifeRegenDebuff = true;
            npc.lifeRegen -= 16;
        }
    }
}
