using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlocXChange.Models;

namespace BlocXChange.Class
{
    public class GenerateGameData
    {
        public Game game { get; set; }

        private int InitialStockValue = 100;
        private int MaxCompany = 4;

        private int TotalGameMinutes = 45;
        private int FlucIntervalMinutes = 5;
        private long SecondsToTicks = 1000000;

        public GenerateGameData(Game game)
        {
            this.game = game;
        }

        public List<Stock> GetStocks()
        {
            var stocks = new List<Stock>();

            for(int n = 0; n < MaxCompany; n++)
            {
                Stock stock = new Stock()
                {
                    CompanyNo = n,
                    StockValue = InitialStockValue,
                    GameNo = game.GameNo
                };

                stocks.Add(stock);
            }
            return stocks;
        }

        public List<Fluctuation> GetFluctuations()
        {
            var fluctuations = new List<Fluctuation>();
            Random r = new Random();

            for(int i = 0; i < MaxCompany; i++)
            {
                var fluc = new List<int>();
                int value = InitialStockValue;
                for(int j = 0; j < 4; j++)
                {
                    int t = r.Next(-10, 10) * 10;
                    while(value + t <= 0 || t == 0)
                    {
                        t = r.Next(-10, 10) * 10;
                    }
                    value += t;

                    fluctuations.Add(new Fluctuation() { CompanyNo = i, FlucValue = t, GameNo = game.GameNo });
                }
            }

            ShuffleList(fluctuations);

            int n = 0;
            for(int i = 1; i < TotalGameMinutes / FlucIntervalMinutes; i++)
            {
                fluctuations[n].FlucTimeTicks = (long)i * FlucIntervalMinutes * 60 * SecondsToTicks;
                fluctuations[n + 1].FlucTimeTicks = (long)i * FlucIntervalMinutes * 60 * SecondsToTicks;
                n += 2;
            }

            return fluctuations;
        }

        public static void ShuffleList<T>(List<T> list)
        {
            Random r = new Random();
            int random1;
            int random2;

            T tmp;
            for (int index = 0; index < list.Count; ++index)
            {
                random1 = r.Next(0, list.Count);
                random2 = r.Next(0, list.Count);

                tmp = list[random1];
                list[random1] = list[random2];
                list[random2] = tmp;
            }
        }
    }
}
