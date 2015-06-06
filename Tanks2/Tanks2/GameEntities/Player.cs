using Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GameEntity
{
    public class Player
    {
        //public string id { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public Direction direction { get; set; }
        public bool wasShot { get; set; }
        public int health { get; set; }
        public int coins { get; set; }
        public int points { get; set; }
        public bool isOpponent { get; set; }
        public Texture2D texture { get; set; }
        //private string tankname;
        private string playerid;

        public string id
        {
            get
            {
                return playerid;
            }

            set
            {
                playerid = value;
                texture = Util.Content.Load<Texture2D>("tank"+id[1]);
            }
        }

        public Player()
        {
            //texture = Util.Content.Load<Texture2D>("tank1");
        }

        public void Draw()
        {
            Vector2 position = Vector2.Zero;
            Vector2 texturePosition = new Vector2(x * 30 + 15, y * 30 + 15) + position;

            //Here you would typically index to a Texture based on the textureId.
            Util.sprite.Draw(texture, texturePosition, null, Color.White, ((int)direction)*MathHelper.PiOver2, Util.CENTER, 1.0f, SpriteEffects.None, 0f);
        }
    }
}
