using Labb3.Data;
using Labb3.Models;
using Labb3.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.NetworkInformation;
using System.Net.WebSockets;
using System.Reflection.Metadata.Ecma335;
using System.Text;


namespace Labb3.Menus
{
    public class StudentMenu
    {

        private readonly ChasGymnasieSkolaDb _context;
        private readonly StudentService _studentService;
        private MainMenu _mainMenu;
        private ClassMenu _classMenu;
        private ClassService _classService;

        public StudentMenu(StudentService studentService, ClassService classService)
        {
            _studentService = studentService;
            _classService = classService;
            _context = new ChasGymnasieSkolaDb();
        }

        public void SetMenu(MainMenu mainMenu, ClassMenu classMenu)
        {
            _mainMenu = mainMenu;
            _classMenu = classMenu;
        }

        // Selected which name to sort by
        public void ShowStudentsOrderMenu()
        {
            var options = new List<MenuItem>
            {
                new ActionMenuItem("Order by First Name", () => ShowStudentDirectionMenu(StudentSortField.FirstName)),
                new ActionMenuItem("Order by Last Name", () => ShowStudentDirectionMenu(StudentSortField.LastName)),
                new ActionMenuItem("Exit to Main Menu", () => _mainMenu.ShowMainMenu())
            };

            MenuHelper.CreateMenu("", options);
        }

        // Select sort direction, receives the previously selected field
        public void ShowStudentDirectionMenu(StudentSortField selectedField)
        {
            var options = new List<MenuItem>
            {
                new ActionMenuItem("Sort by Ascending", () => DisplaySortedStudents(selectedField, ListSortDirection.Ascending)),
                new ActionMenuItem("Sort by Descending", () => DisplaySortedStudents(selectedField, ListSortDirection.Descending)),
                new ActionMenuItem("Back", () => ShowStudentsOrderMenu())
            };

            MenuHelper.CreateMenu("", options);
        }

        // Show the final result, receives both previously selected fields
        public void DisplaySortedStudents(StudentSortField selectedField, ListSortDirection direction)
        {
            _studentService.WriteSortedStudents(selectedField, direction);
        }

        public void ShowAddStudentMenu()
        {
            var firstNameItem = new EditableMenuItem("First Name");
            var lastNameItem = new EditableMenuItem("Last Name");
            var pinItem = new EditableMenuItem("PIN");

            var options = new List<MenuItem>
            {
                firstNameItem,
                lastNameItem,
                pinItem,
                new ActionMenuItem("Confirm", () => {
                    string firstName = firstNameItem.InputValue;
                    string lastName = lastNameItem.InputValue;
                    string pin = pinItem.InputValue;
                    _classMenu.SelectClassForNewStudentMenu(firstName, lastName, pin);
                }),
                new ActionMenuItem("Exit", () => _mainMenu.ShowMainMenu())
            };

            MenuHelper.CreateMenu("Press enter to edit a value: ", options);
            _mainMenu.ShowMainMenu();
        }
    }
}
