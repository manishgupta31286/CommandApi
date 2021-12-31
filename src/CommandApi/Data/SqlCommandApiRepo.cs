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
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            _commandContext.CommandItems.Add(cmd);
        }

        public void DeleteCommand(Command cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            _commandContext.CommandItems.Remove(cmd);
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
            return (_commandContext.SaveChanges() >= 0);
        }

        public void UpdateCommand(Command cmd)
        {
            //No need to implement
        }
    }
}