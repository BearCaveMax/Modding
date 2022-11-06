using Terraria;
using Terraria.ID;
using System;
using Terraria.Audio;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using UltraPhaseSaber.Content.Dusts;

namespace UltraPhaseSaber.Content.Projectiles
{
    public class LightBeam : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("LightBeam");
        }
        public override void SetDefaults()
        {
            Projectile.width = 32;
            Projectile.height = 16;
            AIType = ProjectileID.AmberBolt;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.timeLeft = 600;
            Projectile.penetrate = 10;
            Projectile.light = 0.4f;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.immune[Projectile.owner] = 4;
        }
        public override void Kill(int timeLeft) {
            for (int k = 0; k < 5; k++) {
                Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, ModContent.DustType<GoldLight>(), Projectile.oldVelocity.X * 0.5f, Projectile.oldVelocity.Y * 0.5f);
            }
        }
        public override void AI()
         {
            Lighting.AddLight(Projectile.position, 0.5f, 0.5f, 0.1f);
            if (Main.rand.NextBool(2))
            {
                Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, ModContent.DustType<GoldLight>(), Projectile.velocity.X * 0.5f, Projectile.velocity.Y * 0.5f);
            }
             Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2 - MathHelper.PiOver4 * Projectile.spriteDirection;
         }
    }
}
