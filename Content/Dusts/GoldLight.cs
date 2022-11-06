using Terraria;
using Terraria.ModLoader;

namespace UltraPhaseSaber.Content.Dusts
{
    public class GoldLight : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.velocity *= 0.3f;
            dust.noGravity = true;
            dust.noLight = true;
            dust.scale *= 1.2f;
        }
        public override bool Update(Dust dust)
        {
            dust.position += dust.velocity;
            dust.rotation += dust.velocity.X * 0.15f;
            dust.scale *= 0.99f;

            float light = 0.35f * dust.scale;

            Lighting.AddLight(dust.position, 0.4f, 0.4f, 0.1f);

            if (dust.scale < 0.5f)
            {
                dust.active = false;
            }
            return false;
        }
    }
}
