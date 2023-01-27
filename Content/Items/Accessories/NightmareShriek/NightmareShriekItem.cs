﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.IO;
using Terraria.ID;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using oceanofstars.Content.Buffs.Debuffs.NMSCooldown;

namespace oceanofstars.Content.Items.Accessories.NightmareShriek
{
    internal class NightmareShriekItem : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nightmare Shriek");
            Tooltip.SetDefault("zattiri zort zort");
        }
        public override void SetDefaults()
        {
            Item.height = 30;
            Item.width = 30;
            Item.accessory = true;
        }
        public override void UpdateEquip(Player player)
        {
            if (!player.HasBuff(ModContent.BuffType<NMSCooldown>()))
            {
                Projectile.NewProjectile(player.GetSource_Accessory(Item), player.position, Vector2.Zero, ModContent.ProjectileType<NightmareShriekProj>(), 1, 0, Main.myPlayer);
            }
        }
    }
    internal class NightmareShriekProj : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.height = 30;
            Projectile.width = 30;
            Projectile.friendly = true;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 9999999;
            Projectile.scale = 1;
        }
        public override void OnSpawn(IEntitySource source)
        {
            if (Main.player[Projectile.owner].ownedProjectileCounts[Projectile.type] >= 1)
            {
                Projectile.Kill();
            }
        }
        public override void AI()
        {
            Projectile.position.X = Main.player[Projectile.owner].position.X - 8;
            Projectile.position.Y = Main.player[Projectile.owner].position.Y - 32;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Main.player[Projectile.owner].AddBuff(ModContent.BuffType<NMSCooldown>(), 15 * 60);
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position, Vector2.Zero, ModContent.ProjectileType<NightmareShriekProj1>(), 1, 0, Main.myPlayer);
            //projectile ın ölmesi ve başka oluşması
        }
    }
    internal class NightmareShriekProj1 : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.height = 30;
            Projectile.width = 30;
            Projectile.friendly = true;
            Projectile.damage = 10;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 180;
        }
        public override void OnSpawn(IEntitySource source)
        {
            if (Main.player[Projectile.owner].ownedProjectileCounts[Projectile.type] >= 1)
            {
                Projectile.Kill();
            }
        }
        public override void AI()
        {
            //scale up normally
        }
    }
}
