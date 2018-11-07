﻿namespace BashSoft.IO.Commands
{
    using Contracts.IO;
    using Contracts.Judge;
    using Contracts.Repository;
    using Exceptions;
    using Judge;
    using Repository;

    public class CompareFilesCommand : Command
    {
        public CompareFilesCommand(string input, string[] data, IContentComparer judge, IDatabase repository,
            IDirectoryManager inputOutputManager) : base(input, data, judge, repository, inputOutputManager) {}

        public override void Execute()
        {
            if (this.Data.Length != 3)
            {
                throw new InvalidCommandException(this.Input);
            }

            this.Judge.CompareContent(this.Data[1], this.Data[2]);
        }
    }
}
