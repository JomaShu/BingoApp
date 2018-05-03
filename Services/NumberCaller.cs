using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using BingoApp.Entities;

namespace BingoApp.Services
{
    public static class NumberCaller
    {
        public static Entities.BingoCard CallTestGame(List<Entities.BingoCard> players, Entities.Caller caller, bool cheater = false)
        {
            bool bingoCalled = false;

            foreach (int num in caller.BallNumberBag)
            {
                if (bingoCalled)
                {
                    break;
                }
                else
                {
                    caller.CalledNumber.Add(num);
                    Console.WriteLine(num);
                    foreach (var player in players)
                    {
                        if (Services.CheckBingoCard.CheckNumberInBingoCard(player.gottenNumbersBingoCard, num, player.mat, player.row, player.column))
                        {
                            Console.WriteLine(num + " - WoW");
                            if (cheater && num == 23)
                            {
                                CheckCheater(caller, player);
                                bingoCalled = true;
                                return player;
                            }
                            if (player.gottenNumbersBingoCard.Count() == (player.row * player.column) - 1)
                            {
                                bingoCalled = true;
                                return player;

                            }
                        }
                    }
                }
            }
            return players[0];
        }
        public static void CallGame(List<Entities.BingoCard> players, Entities.Caller caller, bool cheater = false)
        {
            bool bingoCalled = false;
            
            foreach (int num in caller.BallNumberBag)
            {
                if (bingoCalled)
                {
                    break;
                }
                else
                {
                    caller.CalledNumber.Add(num);
                    Console.WriteLine(num);
                    foreach (var player in players)
                    {
                        if (Services.CheckBingoCard.CheckNumberInBingoCard(player.gottenNumbersBingoCard, num, player.mat, player.row, player.column))
                        {
                            Console.WriteLine(num + " - WoW");
                            if(cheater && num == 23)
                            {
                                CheckCheater(caller, player);
                            }
                            if (player.gottenNumbersBingoCard.Count() == (player.row * player.column) - 1)
                            {
                                Console.WriteLine("BIINNNGGOOO!!!");
                                Services.BingoCard.Print(player);

                                if (Services.CheckBingoCard.CheckBingoCardCompleted(caller.CalledNumber, player.mat, player.row, player.column).Count() == (player.row * player.column) - 1)
                                {
                                    foreach (int number in caller.CalledNumber)
                                    {
                                        Console.WriteLine(number);
                                    }
                                    Console.WriteLine("YESSSSSSS!!!");
                                    Console.WriteLine("Winner Player: " + player.playerName);
                                    bingoCalled = true;
                                }
                                else
                                {
                                    Console.WriteLine("Nop Sorry :(");
                                }
                            }
                        }

                    }

                }
            }
        }

        private static void CheckCheater(Caller caller, Entities.BingoCard player)
        {
            if (Services.CheckBingoCard.CheckBingoCardCompleted(caller.CalledNumber, player.mat, player.row, player.column).Count() != (player.row * player.column) - 1)
            {
                foreach (int number in caller.CalledNumber)
                {
                    Console.WriteLine(number);
                }
                Console.WriteLine("YESSSSSSS!!!");
                Console.WriteLine("Winner Player: " + player.playerName);

            }
        }

        public static int CallASingleNumber(Entities.Caller caller)
        {
            return caller.BallNumberBag[0];
        }
    }
}
