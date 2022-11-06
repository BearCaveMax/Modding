using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Terraria.Audio;
using Microsoft.Xna.Framework;
using Terraria.Graphics.Shaders;
using Terraria.Graphics.Effects;
using System;


namespace UltraPhaseSaber.Content.Items
{
	public class LightStaff : ModItem
	{
		public override void SetStaticDefaults() {
            DisplayName.SetDefault("Goldenlight Staff");
			Tooltip.SetDefault("Shoots bolts of concentrated light.");
		}

		public override void SetDefaults() {
			Item.damage = 60;
			Item.DamageType = DamageClass.Magic;
			Item.width = 32;
			Item.height = 32;
			Item.useTime = 40;
			Item.useAnimation = 40;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 6;
			Item.value = 22000;
			Item.rare = 3;
			Item.UseSound = new SoundStyle($"UltraPhaseSaber/Sounds/Item/LightBeam") {
                Volume = 0.3f,
                PitchVariance = 0.1f,
                MaxInstances = 4,
            };
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.LightBeam>();
			Item.shootSpeed = 27f;
			Item.crit = 6;
			Item.mana = 16;
		}

		
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
				recipe.AddIngredient(ItemID.AmberStaff, 1);
                recipe.AddIngredient(ItemID.Obsidian, 35);
                recipe.AddIngredient(ItemID.SunplateBlock, 50);
				recipe.AddTile(TileID.Hellforge);
				recipe.Register();
		}
	}
} 
