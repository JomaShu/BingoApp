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
    public class CheckingBingoCardsSteps
    {
        int rows;
        int columns;
        int LowestBound;
        int HighestBound;
        int numberOfPlayer;
        BingoApp.Entities.Caller caller;
        List<BingoApp.Entities.BingoCard> players;
        BingoApp.Entities.BingoCard player;
        List<BingoApp.Entities.Range> rowRangeList;
        bool Won;

        [Given(@"a player calls Bingo after all numbers on their card have been called")]
        public void GivenAPlayerCallsBingoAfterAllNumbersOnTheirCardHaveBeenCalled()
        {
            setADefaultGame();

            player = BingoApp.Services.NumberCaller.CallTestGame(players, caller);
        }

        [Given(@"a player calls Bingo before all numbers on their card have been called")]
        public void GivenAPlayerCallsBingoBeforeAllNumbersOnTheirCardHaveBeenCalled()
        {
            setADefaultGame();

            player = BingoApp.Services.NumberCaller.CallTestGame(players, caller,cheater:true);
        }
        
        [When(@"I check the card")]
        public void WhenICheckTheCard()
        {
            Won = BingoApp.Services.CheckBingoCard.CheckBingoCardCompleted(caller.CalledNumber, player.mat, player.row, player.column).Count() == (player.row * player.column) - 1 ? true : false;
        }
        
        [Then(@"the player is the winner")]
        public void ThenThePlayerIsTheWinner()
        {
            Assert.IsTrue(Won);

        }

        [Then(@"the player is not the winner")]
        public void ThenThePlayerIsNotTheWinner()
        {
            Assert.IsFalse(Won);

        }


        private void setADefaultGame()
        {
            rows = 5;
            columns = 5;
            LowestBound = 1;
            HighestBound = 75;
            numberOfPlayer = 2;

            caller = new BingoApp.Factories.Caller(HighestBound).caller;
            players = new List<BingoApp.Entities.BingoCard>();

            rowRangeList = BingoApp.Services.BingoCard.GetDefaultRange();

            for (int i = 1; i <= numberOfPlayer; i++)
            {
                player = new BingoApp.Factories.BingoCard(rows, columns, i.ToString(), rowRangeList).bingoCard;
                players.Add(player);
                BingoApp.Services.BingoCard.Print(player);
            }
        }

    }
}
