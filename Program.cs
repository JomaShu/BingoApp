using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BingoApp.Entities;

namespace BingoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = 5;
            int columns = 5;
            int LowestBound = 1;
            int HighestBound = 75;
            int numberOfPlayer = 2;
            Entities.Caller caller = new Factories.Caller(HighestBound).caller;
            List<Entities.BingoCard> players = new List<Entities.BingoCard>();
            Entities.BingoCard player;
            List<Entities.Range> rowRangeList = BingoApp.Services.BingoCard.GetDefaultRange();

            for (int i =1;i<=numberOfPlayer;i++)
            {
                player = new Factories.BingoCard(rows, columns, i.ToString(), rowRangeList).bingoCard;
                players.Add(player);
                Services.BingoCard.Print(player);
            }

            Services.NumberCaller.CallGame(players,caller);

            Console.ReadLine();


        }

    }
}
