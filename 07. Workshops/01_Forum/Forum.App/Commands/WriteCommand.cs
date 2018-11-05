﻿namespace Forum.App.Commands
{
    using Contracts;

    public class WriteCommand : ICommand
    {
        private readonly ISession session;

        public WriteCommand(ISession session)
        {
            this.session = session;
        }

        public IMenu Execute(params string[] args)
        {
            var currentMenu = (ITextAreaMenu)this.session.CurrentMenu;
            currentMenu.TextArea.Write();

            return currentMenu;
        }
    }
}