using System;
using System.Collections.Generic;
using System.Text;

namespace Labb3.Menus
{
    public abstract class MenuItem
    {
        public string Label { get; protected set; }

        protected MenuItem(string label)
        {
            Label = label;
        }

        public abstract void OnEnter();
        public abstract string GetDisplayText();
    }
}
