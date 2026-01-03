using Labb3.Data;
using Labb3.Service;
using Labb3.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Labb3.Menus
{
    public class StaffMenu
    {
        private readonly ChasGymnasieSkolaDb _context;
        private MainMenu _mainMenu;
        private StaffService _staffService;

        public StaffMenu(StaffService staffService)
        {
            _context = new ChasGymnasieSkolaDb();
            _staffService = staffService;
        }

        public void SetMenu(MainMenu mainMenu)
        {
            _mainMenu = mainMenu;
        }

        public void ShowStaffMenu()
        {
            var options = new List<MenuItem>
            {
                new ActionMenuItem("All staff", () => DisplayStaffInfo("All")),
                new ActionMenuItem("All teachers", () => DisplayStaffInfo("Teacher")),
                new ActionMenuItem("All counselors", () => DisplayStaffInfo("Counselor")),
                new ActionMenuItem("All administrators", () => DisplayStaffInfo("Administrator")),
                new ActionMenuItem("Back to main menu", () => _mainMenu.ShowMainMenu())
            };

            MenuHelper.CreateMenu("Select a category of staff to view: ", options);
        }

        public void DisplayStaffInfo(string selectedCategory)
        {
            var staffList = _staffService.GetStaff();
            Console.Clear();
            Console.WriteLine("List of staff members: ");
            foreach (Staff s in (staffList))
            {
                if (s.Occupation == selectedCategory)
                {
                    Console.WriteLine($"{s.FirstName} {s.LastName}, Occupation: {s.Occupation}");
                }
                else if (selectedCategory == "All")
                {
                    Console.WriteLine($"{s.FirstName} {s.LastName}, Occupation: {s.Occupation}");
                }
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey(true);
            _mainMenu.ShowMainMenu();
        }

        public void ShowAddStaffMenu()
        {
            var firstNameItem = new EditableMenuItem("First Name");
            var lastNameItem = new EditableMenuItem("Last Name");
            

            var options = new List<MenuItem>
            {
                firstNameItem,
                lastNameItem,
                new ActionMenuItem("Next step", () => {
                    string firstName = firstNameItem.InputValue;
                    string lastName = lastNameItem.InputValue;
                    SelectStaffOccupationMenu(firstName, lastName);
                }),
                new ActionMenuItem("Back to main menu", () => _mainMenu.ShowMainMenu())
            };

            MenuHelper.CreateMenu("Press enter to edit a value: ", options);
        }

        public void SelectStaffOccupationMenu(string firstName, string lastName)
        {
            var options = new List<MenuItem>
            {
                new ActionMenuItem("Teacher", () => {
                    _staffService.AddStaff(firstName, lastName, "Teacher");
                    _mainMenu.ShowMainMenu();
                }),
                new ActionMenuItem("Counselor", () => {
                    _staffService.AddStaff(firstName, lastName, "Counselor");
                    _mainMenu.ShowMainMenu();
                }),
                new ActionMenuItem("Administrator", () => {
                    _staffService.AddStaff(firstName, lastName, "Administrator");
                    _mainMenu.ShowMainMenu();
                }),
            }; 

            MenuHelper.CreateMenu($"Choose an occupation for the staff member {firstName} {lastName}: ", options);
        }
    }
}
