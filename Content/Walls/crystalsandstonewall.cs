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

namespace oceanofstars.Content.Walls
{
    internal class crystalsandstonewall : ModWall
    {
        public override void SetStaticDefaults()
        {
            Main.tileMergeDirt[Type] = true;
            ModTranslation name = CreateMapEntryName();
            AddMapEntry(Color.Gray, name);
            name.SetDefault("");
        }
    }
}
