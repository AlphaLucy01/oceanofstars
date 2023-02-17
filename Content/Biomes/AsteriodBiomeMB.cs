using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using oceanofstars.Common.Systems;

namespace oceanofstars.Content.Biomes
{
    internal class AsteriodBiomeMB : ModBiome
    {
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Asteriod Biome");
        }
        public override bool IsBiomeActive(Player player)
        {
            return ModContent.GetInstance<GModSystem>().AsteriodBlockCount >= 40;
        }
        public override void OnInBiome(Player player)
        {
            
        }
        
    }
}
