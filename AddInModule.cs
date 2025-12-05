using Eplan.EplApi.ApplicationFramework;
using Eplan.EplApi.Gui;
using Eplan.EplApi.Scripting;
using Eplan.EplApi.Base;
using System.ComponentModel.Design;

namespace Test
{
    public class AddInModule : IEplAddIn
    {
        public bool OnRegister(ref bool bLoadOnStart)
        {
            bLoadOnStart = true;
            return true;
        }

        public bool OnUnregister()
        {
            return true;
        }

        public bool OnInit()
        {
            return true;
        }

        public bool OnInitGui()
        {
            Menu OurMenu = new Menu();
            uint mainMenuId = OurMenu.AddMainMenu(
                "Тест2",                             // Название главного меню
                Menu.MainMenuName.eMainMenuUtilities, // Тип/категория меню
                "Кнопка",            // Подзаголовок или описание
                "ActionTest",                        // Ссылка на действие/метод при выборе
                "Имя проекта, фирмы и дата создания", // Дополнительная информация, подсказка
                1                                    // Порядковый номер или приоритет отображения
            );

            OurMenu.AddMenuItem(
                "Новая кнопка",
                "CreateFile",
                "Выполняется отчёт",
                mainMenuId,
                1,
                false,
                false
                );

            return true;
        }

        public bool OnExit()
        {
            return true;
        }
    }
}