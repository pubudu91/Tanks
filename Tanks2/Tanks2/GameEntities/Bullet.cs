using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Core;
using GameEntity;

namespace GameLogic.GameEntities
{
    class Bullet
    {
        Texture2D bulletTexture;
        float bulletAngle;
        public int x { get; set; }
        public int y { get; set; }
        public Direction bulletDirection { get; set; }

        float bulletTime = 250;
        private bool moved = false;

        public Bullet()
        {
            bulletTexture = Util.Content.Load<Texture2D>("rocket");
        }

        public void Draw()
        {
            bulletAngle = (float)bulletDirection * 90;
            float elapsedTime = (float)Util.gameTime.ElapsedGameTime.TotalMilliseconds;
            bulletTime = bulletTime - elapsedTime;
            if (bulletTime < 0)
            {
                x += (int)Math.Round(Math.Sin(bulletAngle * Math.PI / 180), 0, MidpointRounding.AwayFromZero);
                y += (int)Math.Round(-Math.Cos(bulletAngle * Math.PI / 180), 0, MidpointRounding.AwayFromZero);
                moved = true;
                bulletTime = 250;
            }

            Util.sprite.Draw(bulletTexture, new Vector2(10 + 30 * x, 10 + 30 * y), null, Color.White, bulletAngle, new Vector2(30, 30), 0, SpriteEffects.None, 0);
        }
    }
}
