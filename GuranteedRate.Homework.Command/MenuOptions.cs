using System;

namespace GuranteedRate.Homework.Command
{
    internal class MenuOptions
    {
        public string Name { get; }
        public Action Selected { get; }

        public MenuOptions(string name, Action action)
        {
            Name = name;
            Selected = action;
        }
    }
}
