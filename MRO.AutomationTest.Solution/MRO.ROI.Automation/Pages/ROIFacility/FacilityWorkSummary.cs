﻿using AventStack.ExtentReports;
using MRO.ROI.Automation.Common.Navigation;
using MRO.ROI.Automation.Selenium;
using MRO.ROI.Automation.Utility;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Diagnostics;
using WindowsInput.Native;

namespace MRO.ROI.Automation.Pages.ROIFacility
{
    public static class FacilityWorkSummary
    {
        private static string createdDateTime = DateTime.Now.ToString();
        public static string dateTime;
        public static object ROIRequestsTopMenu;
        //private static double timeOut;
        //private static object Browser;

        public static bool IsAtLogNewRequestPage
        {
            get
            {
                //TODO: var LogNewRequestPageLabel = Driver.Instance.FindElement(By.XPath("//td[contains(text(), 'Log a New Request')]"));
                return true;//LogNewRequestPageLabel.Text == "Log a New Request";
            }
        }

        public static bool NewRequestCreated
        {
            get
            {
                //TODO: Logic to confirm that a new request was created
                return true;
            }
        }

        public static void GoToLogNewRequestPage()
        {
            Driver.logger.Log(Status.Pass, "Go to log New Request Page");
            FacilityMenuNavigation.ROIRequests.LogNewRequest.Select();
        }
        public static void GoToLogNewRequestPage1()
        {
            InternalUserNavigation.CreateARequest.CreateAPortalRequest.Select();
        }
        public static void facillogoutbutton()
        {
            // Driver.Wait(TimeSpan.FromSeconds(5));
            var loutbutton = Driver.Instance.FindElement(By.Id(PageElements.FacilityWorkSummaryPage.facillogoutbtn_id));
            loutbutton.Click();
            //  var loutbutton = Driver.Instance.FindElement(By.Id(PageElements.FacilityWorkSummaryPage.facillogoutbtn_id));
        }
        public static bool ClickMRODeliveryTab()
        {
            DebugUtil.DebugMessage(Driver.Instance.Scripts().ExecuteScript("return document.readyState").ToString());

            DebugUtil.DebugMessage("Create MRO Delivery request");

            //check if tab is already selected
            if (WebElementHelper.IsElementPresent(PageElements.LogNewRequestPage.mroDelSelectionTest_xpath))
                return true;

            Driver.Instance.FindElement(By.XPath(PageElements.LogNewRequestPage.mroDelivery_xpath)).Click();
            Driver.Wait(TimeSpan.FromSeconds(2));
            return WebElementHelper.IsElementPresent(PageElements.LogNewRequestPage.mroDelSelectionTest_xpath);
        }


        public static void FillNewMRODeliveryRequest()
        {
            ////2/14/2019
            //   var facilMroDelivery = Driver.Instance.FindElement(By.XPath(PageElements.LogNewRequestPage.mroDelivery_xpath));
            //  facilMroDelivery.Click();
            Driver.logger.Log(Status.Info, "Create A New MRO Delivery Request.");
            Driver.Instance.FindElement(By.Id(PageElements.LogNewRequestPage.firstName_Id)).SendKeys("FN" + createdDateTime);
            Driver.logger.Log(Status.Info, "First Name entered.");
            Driver.Instance.FindElement(By.Id(PageElements.LogNewRequestPage.lastName_Id)).SendKeys("LN" + createdDateTime);
            Driver.logger.Log(Status.Info, "Last Name entered.");
            Driver.Instance.FindElement(By.Id(PageElements.LogNewRequestPage.dateOfBith_Id)).SendKeys("11/11/1990");
            Driver.logger.Log(Status.Info, "DOB Entered.");
            // DebugUtil.DebugMessage("Basic information added");

            var locationDropDown = Driver.Instance.FindElement(By.Id(PageElements.LogNewRequestPage.locationDropDown_id));
            locationDropDown.Click();
            Driver.logger.Log(Status.Pass, "Location Selected To Boston Proper.");
            Driver.Wait(TimeSpan.FromSeconds(2));

            var locationItem = locationDropDown.FindElement(By.XPath("//div[@id='mrocontent_lstLocation_DropDown']/div/ul/li[text()='Boston Proper']"));
            locationItem.Click();
            DebugUtil.DebugMessage("Location selected");

            //IgnoreDuplicates();

            Driver.Instance.FindElement(By.Id("mrocontent_txtRequestRcvdDate")).SendKeys(DateTime.Now.ToShortDateString());
            WebElementHelper.ScrollIntoView("mrocontent_cmdLogRequest", FindElementBy.Id);
            Driver.Wait(TimeSpan.FromSeconds(5));
            Driver.Instance.FindElement(By.Id("mrocontent_cmdLogRequest")).Click();
            Driver.Wait(TimeSpan.FromSeconds(5));

            ScannerUtil.ScanDocuments();
            Driver.logger.Log(Status.Pass, "Documents scanned.");
            //  DebugUtil.DebugMessage("Documents scanned");
        }

