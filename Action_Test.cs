using System;
using System.Windows.Forms;
using Eplan.EplApi.ApplicationFramework;
using Eplan.EplApi.DataModel;
using Eplan.EplApi.HEServices;

namespace Test.Action_test
{
    public class Action_Test : IEplAction
    {
        public bool OnRegister(ref string Name, ref int Ordinal)
        {
            Name = "ActionTest";
            Ordinal = 20;
            return true;
        }

        public bool Execute(ActionCallingContext oActionCallingContext)
        {
            SelectionSet Set = new SelectionSet();
            Project CurrentProject = Set.GetCurrentProject(true);
            string ProjectName = CurrentProject.ProjectName;
            string ProjectCompanyName = CurrentProject.Properties.PROJ_COMPANYNAME;
            DateTime ProjectCreationDate = CurrentProject.Properties.PROJ_CREATIONDATE;
            MessageBox.Show("Название проекта: " + ProjectName + "\n" + "Название фирмы: " + ProjectCompanyName +
                            "\n" + "Дата создания проекта: " + ProjectCreationDate.ToShortDateString());





            Project proj = new ProjectManager().CreateProject("$(MD_PROJECTS)\\Example_003.elk", "$(MD_TEMPLATES)\\IEC_bas003.zw9");

            // Первый лист
            PagePropertyList pagePropList = new PagePropertyList();
            pagePropList.DESIGNATION_PLANT = "ListTitle";
            pagePropList.DESIGNATION_LOCATION = "New_Schematic";
            pagePropList.PAGE_COUNTER = 1;

            Page page1 = new Page();
            page1.Create(proj, DocumentTypeManager.DocumentType.Circuit, pagePropList);

            // Второй лист
            PagePropertyList pagePropList1 = new PagePropertyList();
            pagePropList1.DESIGNATION_PLANT = "List First";
            pagePropList1.DESIGNATION_LOCATION = "New_Schematic";
            pagePropList1.PAGE_COUNTER = 2;

            Page page2 = new Page();
            page2.Create(proj, DocumentTypeManager.DocumentType.Circuit, pagePropList1);







            return true;


        }

        public void GetActionProperties(ref ActionProperties actionProperties)
        {
        }
    }
}