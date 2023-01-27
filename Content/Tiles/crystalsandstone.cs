﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ObjectData;
using oceanofstars.Content.Items.Blocks;

namespace oceanofstars.Content.Tiles
{
    internal class crystalsandstone : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileLighted[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.lightning = 15f;

            ModTranslation name = CreateMapEntryName();
            AddMapEntry(Color.DarkOliveGreen, name);
            name.SetDefault("");
        }
        public override bool Drop(int i, int j)
        {
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 16, ModContent.ItemType<CrystalSandstoneBlock>());
            return base.Drop(i, j);
        }
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            Tile left = Main.tile[i - 1, j];
            Tile right = Main.tile[i + 1, j];
            Tile up = Main.tile[i, j - 1];
            Tile down = Main.tile[i, j + 1];
            if (left.HasTile && right.HasTile && up.HasTile && down.HasTile)
            {
                return;
            }
            r = 0.35f;
            g = 0.25f;
            b = 0.3f;
        }
    }
}
