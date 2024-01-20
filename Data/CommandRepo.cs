using CommandsService.Models;

namespace CommandsService.Data
{
    public class CommandRepo : ICommandRepo
    {
        private readonly AppDbContext _context;

        public CommandRepo(AppDbContext context)
        {
            _context = context;
        } 

        public void CreateCommand(int platformId, Command command)
        {
            if(command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }
           
           command.PlatformId = platformId;
           _context.Commands.Add(command);
        }

        public void CreatePlatform(Platform plat)
        {
           if(plat == null)
           {
                throw new ArgumentNullException(nameof(plat));
           }
           
           _context.Platforms.Add(plat);
        }

        public IEnumerable<Platform> GetAllPlatforms()
        {
             return _context.Platforms.ToList();
        }

        public Command GetCommand(int platformId, int commandId)
        {
           return _context.Commands
                .FirstOrDefault(c => c.PlatformId == platformId && c.Id == commandId);
        }

        public IEnumerable<Command> GetCommandsForPlatform(int platformId)
        {
            return _context.Commands
                .Where(c => c.PlatformId == platformId)
                .OrderBy(c => c.Platform.Name);
        }

        public bool PlatformExist(int PlatformId)
        {
           return _context.Platforms.Any(p => p.id == PlatformId);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}