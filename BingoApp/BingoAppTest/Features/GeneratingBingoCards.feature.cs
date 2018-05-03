﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.3.2.0
//      SpecFlow Generator Version:2.3.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace BingoAppTest.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.3.2.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("GeneratingBingoCards")]
    public partial class GeneratingBingoCardsFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "GeneratingBingoCards.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "GeneratingBingoCards", "\tAs a VP of Gaming\r\n\tI want my game to generate random Bingo cards\r\n\tSo that peop" +
                    "le can play", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Generate Bingo Card")]
        [NUnit.Framework.CategoryAttribute("mytag")]
        public virtual void GenerateBingoCard()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Generate Bingo Card", new string[] {
                        "mytag"});
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
 testRunner.Given("I have a Bingo card generator", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "LowerBound",
                        "UpperBound"});
            table1.AddRow(new string[] {
                        "1",
                        "15"});
            table1.AddRow(new string[] {
                        "16",
                        "30"});
            table1.AddRow(new string[] {
                        "31",
                        "45"});
            table1.AddRow(new string[] {
                        "46",
                        "60"});
            table1.AddRow(new string[] {
                        "61",
                        "75"});
#line 9
 testRunner.When("I generate a Bingo card with 5 spaces per row", ((string)(null)), table1, "When ");
#line 16
 testRunner.Then("the generated card has 25 unique spaces", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "LowerBound",
                        "UpperBound"});
            table2.AddRow(new string[] {
                        "1",
                        "15"});
            table2.AddRow(new string[] {
                        "16",
                        "30"});
            table2.AddRow(new string[] {
                        "31",
                        "45"});
            table2.AddRow(new string[] {
                        "46",
                        "60"});
            table2.AddRow(new string[] {
                        "61",
                        "75"});
#line 17
 testRunner.And("column $column only contains numbers between $lowerBound and $upperBound inclusiv" +
                    "e", ((string)(null)), table2, "And ");
#line 24
 testRunner.And("the generated card has a FREE space in the middle", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
