﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using oceanofstars.Content.Tiles;

namespace oceanofstars.Content.Items.Blocks
{
    internal class ArenaDoorItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Arena door");
        }
        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 16;
            Item.createTile = ModContent.TileType<ArenaDoor>();
            Item.autoReuse = true;
            Item.consumable = true;
            Item.useAnimation = 10;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.maxStack = 999;
        }
    }
}
