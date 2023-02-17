using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using oceanofstars.Content.Tiles.CrystalDesert;

namespace oceanofstars.Content.Items.Blocks
{
    internal class CrystalSandstoneBlock : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystal sandstone");
        }
        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 16;
            Item.createTile = ModContent.TileType<crystalsandstone>();
            Item.autoReuse = true;
            Item.consumable = true;
            Item.useAnimation = 10;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.maxStack = 999;
        }
    }
}
