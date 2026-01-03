using System;
using System.Collections.Generic;
using System.Text;

namespace Labb3.Menus
{
    public class EditableMenuItem : MenuItem
    {
        public string InputValue { get; private set; } = "";
        public EditableMenuItem(string label) : base(label)
        {

        }

        public override void OnEnter()
        {
            Console.Clear();
            Console.Write($"{Label}: ");
            InputValue = Console.ReadLine();
        }

        public override string GetDisplayText()
        {
            return $"{Label}: {InputValue}";
        }
    }
}
