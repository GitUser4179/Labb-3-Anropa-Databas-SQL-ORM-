using Labb3.Data;
using Labb3.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Labb3.Menus
{
    public class ClassMenu
    {
        private readonly ChasGymnasieSkolaDb _context;
        private readonly StudentService _studentService;
        private MainMenu _mainMenu;
        private StudentMenu _studentMenu;
        private ClassService _classService;

        public ClassMenu(StudentService studentService, ClassService classService)
        {
            _studentService = studentService;
            _classService = classService;
            _context = new ChasGymnasieSkolaDb();
        }

        public void SetMenu(MainMenu mainMenu, StudentMenu studentMenu)
        {
            _mainMenu = mainMenu;
            _studentMenu = studentMenu;
        }

        public void ShowClassMenu()
        {
            var classList = _classService.GetClasses();
            var options = new List<MenuItem>();
            foreach (var c in (classList))
            {
                options.Add(new ActionMenuItem(c.ClassName, () => _studentService.DisplayStudentsInClass(c.ClassId)));
            }
            ;

            MenuHelper.CreateMenu("Select a class ID to choose from: ", options);
        }
        
        public void SelectClassForNewStudentMenu(string firstName, string lastName, string pin)
        {
            var classList = _classService.GetClasses();
            var options = new List<MenuItem>();
            foreach (var c in (classList))
            {
                options.Add(new ActionMenuItem(c.ClassName, () => _classService.AddStudent(firstName, lastName, pin, c)));
            };
            options.Add(new ActionMenuItem("Return to main menu", () => _mainMenu.ShowMainMenu()));

            MenuHelper.CreateMenu("Select a class to add the student to: ", options);
        }
    }
}
