using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingoApp.Factories
{
    public class BingoCard
    {
        public Entities.BingoCard bingoCard;

        public BingoCard(int row, int column, string name, List<Entities.Range> rowRange)
        {
            
            bingoCard = new Entities.BingoCard();
            bingoCard.mat = new int[row, column];
            bingoCard.gottenNumbersBingoCard = new List<int>();
            bingoCard.row = row;
            bingoCard.column = column;
            bingoCard.playerName = name;
            bingoCard.mat = Services.BingoCard.GetRandomBingoCard(bingoCard, rowRange);
        }
    }
}
