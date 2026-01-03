using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Labb3.Menus
{
    public static class MenuHelper
    {
        public static void CreateMenu(string title, List<MenuItem> items)
        {
            int index = 0;
            ConsoleKeyInfo key;

            do
            {
                RenderMenu(items, index, title);
                key = Console.ReadKey(true);

                index = MenuInputHelper.HandleKey(key.Key, index, items.Count, () => items[index].OnEnter());
            } while (key.Key != ConsoleKey.Escape);
        }
        
        
        // Hovers over the currently selected option
        static void RenderMenu(List<MenuItem> items, int selectedIndex, string title)
        {
            Console.Clear();
            if (!title.IsNullOrEmpty())
            {
                Console.WriteLine(title);
            }
            else
            {

            }
            for (int i = 0; i < items.Count; i++)
            {
                Console.Write(i == selectedIndex ? "> " : " ");
                Console.WriteLine(items[i].GetDisplayText());
            }
        }
    }
}
