using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingoApp.Services
{
    public static class CheckBingoCard
    {
        private static Object thisLock = new Object();

        public static bool CheckNumberInBingoCard(List<int> gottenNumbersBingoCard, int numberCalled, int[,] bingoCard, int rows, int columns)
        {
            lock (thisLock)
            {
                for (int r = 0; r < rows; r++)
                {
                    for (int c = 0; c < columns; c++)
                    {
                        if (bingoCard[r, c] == numberCalled)
                        {
                            gottenNumbersBingoCard.Add(numberCalled);
                            return true;
                        }

                    }
                }
                return false;
            }
        }
        public static List<int> CheckBingoCardCompleted(List<int> calledNumbers, int[,] bingCard, int rows, int columns)
        {
            List<int> numbersGottenBingoCard = new List<int>();

            foreach (var num in calledNumbers)
            {
                for (int r = 0; r < rows; r++)
                {
                    for (int c = 0; c < columns; c++)
                    {
                        if (bingCard[r, c] == num)
                        {
                            numbersGottenBingoCard.Add(num);
                            if(numbersGottenBingoCard.Count()==(rows*columns)-1)
                                return numbersGottenBingoCard;
                        }

                    }
                } 
            }
            return numbersGottenBingoCard;
        }
    }
}