        public static bool ClickOnSiteDeliveryTab()
        {
            DebugUtil.DebugMessage(Driver.Instance.Scripts().ExecuteScript("return document.readyState").ToString());

            //   DebugUtil.DebugMessage("Create Onsite Delivery request");
            Driver.logger.Log(Status.Info, "Create Onsite Delivery request.");
            //check if tab is already selected
            if (WebElementHelper.IsElementPresent(PageElements.LogNewRequestPage.onsitedeliverySelectionTest_xpath))
                return true;

            Driver.Instance.FindElement(By.XPath(PageElements.LogNewRequestPage.onsitedelivery_xpath)).Click();
            Driver.Wait(TimeSpan.FromSeconds(2));
            return WebElementHelper.IsElementPresent(PageElements.LogNewRequestPage.onsitedeliverySelectionTest_xpath);
        }

        public static void CreateNewOnsiteDeliveryRequest()
        {
            //Driver.Instance.FindElement(By.XPath(PageElements.LogNewRequestPage.onsitedelivery_xpath)).Click();
            Driver.Instance.FindElement(By.Id(PageElements.LogNewRequestPage.firstName_Id)).SendKeys("FN" + createdDateTime);
            Driver.logger.Log(Status.Info, "First Name entered.");
            Driver.Instance.FindElement(By.Id(PageElements.LogNewRequestPage.lastName_Id)).SendKeys("LN" + createdDateTime);
            Driver.logger.Log(Status.Info, "Last Name entered.");
            Driver.Instance.FindElement(By.Id(PageElements.LogNewRequestPage.dateOfBith_Id)).SendKeys("11/11/1990");
            Driver.logger.Log(Status.Info, "DOB Entered.");

            var locationDropDown = Driver.Instance.FindElement(By.Id(PageElements.LogNewRequestPage.locationDropDown_id));
            locationDropDown.Click();
            Driver.Wait(TimeSpan.FromSeconds(2));
            var locationItem = locationDropDown.FindElement(By.XPath("//div[@id='mrocontent_lstLocation_DropDown']/div/ul/li[text()='Boston Proper']"));
            locationItem.Click();
            Driver.logger.Log(Status.Info, "Location. " + locationItem);
            Driver.Wait(TimeSpan.FromSeconds(2));
            IgnoreDuplicates();

            Driver.Instance.FindElement(By.Id(PageElements.LogNewRequestPage.requestRecievedDate_Id)).SendKeys(DateTime.Now.ToShortDateString());
            SelectElement oSelect = new SelectElement(Driver.Instance.FindElement(By.Id(PageElements.LogNewRequestPage.requesterType_Id)));
            // oSelect.SelectByText("Patient"); Provider
            oSelect.SelectByText("Provider");

            Driver.Instance.FindElement(By.Id(PageElements.LogNewRequestPage.logRequestBtn_Id)).Click();
            Driver.Wait(TimeSpan.FromSeconds(5));

            ScannerUtil.ScanDocuments();
        }

