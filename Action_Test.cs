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

            int page_number = 0;
            
            MessageBox.Show("Создание проэкта", "Окно");
            // Создание проэкта
            Project proj = new ProjectManager().CreateProject("$(MD_PROJECTS)\\ProjectFirst.elk", "$(MD_TEMPLATES)\\IEC_bas003.zw9");

            // Первый лист
            PagePropertyList pagePropList = new PagePropertyList();
            //pagePropList.DESIGNATION_PLANT = "List_First";
            //pagePropList.DESIGNATION_LOCATION = "New_Schematic";
            pagePropList.PAGE_COUNTER = page_number++;

            Page page1 = new Page();
            page1.Create(proj, DocumentTypeManager.DocumentType.TitlePage, pagePropList);

            

            MessageBox.Show("Первый проэкт создан", "Окно");

            // Второй лист
            PagePropertyList pagePropList1 = new PagePropertyList();

            for (int i = 1; i < 5; i++)
            {
                
                //pagePropList1.DESIGNATION_PLANT = "List_Circuit";
                //pagePropList1.DESIGNATION_LOCATION = "Lol";
                pagePropList1.PAGE_COUNTER = page_number++;

                Page page2 = new Page();
                page2.Create(proj, DocumentTypeManager.DocumentType.Circuit, pagePropList1);
            }

            
            

            MessageBox.Show("Второй проэкт создан", "Окно");


            // Второй лист
            PagePropertyList pagePropList3 = new PagePropertyList();
            //pagePropList3.DESIGNATION_PLANT = "List_Overview";
            //pagePropList3.DESIGNATION_LOCATION = "XOXOL";
            pagePropList3.PAGE_COUNTER = page_number++;

            Page page3 = new Page();
            page3.Create(proj, DocumentTypeManager.DocumentType.Overview, pagePropList3);

            MessageBox.Show("Третий проэкт создан", "Окно");

            /*
            Page targetPage = null;
            foreach (Page page in proj.Pages)
            {
                if (page.Properties.PAGE_COUNTER == "2") // ищем страницу 2
                {
                    targetPage = page;
                    break;
                }
            }


            if (targetPage != null)
            {
                // Изменяем свойства
                targetPage.Properties.PAGE_REVISION_APPROVEDBY = "Иванов И.И.";
                targetPage.Properties.PAGE_DESCRIPTION = "Силовая часть шкафа А1";
                targetPage.Properties.DESIGNATION_LOCATION = "Power_Supply"; // ← Осторожно! (см. ниже)

                // Пример: дата утверждения (в формате YYYYMMDD)
                targetPage.Properties.PAGE_REVISION_DATEAPPROVED = "20251206";

                MessageBox.Show("Свойства листа успешно обновлены!");
            }
            else
            {
                MessageBox.Show("Страница не найдена!");
            }
            */





            return true;


        }

        public void GetActionProperties(ref ActionProperties actionProperties)
        {
        }
    }
}