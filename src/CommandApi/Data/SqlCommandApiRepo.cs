using System.Collections.Generic;
using CommandApi.Models;
namespace CommandApi.Data
{
    public class SqlCommandApiRepo : ICommandApiRepo
    {
        private readonly CommandContext _commandContext;
        public SqlCommandApiRepo(CommandContext commandContext)
        {
            _commandContext = commandContext;
        }

        public void CreateCommand(Command cmd)
        {
            throw new NotImplementedException();
        }

        public void DeleteCommand(Command cmd)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return _commandContext.CommandItems.ToList();
        }

        public Command GetCommandById(int id)
        {
            return _commandContext.CommandItems.FirstOrDefault(c => c.Id == id);
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateCommand(Command cmd)
        {
            throw new NotImplementedException();
        }
    }
}