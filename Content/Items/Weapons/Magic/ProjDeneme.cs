using System;
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
using Terraria.Audio;
using Mono.Cecil;
using static Terraria.ModLoader.PlayerDrawLayer;
using oceanofstars.Content.Items.Blocks.bars;

namespace oceanofstars.Content.Items.Weapons.Magic
{
    internal class ProjDeneme : ModItem
    {
        public int timesFired = 0;
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("deneme");
        }
        public override void SetDefaults()
        {
            Item.height = 64;
            Item.width = 30;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.useAnimation = 8;
            Item.useTime = 8;
            Item.consumable = false;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.DamageType = DamageClass.Magic;
            Item.damage = 10;
            Item.shootSpeed = 15;
            

            Item.shoot = ModContent.ProjectileType<DenemeProj>();
        }
        

        public override void AddRecipes()
        {
            Recipe.Create(ModContent.ItemType<PHwand>())
                .AddIngredient<examplebar>(10)
                .AddTile(TileID.Anvils)
                .Register();
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            /*position += Vector2.Normalize(new Vector2(velocity.X, velocity.Y)) * 45f;
            for (int i = 0; i < 8; i++)
            {
                Vector2 vel = Vector2.UnitX.RotatedBy(MathHelper.ToRadians(i * 45)) * (1 + i / 15f) * 6f;
                Projectile.NewProjectile(source, position.X, position.Y, vel.X, vel.Y, type, damage, knockback, player.whoAmI);
            }*/
            

            return true;
            
        } 
    }
    public class DenemeProj : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.friendly = true;
            Projectile.width = 26;
            Projectile.height = 26;
            Projectile.aiStyle = 0;
            Projectile.timeLeft = 600;
            Projectile.penetrate = 1;
        }
        public override void OnSpawn(IEntitySource source)
        {
            Projectile.rotation = Projectile.Center.DirectionTo(Main.MouseWorld).ToRotation();
            Projectile.spriteDirection = Projectile.direction;
        }
        public override void AI()
        {
            Projectile.ai[0]++;
            if (Projectile.ai[0] >= 120)
            {
                Projectile.ai[1]++;
                Vector2 vel = Vector2.UnitX.RotatedBy(MathHelper.ToRadians(Projectile.ai[1] * 15)) * 4f;
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X, Projectile.position.Y, vel.X, vel.Y, ModContent.ProjectileType<PHwandproj>(), Projectile.damage, Projectile.knockBack, Main.LocalPlayer.whoAmI);
            }
            Projectile.velocity *= 0.85f;// make it swirl

            /*Player player = Main.LocalPlayer;
            if (Projectile.getRect().Intersects(Main.LocalPlayer.getRect()))//collision check
            {
               player.velocity = new Vector2(0, 0);
               player.gravity = -1f;
            }*/
        }
    }
}
