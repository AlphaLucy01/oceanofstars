using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace oceanofstars.Content.Items.Blocks.bars
{
    internal class examplebar : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Example bar");
        }
        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 24;
            Item.maxStack = 999;
        }
    }
}
