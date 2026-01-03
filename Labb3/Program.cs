using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Labb3.Menus;
using Labb3.Service;

namespace Labb3
{
    internal class Program
    {
        static void Main(string[] args)
        {    
            // Initializing objects
            Console.CursorVisible = false;

            // Initializing services
            var studentService = new StudentService();

            var classService = new ClassService();

            var staffService = new StaffService();

            // Initializing Menus
            var studentMenu = new StudentMenu(studentService, classService);

            var classMenu = new ClassMenu(studentService, classService);

            var staffMenu = new StaffMenu(staffService);

            var mainMenu = new MainMenu(studentMenu, classMenu, staffMenu);

            // Setting menus
            studentMenu.SetMenu(mainMenu, classMenu);

            classMenu.SetMenu(mainMenu, studentMenu);

            staffMenu.SetMenu(mainMenu);

            studentService.SetMenu(mainMenu);

            classService.SetMenu(mainMenu);

            staffService.SetMenu(mainMenu);

            // Run
            mainMenu.ShowMainMenu();
        }
    }
}


