using System;
using System.Collections.Generic;
using System.Text;

namespace Labb3.Menus
{
    public static class MenuInputHelper
    {
        public static int HandleKey(ConsoleKey key, int index, int count, Action onEnter)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    return Math.Max(0, index - 1);

                case ConsoleKey.DownArrow:
                    return Math.Min(count - 1, index + 1);

                case ConsoleKey.Enter:
                    onEnter();
                    return index;

                default:
                    return index;
            }
        }
    }
}
