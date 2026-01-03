using Labb3.Data;
using Labb3.Menus;
using Labb3.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Labb3.Service
{
    public class MainService
    {
        protected readonly ChasGymnasieSkolaDb _context;
        protected MainMenu _mainMenu;

        public MainService()
        {
            _context = new ChasGymnasieSkolaDb();
        }

        public void SetMenu(MainMenu mainMenu)
        {
            _mainMenu = mainMenu;
        }
    }
}
