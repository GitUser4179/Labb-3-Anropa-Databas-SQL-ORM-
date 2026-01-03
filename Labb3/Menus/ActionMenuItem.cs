using System;
using System.Collections.Generic;
using System.Text;

namespace Labb3.Menus
{
    public class ActionMenuItem : MenuItem
    {
        private readonly Action _action;

        public ActionMenuItem(string label, Action action) : base(label)
        {
            _action = action;
        }

        public override void OnEnter()
        {
            _action.Invoke();
        }

        public override string GetDisplayText()
        {
            return Label;
        }
    }
}