        public static bool ClickInternalPortalTab()
        {
            DebugUtil.DebugMessage(Driver.Instance.Scripts().ExecuteScript("return document.readyState").ToString());

            DebugUtil.DebugMessage("Create Internal Portal request");

            //check if tab is already selected
            if (WebElementHelper.IsElementPresent(PageElements.LogNewRequestPage.internalportalSelectionTest_xpath))
                return true;

            Driver.Instance.FindElement(By.XPath(PageElements.LogNewRequestPage.internalportalbtn_xpath)).Click();
            Driver.Wait(TimeSpan.FromSeconds(2));
            return WebElementHelper.IsElementPresent(PageElements.LogNewRequestPage.internalportalSelectionTest_xpath);
        }



        public static void IgnoreDuplicates()
        {
            if (Driver.Instance.FindElements(By.Id(PageElements.LogNewRequestPage.ignoreDuplicatesChk_Id)).Count != 0)
            {
                Driver.Instance.FindElement(By.Id(PageElements.LogNewRequestPage.ignoreDuplicatesChk_Id)).Click();
            }
        }

        public static void GoToRequestStatusPage()
        {
            Driver.Wait(TimeSpan.FromSeconds(5));
            Driver.Instance.FindElement(By.Id(PageElements.LogNewRequestPage.requestStatusButton_Id)).Click();
        }


        public static void RequestStatus()
        {

            Driver.Wait(TimeSpan.FromSeconds(5));
            var requestStatusButton = Driver.Instance.FindElement(By.Id(PageElements.LogNewRequestPage.requestStatusButton_Id));
            requestStatusButton.Click();

        }


        public static void ScanPatientPages()
        {
            click_action();
            Debug.WriteLine("scan button clicked");
        }

        private static IWebElement getElement(string v)
        {
            return Driver.Instance.FindElement(By.Id(v));

        }

        private static void click_action()
        {
            var btn = Driver.Instance.FindElement(By.Id(PageElements.LogNewRequestPage.scanButton_Id));
            Actions action = new Actions(Driver.Instance);
            action.Click(btn).Build().Perform();
        }



        public static void acceptalert()
        {
            Driver.Instance.SwitchTo().Alert().Accept();
        }

        public static void PatientNameValidation()
        {
            //Pending needs to implement assert validation.
            string patientname = Driver.Instance.FindElement(By.Id("mrocontent_tdPatientName")).Text;
            // test.info("Request ID: " + reqeustid);
            Console.WriteLine("Fn" + dateTime + " Ln" + dateTime);
            Console.WriteLine(patientname);

            if (patientname.Equals("Fn" + dateTime + " Ln" + dateTime))
            {
                Console.WriteLine("patientname passed");
            }
            else
            {
                Console.WriteLine("patientname failed");

            }
            string dobvalidation = Driver.Instance.FindElement(By.Id(PageElements.LogNewRequestPage.dobvalidation_id)).Text;
            Console.WriteLine(dobvalidation);
            if (dobvalidation.Equals("11/11/1990"))
            {
                Console.WriteLine("date of birth passed");
            }
            else
            {
                Console.WriteLine("date of birth failed");

            }

            string deliverymethod = Driver.Instance.FindElement(By.Id(PageElements.LogNewRequestPage.dlvymethod_id)).Text;
            Console.WriteLine(deliverymethod);

            if (deliverymethod.Equals(""))
            {

            }

            Driver.Wait(TimeSpan.FromSeconds(5));
        }

        public static void DeliverMedicalRecordOnsite()
        {

            string balanceDue = Driver.Instance.FindElement(By.XPath(PageElements.LogNewRequestPage.balancedue_xpath)).Text;
            Driver.Wait(TimeSpan.FromSeconds(5));

        }
        public static void Dlvfaxonsite()
        {
            Driver.Instance.FindElement(By.Id(PageElements.FacilityRequestStatusPage.deliverfaxosdnow_id)).Click();
            Driver.Wait(TimeSpan.FromSeconds(5));
            Driver.Instance.FindElement(By.XPath(PageElements.LogNewRequestPage.dlvymethod_xpath)).Click();
            Driver.Wait(TimeSpan.FromSeconds(2));
            var stroredonpaper = Driver.Instance.FindElement(By.Id(PageElements.LogNewRequestPage.storedonpaper_id));
            stroredonpaper.SendKeys("10");
            var storedelectronically = Driver.Instance.FindElement(By.Id(PageElements.LogNewRequestPage.storedelectronically_id));
            storedelectronically.SendKeys("10");
            var creaeinvoicebtn = Driver.Instance.FindElement(By.Id(PageElements.LogNewRequestPage.createinvoiceButton_id));
            creaeinvoicebtn.Click();
            string balanceDue = Driver.Instance.FindElement(By.XPath(PageElements.LogNewRequestPage.balancedue_xpath)).Text;
            Driver.Wait(TimeSpan.FromSeconds(5));

        }

