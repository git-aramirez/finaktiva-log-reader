namespace LogReader.Domain.IRepositories
{
    public interface ILogReaderRepository
    {
        bool CreateLog(EventLog log);
        List<EventLog> Logs();
    }
}
