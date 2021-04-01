using AventStack.ExtentReports;
using AventStack.ExtentReports.MarkupUtils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MRO.ROI.Automation;
using MRO.ROI.Automation.Common.Navigation;
using MRO.ROI.Automation.Pages;
using MRO.ROI.Automation.Pages.Common;
using MRO.ROI.Automation.Pages.ROIFacility;
using MRO.ROI.Automation.Selenium;
using MRO.ROI.Test.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace MRO.ROI.Test.SmokeTests.ROIAdmin
{
    [TestClass]
    public class ROICDPasswordSpecification
    {

        [TestMethod]       
        public void ROI_CD_Password_Specification()
        {
            TestBase baseClass = new TestBase();
            try
            {
                baseClass.Init("ROIAdmin");
                Driver.logger = Driver.extent.CreateTest("ROI CD Password Specification");

                MenuSelector.SelectRoiAdmin("System", " Facility Policies ", TestBase.BaseWebDriver.Value);
               
               
                baseClass.Dispose();



            }
            catch (Exception ex)
            {
                Driver.logger.Log(Status.Fail, "Test failed with exception"); //Logging fail
                Driver.logger.Log(Status.Error, MarkupHelper.CreateTable(
                    new string[,]
                    {
                        {"Exception", ex.Message },
                        {"StackTrace", ex.StackTrace }
                    })); //Logging Error in a tabular format
                baseClass.Dispose();
                Assert.Fail(ex.Message);

            }
        }
    }
}