        public static void SendEnterKey()
        {
            Debug.WriteLine("Accept the scan");
            Driver.Wait(TimeSpan.FromSeconds(10));
            InputSimulator simulator = new InputSimulator();
            simulator.Keyboard.KeyPress(VirtualKeyCode.RETURN);
            //  Driver.Wait(TimeSpan.FromSeconds(5));
            //       VK_ENTER);
            //    simulator.Keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_T);

            Driver.Wait(TimeSpan.FromSeconds(15));

            //      simulator.Keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_A);

        }

        public static void Facillogoutbutton()
        {
            Driver.Wait(TimeSpan.FromSeconds(5));
            var loutbutton = Driver.Instance.FindElement(By.Id(PageElements.LogNewRequestPage.facillogoutbtn_id));
            loutbutton.Click();

        }

        public static void extportallogoutbtn()
        {
            Driver.Wait(TimeSpan.FromSeconds(5));
            var extportallogoutbtn = Driver.Instance.FindElement(By.Id(PageElements.ROIRequesterPortal.extportalLogoutbtn_xpath));
            extportallogoutbtn.Click();

        }
        public static void mroToOnsite()
        {
            string deliverymethod = Driver.Instance.FindElement(By.Id("mrocontent_lblRequestType")).Text;
            Console.WriteLine("Current Delivery Method Set To #" + deliverymethod);
            // logger.Log(Status.Pass, "Sucessfully Logged Out From Facility.");
            Driver.Wait(TimeSpan.FromSeconds(2));
            Driver.Instance.FindElement(By.Id(PageElements.LogNewRequestPage.changedlvymethod_id)).Click();
            Driver.Wait(TimeSpan.FromSeconds(2));
            SelectElement objSelect = new SelectElement(Driver.Instance.FindElement(By.Id("mrocontent_lstChanges")));
            objSelect.SelectByText("Change to On-Site");
            Driver.Wait(TimeSpan.FromSeconds(5));
            string deliverymethod1 = Driver.Instance.FindElement(By.Id("mrocontent_lblRequestType")).Text;
            Console.WriteLine("Check Delivery Type Change from MRO To # " + deliverymethod1);
            Driver.Wait(TimeSpan.FromSeconds(5));
            Driver.Instance.FindElement(By.Id(PageElements.LogNewRequestPage.sendmsgmrobtn_id)).Click();
            Driver.Wait(TimeSpan.FromSeconds(2));
            SelectElement objSelect1 = new SelectElement(Driver.Instance.FindElement(By.Id("mrocontent_lstActions")));
            objSelect1.SelectByText("No Authorization Required");
            Driver.Instance.FindElement(By.Id(PageElements.LogNewRequestPage.sendmsgmrotxt_id)).SendKeys("Test Message to MRO");
            Driver.Wait(TimeSpan.FromSeconds(2));

            //  Assert.assertTrue(objSelect == objSelect);

        }

