using MRO.ROI.Automation.Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;


namespace MRO.ROI.Automation.Pages.ROIAdmin
{ 
    public class ROIFacilityPoliciesPage
    {

        public void SelectFacility()
        {
            SelectElement oSelect1 = new SelectElement(Driver.Instance.FindElement(By.Id("mrocontent_custFacilityPolicySelector_ddlFacility_Input")));
            oSelect1.SelectByText("Duke University Health System");

        }

        public void SelectLocation()
        {
            SelectElement oSelect1 = new SelectElement(Driver.Instance.FindElement(By.Id("mrocontent_custFacilityPolicySelector_ddlFacility_Input")));
            oSelect1.SelectByText("Duke University Health System");

        }
    }
}
