using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingoApp.Factories
{
    public class Caller
    {
        public Entities.Caller caller;

        public Caller(int maxNumber)
        {
            caller = new Entities.Caller();
            caller.MaxNumber = maxNumber;
            caller.BallNumberBag = Services.Commons.RandomListGeneration.GetRandomListInRange(1, maxNumber, maxNumber);
            caller.CalledNumber = new List<int>();
        }
    }
}
