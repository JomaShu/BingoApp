using System.Collections.Generic;

namespace BingoApp.Entities
{
    public class Caller
    {
       public List<int> BallNumberBag { get; set; }
       public int MaxNumber { get; set; }
       public List<int> CalledNumber { get; set; }
    }
}