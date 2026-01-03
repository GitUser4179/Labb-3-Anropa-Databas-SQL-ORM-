using Labb3.Data;
using Labb3.Menus;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Labb3.Models;
using Microsoft.Identity.Client;

namespace Labb3.Service
{
    public class StudentService : MainService
    {
        public void WriteSortedStudents(StudentSortField field, ListSortDirection direction)
        {
            var studentsQuery = _context.Students.AsQueryable();
            
            if (field == StudentSortField.FirstName)
            {
                studentsQuery = direction == ListSortDirection.Descending
                    ? studentsQuery.OrderByDescending(s => s.FirstName)
                    : studentsQuery.OrderBy(s => s.FirstName);
            }
            else if (field == StudentSortField.LastName)
            {
                studentsQuery = direction == ListSortDirection.Descending
                    ? studentsQuery.OrderByDescending(s => s.LastName)
                    : studentsQuery.OrderBy(s => s.LastName);
            }

            var students = studentsQuery.ToList();
            Console.Clear();
            Console.WriteLine("List of all Students");
            foreach (var s in students)
            {
                Console.WriteLine($"{s.FirstName} {s.LastName}");
            }

            Console.WriteLine("Press any key to return to the main menu");
            Console.ReadKey(intercept: true);
            _mainMenu.ShowMainMenu();
        }

        public void DisplayStudentsInClass(int classId)
        {
            var classList = _context.Classes.AsQueryable().ToList();
            var studentList = _context.Students.AsQueryable().ToList();
            var filteredStudents = studentList
                .Where(s => s.ClassId == classId)
                .ToList();
            var selectedClass = classList.Single(c => c.ClassId == classId);

            Console.Clear();
            Console.WriteLine($"Students from {selectedClass.ClassName}: ");
            foreach (var fS in filteredStudents)
            {
                Console.WriteLine($"{fS.FirstName} {fS.LastName}");
            }

            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey(true);
            _mainMenu.ShowMainMenu();
        }

        // Returns a list of all the Students
        public List<Student> GetStudents()
        {
            var studentsQuery = _context.Students.AsQueryable();
            var students = studentsQuery.ToList();
            return students;
        }

        // Returns a list of all the students in a specified class
        public List<Student> GetStudentsInXClass(int classId)
        {
            var students = new List<Student>();
            foreach (var s in GetStudents())
            {
                if (classId == s.ClassId)
                {
                    students.Add(s);
                }
            }

            return students;
        }
    }

    public enum StudentSortField
    {
        FirstName,
        LastName
    }
}
