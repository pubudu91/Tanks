using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Core
{
    public class Util
    {
        public static string LOCALHOST = "127.0.0.1";
        public static string SERVERIP = LOCALHOST;//"10.8.106.49";
        public static string MYIP = LOCALHOST;//"10.10.6.183";
        public static ContentManager Content;
        public static SpriteBatch sprite;
        public static GameTime gameTime;
        public static float scale = 0.75f;
        public static Vector2 CENTER = new Vector2(15, 15);
    }
}
