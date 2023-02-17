﻿using oceanofstars.Common.GlobalNPCs;
using oceanofstars.Common.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace oceanofstars.Content.Buffs
{
    internal class UpwardsBoostBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("u boost");
            Description.SetDefault("Your soul is slowly decaying");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = false;
            BuffID.Sets.LongerExpertDebuff[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<MPlayer>().hasUpwardsBoostBuff = true;
        }
        
    }
}
