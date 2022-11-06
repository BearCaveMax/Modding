using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Graphics.Shaders;
using Terraria.Graphics.Effects;
using UltraPhaseSaber.Content.Projectiles;
using Terraria.Audio;

namespace UltraPhaseSaber.Content.Items
{
	public class Ultra : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ultra Phasesaber"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("The crown jewel of cosmic swords");
		}
		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
		{
			target.AddBuff(BuffID.ShadowFlame, 5 * 60);
		}
		public override void SetDefaults()
		{
			Item.damage = 93;
			Item.crit = 7;
			Item.DamageType = DamageClass.Melee;
			Item.width = 96;
			Item.height = 96;
			Item.useTime = 25;
			Item.useAnimation = 25;
			Item.useStyle = 1;
			Item.knockBack = 9;
			Item.value = 73575;
			Item.rare = 5;
			Item.UseSound = new SoundStyle($"UltraPhaseSaber/Sounds/Item/UltraBeam") {
				Volume = 0.28f,
				PitchVariance = 0.3f,
				MaxInstances = 3,
			};
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.UltraBeam>();
			Item.shootSpeed = 14f;
		}
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(4) == 0)
			{
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.WhiteTorch);
			}
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.BluePhasesaber, 1);
			recipe.AddIngredient(ItemID.RedPhasesaber, 1);
			recipe.AddIngredient(ItemID.GreenPhasesaber, 1);
			recipe.AddIngredient(ItemID.YellowPhasesaber, 1);
			recipe.AddIngredient(ItemID.PurplePhasesaber, 1);
			recipe.AddIngredient(ItemID.WhitePhasesaber, 1);
			recipe.AddIngredient(ItemID.OrangePhasesaber, 1);
			recipe.AddIngredient(ItemID.FallenStar, 25);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}
