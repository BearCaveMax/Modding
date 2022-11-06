using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;
using Terraria.Graphics.Shaders;
using Terraria.Graphics.Effects;
using UltraPhaseSaber.Content.Projectiles;
using Terraria.Audio;
using Terraria.DataStructures;

namespace UltraPhaseSaber.Content.Items
{
	public class PlasmicSaber : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Plasmic Phasesaber"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("It cuts through butter like it's butter!");
		}
		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
		{
			target.AddBuff(BuffID.Venom, 5 * 60);
		}
		public override void SetDefaults()
		{
			Item.damage = 95;
			Item.crit = 15;
			Item.DamageType = DamageClass.Melee;
			Item.width = 96;
			Item.height = 96;
			Item.useTime = 43;
			Item.useAnimation = 43;
			Item.useStyle = 1;
			Item.knockBack = 10;
			Item.value = 103575;
			Item.rare = 7;
			Item.UseSound = new SoundStyle($"UltraPhaseSaber/Sounds/Item/PlasmBeam") {
				Volume = 0.32f,
				PitchVariance = 0.2f,
				MaxInstances = 3,
			};
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.PlasmBurst>();
			Item.shootSpeed = 5f;
		}
		
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(3) == 0)
			{
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.UltraBrightTorch);
			}
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient<Ultra>();
            recipe.AddIngredient(ItemID.Ectoplasm, 20);
            recipe.AddIngredient(ItemID.Katana, 1);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			const int NumProjectiles = 4;

			for(int i = 0; i < NumProjectiles; i++) {
				Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(20));
				newVelocity *= 1f - Main.rand.NextFloat(0.3f);
				Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
			}
			return false;
		}
		
	}
}
