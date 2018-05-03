using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingoApp.Entities
{
    public class BingoCard
    {
        public string playerName { get; set; }
        public int[,] mat { get; set; }
        public int row { get; set; }
        public int column { get; set; }
        public List<int> gottenNumbersBingoCard { get;set;}
    }
}
