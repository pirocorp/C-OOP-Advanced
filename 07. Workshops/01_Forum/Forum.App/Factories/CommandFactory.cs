﻿namespace Forum.App.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;

	public class CommandFactory : ICommandFactory
	{
	    private readonly IServiceProvider serviceProvider;

	    public CommandFactory(IServiceProvider serviceProvider)
	    {
	        this.serviceProvider = serviceProvider;
	    }

		public ICommand CreateCommand(string commandName)
		{
		    var assembly = Assembly.GetExecutingAssembly();

		    var commandType = assembly.GetTypes()
		        .FirstOrDefault(t => t.Name == $"{commandName}Command");

		    if (commandType == null)
		    {
		        throw new InvalidOperationException($"{commandName}Command not found!");
		    }

		    if (!typeof(ICommand).IsAssignableFrom(commandType))
		    {
		        throw new InvalidOperationException($"{commandName} is not a {nameof(ICommand)}!");
		    }

		    var ctor = commandType.GetConstructors().First();
            var ctorParams = ctor.GetParameters();

		    var args = new object[ctorParams.Length];
		    for (var i = 0; i < args.Length; i++)
		    {
		        args[i] = this.serviceProvider.GetService(ctorParams[i].ParameterType);
		    }

            var command = (ICommand)ctor.Invoke(args);
            return command;
		}
    }
}