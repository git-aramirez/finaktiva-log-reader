using LogReader.Domain;

namespace LogReader.Core.IServices
{
    public interface ILogReaderService
    {
        bool CreateLog(EventLog eventLog);

        IEnumerable<EventLog> Logs();
    }
}
