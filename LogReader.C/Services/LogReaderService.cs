using LogReader.Core.IServices;
using LogReader.Domain;
using LogReader.Domain.IRepositories;

namespace LogReader.Core.Services
{
    public class LogReaderService : ILogReaderService
    {
        private readonly ILogReaderRepository _logReaderRepository;
        public LogReaderService(ILogReaderRepository logReaderRepository)
        {
            _logReaderRepository = logReaderRepository;
        }

        public bool CreateLog(EventLog eventLog)
        {
            return _logReaderRepository.CreateLog(eventLog);
        }

        public IEnumerable<EventLog> Logs()
        {
            return _logReaderRepository.Logs();
        }
    }
}
