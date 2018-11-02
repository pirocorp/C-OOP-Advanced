﻿namespace Forum.App.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Contracts;

    public class CategoriesMenuCommand : ICommand
    {
        private readonly IMenuFactory menuFactory;

        public CategoriesMenuCommand(IMenuFactory menuFactory)
        {
            this.menuFactory = menuFactory;
        }

        public IMenu Execute(params string[] args)
        {
            var commandName = this.GetType().Name;
            var menuName = commandName.Substring(0, commandName.Length - "Command".Length);

            var menu = this.menuFactory.CreateMenu(menuName);
            return menu;
        }
    }
}