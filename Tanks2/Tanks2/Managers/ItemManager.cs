using GameEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace Managers
{
    class ItemManager
    {
        private static ItemManager manager;
        private static List<CoinPile> coins;
        private static List<LifePack> lifepack;

        private ItemManager()
        {
            if(coins == null)
                coins = new List<CoinPile>();

            if(lifepack == null)
                lifepack = new List<LifePack>();
        }

        public static ItemManager getInstance()
        {
            if (manager == null)
                manager = new ItemManager();

            return manager;
        }

        public void addCoinPile(Position pos, int lifetime, int value)
        {
            CoinPile temp = new CoinPile();
            temp.x = pos.x;
            temp.y = pos.y;
            temp.lifetime = lifetime;
            temp.value = value;

            coins.Add(temp);
        }

        public void Draw()
        {
            foreach (CoinPile cp in coins)
                cp.Draw();

            foreach (LifePack lp in lifepack)
                lp.Draw();
        }

        public static void coinpileExpired(object source, ElapsedEventArgs e)
        {
            CoinPile temp = (CoinPile)source;
            coins.Remove(temp);
        }
    }
}
