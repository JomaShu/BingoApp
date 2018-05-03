using NUnit.Framework;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace BingoAppTest.Steps
{
    [Binding]
    public class GeneratingBingoCardsSteps
    {
        List<BingoApp.Entities.Range> rangeList;
        BingoApp.Entities.BingoCard bingoCard;


        [Given(@"I have a Bingo card generator")]
        public void GivenIHaveABingoCardGenerator()
        {
            bingoCard = new BingoApp.Entities.BingoCard();
        }
        [When(@"I generate a Bingo card with (.*) spaces per row")]
        public void WhenIGenerateABingoCardWithSpacesPerRow(int spacesRow, Table table)
        {
            var dictionary = new Dictionary<string, string>();
            rangeList = new List<BingoApp.Entities.Range>();
            foreach (var row in table.Rows)
            {
                dictionary.Add(row[0], row[1]);
            }


            foreach (var row in dictionary)
            {
                BingoApp.Entities.Range  range = new BingoApp.Entities.Range();
                int lowerBound;
                bool lower = int.TryParse(row.Key, out lowerBound);
                int higherBound;
                bool higher = int.TryParse(row.Value, out higherBound);
                range.length = spacesRow;
                range.LowestBound = lowerBound;
                range.HighestBound = higherBound;
                rangeList.Add(range);
            }
            bingoCard = new BingoApp.Factories.BingoCard(table.Rows.Count, spacesRow, "Test", rangeList).bingoCard;
        }


        [Then(@"the generated card has (.*) unique spaces")]
        public void ThenTheGeneratedCardHasUniqueSpaces(string spaces)
        {
            int numSpaces;
            int.TryParse(spaces, out numSpaces);
            Assert.IsTrue(numSpaces == bingoCard.row * bingoCard.column);
            int a = bingoCard.mat.Length;
        }
        
        [Then(@"column \$column only contains numbers between \$lowerBound and \$upperBound inclusive")]
        public void ThenColumnColumnOnlyContainsNumbersBetweenLowerBoundAndUpperBoundInclusive(Table table)
        {
            var dictionary = new Dictionary<int, int>();
            foreach (var row in table.Rows)
            {
                int lower;
                int.TryParse(row[0], out lower);
                int higher;
                int.TryParse(row[1], out higher);
                dictionary.Add(lower, higher);
            }
            for(int r = 0; r < bingoCard.row; r++)
            {
                for(int c = 0; c < bingoCard.column; c++)
                {
                    if (r==2&& c==2)
                        Assert.IsTrue(bingoCard.mat[r, c] == 0);
                    else
                        Assert.IsTrue(bingoCard.mat[r,c] <= rangeList[r].HighestBound && bingoCard.mat[r, c] >= rangeList[r].LowestBound, "The number "+ bingoCard.mat[r, c] + " is out of range.");
                }
            }
        }
        
        [Then(@"the generated card has a FREE space in the middle")]
        public void ThenTheGeneratedCardHasaFREESpaceInTheMiddle()
        {
            Assert.IsTrue(bingoCard.mat[2, 2] == 0, "The bingo card has not got a free space");
        }
    }
}
