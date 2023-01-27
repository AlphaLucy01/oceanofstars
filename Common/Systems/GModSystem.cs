using oceanofstars.Content.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace oceanofstars.Common.Systems
{
    internal class GModSystem : ModSystem
    {
        public int CrystanSandstoneBlockCount;

        public override void TileCountsAvailable(ReadOnlySpan<int> tileCounts)
        {
            CrystanSandstoneBlockCount = tileCounts[ModContent.TileType<crystalsandstone>()];
        }
    }
}
