using System;
using System.Collections.Generic;
using System.Linq;
using PdfCreator.Commands;

namespace PdfCreator.InputMappers
{
    public class InputMapper : IMapper
    {
        public Queue<ICommand> MapInputFromArray(string[] inputArray)
        {
            if (inputArray == null || inputArray.Length == 0)
            {
                throw new ArgumentException(Constants.NO_INPUTS_TO_MAP_ERROR);
            }

            var queueOfCommands = new Queue<ICommand>();

            // Obtain a list of the possible implementations of ICommand.
            var type = typeof(ICommand);
            var possibleCommandTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p));

            //For each input in the array, instantiate the appropriate implementation of ICommand by matching the input string to the name of the class.
            foreach (string input in inputArray)
            {
                ICommand command = null;
                Type matchedType = null;
                    
                try
                {
                    matchedType = possibleCommandTypes.First(commandType => "." + commandType.Name.ToLower() == input.Split()[0]);
                }
                catch
                {
                    //If no matching command class is found assume it's a text command.
                    var assemblyQualifiedName = $"PdfCreator.Commands.Text, PdfCreator";
                    matchedType = Type.GetType(assemblyQualifiedName);
                }

                if (matchedType.GetConstructor(Type.EmptyTypes) == null)
                {
                    command = Activator.CreateInstance(matchedType, args: new object[] { input }) as ICommand;
                }
                else
                {
                    command = Activator.CreateInstance(matchedType) as ICommand;
                }

                queueOfCommands.Enqueue(command);
            }

            return queueOfCommands;
        }
    }
}
