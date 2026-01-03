using Labb3.Data;
using Labb3.Menus;
using System;
using System.Collections.Generic;
using System.Text;
using Labb3.Models;

namespace Labb3.Service
{
    public class ClassService : MainService
    {
        public List<Class> GetClasses()
        {
            var classQuery = _context.Classes.AsQueryable();
            var classList = classQuery.ToList();
            return classList;
        }

        public void AddStudent(string firstName, string lastName, string pin, Class selectedClass)
        {
            // PIN is a string
            if (!string.IsNullOrEmpty(pin) && selectedClass != null)
            {
                _context.Students.Add(new Student
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Pin = pin,
                    Class = selectedClass,
                    ClassId = selectedClass.ClassId
                });

                Console.WriteLine($"{firstName} {lastName} - {pin} has been added to {selectedClass.ClassName}\n Press any key to continue");
                Console.ReadKey(true);
            }
            else
            {
                Console.WriteLine($"Entered values {pin} or {selectedClass} are invalid.");
            }

            _context.SaveChanges();
        }
    }
}
