using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using BingoApp.Entities;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BingoAppTest
{
    [Binding]
    public class CallingBingoNumbersSteps
    {
        BingoApp.Entities.Caller caller;
        BingoApp.Entities.Range range;
        List<int> number;

        [Given(@"I have a Bingo caller")]
        public void GivenIHaveABingoCaller(Table table)
        {
            range = table.CreateInstance<BingoApp.Entities.Range>();
            caller = new BingoApp.Factories.Caller(range.length).caller;
        }
        
        [When(@"I call a number")]
        public void WhenICallANumber()
        {
            number = BingoApp.Services.Commons.RandomListGeneration.GetRandomListInRange(range.LowestBound, range.HighestBound, 1);
            Console.WriteLine(number);
        }
        
        [When(@"I call all numbers")]
        public void WhenICallANumberTimes()
        {
            foreach(int ball in caller.BallNumberBag)
            {
                Console.WriteLine(ball);
            }
        }

        [Then(@"the number is the following range inclusive:")]
        public void ThenTheNumberIsTheFollowingRangeInclusive(Table table)
        {
            var RangeTable = table.CreateInstance<BingoApp.Entities.Range>();
            Assert.IsTrue(number[0] >= RangeTable.LowestBound && number[0] <= RangeTable.HighestBound, "Sorry the number is not in range");
        }
        
        [Then(@"all numbers between are present")]
        public void ThenAllNumbersBetweenArePresent(Table table)
        {
            var RangeTable = table.CreateInstance<BingoApp.Entities.Range>();
            foreach (int num in caller.BallNumberBag)
            {
                Assert.IsTrue(num >= RangeTable.LowestBound && num <= RangeTable.HighestBound, "Sorry the number "+ num +" is not in range");

            }
        }

        [Then(@"no number has been called more than once")]
        public void ThenNoNumberHasBeenCalledMoreThanOnce()
        {
            caller.BallNumberBag.GroupBy(n => n).Any(c => c.Count() > 1);
        }
    }
}