        public static void ReqPreAuthChngDlvymroToOnsite()
        {
            string deliverymethod = Driver.Instance.FindElement(By.Id("mrocontent_lblRequestType")).Text;
            Console.WriteLine("Current Delivery Method Set To #" + deliverymethod);
            // logger.Log(Status.Pass, "Sucessfully Logged Out From Facility.");
            Driver.Wait(TimeSpan.FromSeconds(2));
            Driver.Instance.FindElement(By.Id(PageElements.LogNewRequestPage.changedlvymethod_id)).Click();
            Driver.Wait(TimeSpan.FromSeconds(2));
            SelectElement objSelect = new SelectElement(Driver.Instance.FindElement(By.Id("mrocontent_lstChanges")));
            objSelect.SelectByText("Change to On-Site");
            Driver.Wait(TimeSpan.FromSeconds(5));
            string deliverymethod1 = Driver.Instance.FindElement(By.Id("mrocontent_lblRequestType")).Text;
            Console.WriteLine("Check Delivery Type Change from MRO To # " + deliverymethod1);
            Driver.Wait(TimeSpan.FromSeconds(5));
            //  Assert.assertTrue(objSelect == objSelect);

        }
        public static void IntPortalReqPreAuthChngDlvyIntToMRO()
        {
            string deliverymethod = Driver.Instance.FindElement(By.Id("mrocontent_lblRequestType")).Text;
            Console.WriteLine("Current Delivery Method Set To #" + deliverymethod);
            // logger.Log(Status.Pass, "Sucessfully Logged Out From Facility.");
            Driver.Wait(TimeSpan.FromSeconds(2));
            Driver.Instance.FindElement(By.Id(PageElements.LogNewRequestPage.changedlvymethod_id)).Click();
            Driver.Wait(TimeSpan.FromSeconds(2));
            SelectElement objSelect = new SelectElement(Driver.Instance.FindElement(By.Id("mrocontent_lstChanges")));
            objSelect.SelectByText("Change to MRO Delivery");
            Driver.Wait(TimeSpan.FromSeconds(5));
            string deliverymethod1 = Driver.Instance.FindElement(By.Id("mrocontent_lblRequestType")).Text;
            Console.WriteLine("Check Delivery Type Change from Internal To # " + deliverymethod1);
            Driver.Wait(TimeSpan.FromSeconds(5));
            //  Assert.assertTrue(objSelect == objSelect);

        }
        //Testing new function to handle click funtionaity.
        private static void facclick_action()
        {
            var btn = Driver.Instance.FindElement(By.XPath("//*[@id=\"actLink\"]"));
            Actions action = new Actions(Driver.Instance);
            action.Click(btn).Build().Perform();
        }

        public static void FacWorkSummaryActionList()
        {
            Driver.Wait(TimeSpan.FromSeconds(5));
            string test = Driver.Instance.FindElement(By.XPath(PageElements.FacilityWorkSummaryPage.facililtyworksummary_xpath)).Text;
            Driver.logger.Log(Status.Info, "Print The Page Information: " + test);

            Driver.Wait(TimeSpan.FromSeconds(5));
            Driver.Instance.SwitchTo().Frame(0);
            Driver.Wait(TimeSpan.FromSeconds(2));
            Driver.Instance.SwitchTo().Frame("srActionList");
            Driver.Wait(TimeSpan.FromSeconds(2));
            Console.Write(Driver.Instance.FindElements(By.XPath("//*[@id='div-panel-container']/a/div/span[1]")).Count);

            IWebElement rowsoutside = Driver.Instance.FindElement(By.XPath("//*[@id='div-panel-container']/a/div/span[1]"));
            string rowsoutsidetext = rowsoutside.Text;

            Driver.logger.Log(Status.Info, "Print Number of rows from Quaderent: " + rowsoutsidetext);

            Driver.Instance.FindElement(By.Id("div-panel-container")).Click();


            Driver.Wait(TimeSpan.FromSeconds(15));
            Driver.Instance.SwitchTo().DefaultContent();
            string test1 = Driver.Instance.FindElement(By.XPath(PageElements.FacilityWorkSummaryPage.facActionListPage_xpath)).Text;
            Driver.logger.Log(Status.Info, "Print Page Information: " + test1);
            // Driver.logger.Log(Status.Info, "Switched to Default frame and successfully landed on Action List Page");

            IWebElement rowsinside = Driver.Instance.FindElement(By.Id("mrocontent_MROReportGridBanner_lblRows"));
            Driver.logger.Log(Status.Info, "Print Number of rows from the Report: " + rowsinside.Text);
            Driver.Wait(TimeSpan.FromSeconds(30));



            if (rowsoutsidetext.Equals(rowsinside.Text))
            {
                Driver.logger.Log(Status.Pass, "Quadarent and report records matches ");
            }
            else
            {
                Driver.logger.Log(Status.Fail, "Quadarent and report records did not matches ");
            }

        }




