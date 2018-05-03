using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BingoApp.Services
{
    public static class BingoCard
    {
        public static int[,] GetRandomBingoCard(Entities.BingoCard bingoCard, List<Entities.Range> rowsRange)
        {

            for (int r = 0; r < bingoCard.row; r++)
            {
                List<int> num = Services.Commons.RandomListGeneration.GetRandomListInRange(rowsRange[r].LowestBound, rowsRange[r].HighestBound, rowsRange[r].length);
                bingoCard.mat = SetBingoCardRow(bingoCard.mat, r, num);
            }

            return bingoCard.mat;

        }

        private static int[,] SetBingoCardRow(int[,] bingoCard, int row, List<int> num)
        {
            for(int column = 0; column<num.Count(); column++)
            {
                if (row == 2 && column == 2)
                {
                    //THE FREE SLOT
                    bingoCard[row, column] = 0;
                }
                else
                    bingoCard[row, column] = num[column];
            }
            return bingoCard;
        }

        public static void Print(Entities.BingoCard bingoCard)
        {
            for (int f = 0; f < bingoCard.row; f++)
            {
                for (int c = 0; c < bingoCard.column; c++)
                {
                    Console.Write(bingoCard.mat[f, c] + " ");
                }
                Console.WriteLine();
            }
            //Console.ReadKey();
        }

        public static List<Entities.Range> GetDefaultRange()
        {
            List<Entities.Range> listRanges = new List<Entities.Range>();
            Entities.Range bRow = new Entities.Range();
            bRow.LowestBound = 1;
            bRow.HighestBound = 16;
            bRow.length = 5;
            Entities.Range iRow = new Entities.Range();
            iRow.LowestBound = 16;
            iRow.HighestBound = 31;
            iRow.length = 5;
            Entities.Range nRow = new Entities.Range();
            nRow.LowestBound = 31;
            nRow.HighestBound = 46;
            nRow.length = 5;
            Entities.Range gRow = new Entities.Range();
            gRow.LowestBound = 46;
            gRow.HighestBound = 61;
            gRow.length = 5;
            Entities.Range oRow = new Entities.Range();
            oRow.LowestBound = 61;
            oRow.HighestBound = 76;
            oRow.length = 5;
            listRanges.Add(bRow);
            listRanges.Add(iRow);
            listRanges.Add(nRow);
            listRanges.Add(gRow);
            listRanges.Add(oRow);
            return listRanges;

        }

    }
}
