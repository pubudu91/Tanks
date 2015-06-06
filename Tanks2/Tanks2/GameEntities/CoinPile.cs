using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Core;
using System.Timers;
using Managers;

namespace GameEntity
{
    public class CoinPile : Cell
    {
        //public int lifetime { get; set; }
        public int value { get; set; }
        public long timestamp { get; set; }
        private Timer timer;
        private int life;

        public int lifetime
        {
            get
            {
                return life;
            }

            set
            {
                life = value;
                timer = new Timer(life);
                timer.AutoReset = false;
                timer.Elapsed += (sender, e) => ItemManager.coinpileExpired(this);
                timer.Enabled = true;
            }
        }

        public CoinPile()
        {
            F = -1;
            G = 0;
            H = 0;
            priority = 5;
            texture = Util.Content.Load<Texture2D>("coin");
            isPassable = true;
        }

        public override void Draw()
        {
            Vector2 position = Vector2.Zero;
            Vector2 texturePosition = new Vector2(x * 30, y * 30) + position;

            //Here you would typically index to a Texture based on the textureId.
            Util.sprite.Draw(texture, texturePosition, null, Color.White, 0, Vector2.Zero, 1.0f, SpriteEffects.None, 0f); 
        }
    }
}