        public static void FacWorkSummaryDocumentRequired()
        {
            Driver.Wait(TimeSpan.FromSeconds(5));
            string test = Driver.Instance.FindElement(By.XPath(PageElements.FacilityWorkSummaryPage.facililtyworksummary_xpath)).Text;
            Driver.logger.Log(Status.Info, "Print The Page Information: " + test);

            Driver.Wait(TimeSpan.FromSeconds(5));
            Driver.Instance.SwitchTo().Frame(0);
            Driver.Wait(TimeSpan.FromSeconds(2));

            Driver.Instance.SwitchTo().Frame("srDocsRequired");

            Driver.Wait(TimeSpan.FromSeconds(2));
            //   Driver.Instance.SwitchTo().Frame(1);
            //  worksummarydocreqid_id admindocrequest_id
            string link = Driver.Instance.FindElement(By.Id(PageElements.ROIAdminList.worksummarydocreqid_id)).Text;
            Console.WriteLine(link);
            Driver.logger.Log(Status.Info, "Print Number of rows from On Report: " + link);

            //string link1 = Driver.Instance.FindElement(By.Id(PageElements.ROIAdminList.admindocrequest_xpath)).Text;
            //Console.WriteLine(link1);
            //Driver.logger.Log(Status.Info, "Print Number of rows from On Report: " + link1);


            //Driver.Wait(TimeSpan.FromSeconds(10));
            // IWebElement rowsoutside = Driver.Instance.FindElement(By.XPath("//*[contains(@href,'Facility/ReportsTel.aspx?page=DocsRequired2')]"));
            IWebElement rowsoutside = Driver.Instance.FindElement(By.Id(PageElements.ROIAdminList.worksummarydocreqid_id));
            rowsoutside.Click();
            Driver.Wait(TimeSpan.FromSeconds(5));
            Driver.Instance.SwitchTo().DefaultContent();

            IWebElement rowsinside = Driver.Instance.FindElement(By.XPath(PageElements.ROIAdminList.admindocreqtotal_xpath));
            Driver.logger.Log(Status.Info, "Print Number of rows from On Report: " + rowsinside.Text);
            Driver.Wait(TimeSpan.FromSeconds(30));


            if (rowsinside.Text.Contains(link))
            {
                Driver.logger.Log(Status.Pass, "Outside and Inside row matches ");
            }
            else
            {
                Driver.logger.Log(Status.Fail, "Outside and Inside row does not matches ");
            }
            Driver.Instance.FindElement(By.XPath(PageElements.LogNewRequestPage.mroDelivery_xpath)).Click();
            Driver.Wait(TimeSpan.FromSeconds(10));
            rowsinside = Driver.Instance.FindElement(By.XPath(PageElements.ROIAdminList.admindocreqtotal_xpath));
            Driver.logger.Log(Status.Info, "Print Number of rows from On MRO delevery: " + rowsinside.Text);
            Driver.Wait(TimeSpan.FromSeconds(5));
            Driver.Instance.FindElement(By.XPath(PageElements.LogNewRequestPage.onsitedelivery_xpath)).Click();
            Driver.Wait(TimeSpan.FromSeconds(10));
            rowsinside = Driver.Instance.FindElement(By.XPath(PageElements.ROIAdminList.admindocreqtotal_xpath));
            Driver.logger.Log(Status.Info, "Print Number of rows from On-Site Delivery: " + rowsinside.Text);
            Driver.Instance.FindElement(By.XPath(PageElements.LogNewRequestPage.internalportalbtn_xpath)).Click();
            Driver.Wait(TimeSpan.FromSeconds(10));
            rowsinside = Driver.Instance.FindElement(By.XPath(PageElements.ROIAdminList.admindocreqtotal_xpath));
            Driver.logger.Log(Status.Info, "Print Number of rows from Internal Portal: " + rowsinside.Text);
            Driver.Instance.FindElement(By.XPath(PageElements.LogNewRequestPage.billingofficebtn_xpath)).Click();
            Driver.Wait(TimeSpan.FromSeconds(10));
            rowsinside = Driver.Instance.FindElement(By.XPath(PageElements.ROIAdminList.admindocreqtotal_xpath));
            Driver.logger.Log(Status.Info, "Print Number of rows from Internal Portal: " + rowsinside.Text);

            Driver.Instance.FindElement(By.XPath(PageElements.LogNewRequestPage.billingofficebtn_xpath)).Click();
            Driver.Wait(TimeSpan.FromSeconds(10));
            rowsinside = Driver.Instance.FindElement(By.XPath(PageElements.ROIAdminList.admindocreqtotal_xpath));
            Driver.logger.Log(Status.Info, "Print Number of rows from Billing Office: " + rowsinside.Text);
            Driver.Instance.FindElement(By.XPath(PageElements.LogNewRequestPage.docrequiredall_xpath)).Click();
            Driver.Wait(TimeSpan.FromSeconds(10));
            rowsinside = Driver.Instance.FindElement(By.XPath(PageElements.ROIAdminList.admindocreqtotal_xpath));
            Driver.logger.Log(Status.Info, "Print Number of rows from All: " + rowsinside.Text);


            if (rowsinside.Text.Contains(link))
            {
                Driver.logger.Pass("number of rows are the same");
            }

        }


