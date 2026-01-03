using System;
using System.Linq;
using Labb3; // Namespace for your DbContext and entities
using Labb3.Data;
using Labb3.Service;

namespace Labb3.Menus
{
    public class MainMenu
    {
        private readonly StudentMenu _studentMenu;
        private readonly ClassMenu _classMenu;
        private readonly StaffMenu _staffMenu;
        public MainMenu(StudentMenu studentMenu, ClassMenu classMenu, StaffMenu staffMenu)
        {
            _studentMenu = studentMenu;
            _classMenu = classMenu;
            _staffMenu = staffMenu;
        }

        public void ShowMainMenu()
        {
            var options = new List<MenuItem>
            {
                new ActionMenuItem("Show all students", () => _studentMenu.ShowStudentsOrderMenu()),
                new ActionMenuItem("Show students in X Class", () => _classMenu.ShowClassMenu()),
                new ActionMenuItem("Add a new student", () => _studentMenu.ShowAddStudentMenu()),
                new ActionMenuItem("Show staff list", () => _staffMenu.ShowStaffMenu()),
                new ActionMenuItem("Add new staff member", () => _staffMenu.ShowAddStaffMenu()),
                new ActionMenuItem("Exit", () => Environment.Exit(0))
            };

            MenuHelper.CreateMenu("Choose a menu option: ", options);
        }
    }
}
