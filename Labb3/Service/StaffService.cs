using Labb3.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace Labb3.Service
{
    public class StaffService : MainService
    {
        public List<Staff> GetStaff()
        {
            var staffQuery = _context.Staff.AsQueryable();
            var staffList = staffQuery.ToList();
            return staffList;
        }

        public void AddStaff(string firstName, string lastName, string occupation)
        {
            if (!firstName.IsNullOrEmpty() && !lastName.IsNullOrEmpty() && !occupation.IsNullOrEmpty())
            {
                _context.Staff.Add(new Staff
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Occupation = occupation
                });

                Console.WriteLine($"{firstName} {lastName} - {occupation} has been added to the staff list\n Press any key to return to the main menu");
                Console.ReadKey(true);
            }

            _context.SaveChanges();
            // FirstName, LastName, Occupation
        }
    }
}