        public static void FacWorkSummaryEletronicRequest(string outsideXpath, string insideXpath)
        {
            Driver.Instance.SwitchTo().DefaultContent();
            Driver.Wait(TimeSpan.FromSeconds(5));
            Driver.Instance.SwitchTo().Frame(0);
            Driver.Wait(TimeSpan.FromSeconds(2));
            Driver.Instance.SwitchTo().Frame("srElectronicRequests");
            Driver.Wait(TimeSpan.FromSeconds(2));
            IWebElement rowsoutside = Driver.Instance.FindElement(By.XPath(outsideXpath));
            string rowsoutsideText = rowsoutside.Text;
            Driver.logger.Log(Status.Info, "Print Number of rows from Electronic Requests: " + rowsoutsideText);
            rowsoutside.Click();
            IWebElement rowsinside = Driver.Instance.FindElement(By.XPath(insideXpath));
            Driver.logger.Log(Status.Info, "Print Number of rows No Request Document(s) Scanned: " + rowsinside.Text);
            if (rowsinside.Text.Contains(rowsoutsideText))
            {
                Driver.logger.Pass("number of rows are the same");
            }
            Driver.Instance.Navigate().Back();
        }


        public static void worksummarydocrequirednoscan()
        {
            Driver.Instance.SwitchTo().DefaultContent();

            Driver.Wait(TimeSpan.FromSeconds(5));
            Driver.Instance.SwitchTo().Frame(0);
            Driver.Wait(TimeSpan.FromSeconds(2));

            Driver.Instance.SwitchTo().Frame("srDocsRequired");

            Driver.Wait(TimeSpan.FromSeconds(2));
            //  internal const string worksummarynoscanid_id = "no-request-docs-scanned";
            //WebElementHelper.ScrollIntoView("imgAjaxSetPanelClass");
            IWebElement rowsoutside = Driver.Instance.FindElement(By.XPath("//*[@id='no-request-docs-scanned']/span"));
            string rowsoutsideText = rowsoutside.Text;
            Driver.logger.Log(Status.Info, "Print Number of rows from Internal Portal: " + rowsoutsideText);

            rowsoutside.Click();

            IWebElement rowsinside = Driver.Instance.FindElement(By.XPath(PageElements.ROIAdminList.admindocreqtotal_xpath));
            Driver.logger.Log(Status.Info, "Print Number of rows No Request Document(s) Scanned: " + rowsinside.Text);


            if (rowsinside.Text.Contains(rowsoutsideText))
            {
                Driver.logger.Pass("number of rows are the same");
            }
        }
    }
}
