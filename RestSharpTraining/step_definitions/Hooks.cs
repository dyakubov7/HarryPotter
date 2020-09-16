using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using RestSharpTraining.Utils;
using System.Xml.Serialization;
using System.Reflection;

namespace RestSharpTraining.step_definitions
{
    [Binding]
    public sealed class Hooks
    {
        protected static ExtentTest scenarioTest;
        private static ExtentReports Reports;
        protected static ExtentTest Test;
        private static string FeatureTitle;

       [BeforeTestRun]
        public static void setUp()
        {
            Reports = ReportingUtil.InitializeExtentReport("HarryPotter");
        }

        [BeforeFeature]
        public static void InItReports()
        {
            FeatureTitle = FeatureContext.Current.FeatureInfo.Title;
            //Test = Reports.CreateTest(FeatureTitle);
            ReportingUtil.test = Test;

        }

        [BeforeScenario]
        public static void InItScenarioReport()
        {
            scenarioTest = Reports.CreateTest<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);

        }

        
        [AfterStep]
        public static void WritingTestResults()
        {
            ScenarioContext scenarioContext = ScenarioContext.Current;
            string stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
            PropertyInfo propertyInfo = typeof(ScenarioContext).GetProperty("ScenarioExecutionStatus");
            MethodInfo getter = propertyInfo.GetGetMethod(nonPublic: true);
            object testResult = getter.Invoke(scenarioContext, null);
            string currentStepText = scenarioContext.StepContext.StepInfo.Text;

            //Pending status
            if (testResult.ToString().Equals("StepDefinitionPending"))
            {
                switch (stepType)
                {
                    case "Given":
                        scenarioTest.CreateNode<Given>(currentStepText).Skip("Step Definition Pending");
                        return;
                    case "When":
                        scenarioTest.CreateNode<When>(currentStepText).Skip("Step Definition Pending");
                        return;
                    case "Then":
                        scenarioTest.CreateNode<Then>(currentStepText).Skip("Step Definition Pending");
                        return;
                }
            }
            if (scenarioContext.TestError == null)
            {
                switch (stepType)
                {
                    case "Given":
                        scenarioTest.CreateNode<Given>("Given " + currentStepText);
                        break;
                    case "When":
                        scenarioTest.CreateNode<When>("When " + currentStepText);
                        break;
                    case "Then":
                        scenarioTest.CreateNode<Then>("Then " + currentStepText);
                        break;
                }
            }
            else
            {
                string testErrorMeassge = scenarioContext.TestError.Message;
                string testErrorStackTrace = scenarioContext.TestError.StackTrace;

                if (testErrorMeassge.Contains("Warning"))
                {
                    scenarioTest.CreateNode(currentStepText).Warning(testErrorMeassge);
                    return;
                }
                else
                {
                    switch (stepType)
                    {
                        case "Given":
                            scenarioTest.CreateNode<Given>("Given " + currentStepText).Fail(testErrorMeassge + " : " + testErrorStackTrace);
                            break;
                        case "When":
                            scenarioTest.CreateNode<When>("When " + currentStepText).Fail(testErrorMeassge + " : " + testErrorStackTrace);
                            break;
                        case "Then":
                            scenarioTest.CreateNode<Then>("Then " + currentStepText).Fail(testErrorMeassge + " : " + testErrorStackTrace);
                            break;
                    }
                }
            }
        }
        [AfterTestRun]
        public static void TearDownReport()
        {
            try
            {
                Reports.Flush();
            }catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

            }
}
