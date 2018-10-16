﻿namespace P08_CustomListSorter.Models.Commands
{
    using Interfaces;
    using IO.Interfaces;

    public class ContainsCommand : Command
    {
        public ContainsCommand(IWriter writer) : base(writer)
        {
        }

        public override void Execute(string[] inputParameters, ICustomList<string> listOfItems)
        {
            this.writer.WriteLine(listOfItems.Contains(inputParameters[1]));
        }
    }
}