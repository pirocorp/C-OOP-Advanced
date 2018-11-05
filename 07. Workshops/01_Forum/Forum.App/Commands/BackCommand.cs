﻿namespace Forum.App.Commands
{
    using Contracts;

    public class BackCommand : ICommand
    {
        private readonly ISession session;

        public BackCommand(ISession session)
        {
            this.session = session;
        }

        public IMenu Execute(params string[] args)
        {
            var menu = this.session.Back();
            return menu;
        }
    }
}