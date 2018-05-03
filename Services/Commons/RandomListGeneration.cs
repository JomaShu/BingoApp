using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingoApp.Services.Commons
{
    public static class RandomListGeneration
    {
        private static List<int> SetRangeList(int lowerBound, int upperBound, int quantity)
        {
            
            var ballNumberBag = new List<int>();

            if (ballNumberBag == null)
                ballNumberBag.Add(0);
            for(; lowerBound <= upperBound; lowerBound++)
            {
                ballNumberBag.Add(lowerBound);
            }

            return ballNumberBag;

        }

        public static List<int> GetRandomListInRange(int lowerBound, int upperBound, int quantity)
        {
            List<int> ballNumberBag = SetRangeList(lowerBound,upperBound,quantity);
            List<int> selectedNumberList = new List<int>();

            while (selectedNumberList == null || selectedNumberList.Count() < quantity)
            {
                selectedNumberList = GetSelectedNumberFromList(ref ballNumberBag, ref selectedNumberList);
            }
            return selectedNumberList;

        }

        private static List<int> GetSelectedNumberFromList(ref List<int> ballNumberBag,ref List<int> selectedNumberList)
        {

            int numberSelected = new Random(DateTime.Now.Millisecond).Next(0, ballNumberBag.Count());

            selectedNumberList.Add(ballNumberBag[numberSelected]);

            ballNumberBag.RemoveAt(numberSelected);

            return selectedNumberList;
        }
    }
}
