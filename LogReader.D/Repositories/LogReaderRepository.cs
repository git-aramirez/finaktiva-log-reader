using LogReader.Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace LogReader.Domain.Repositories
{
    public class LogReaderRepository : ILogReaderRepository
    {
        private readonly ApplicationDbContext _context;

        public LogReaderRepository(ApplicationDbContext context)
        {
            _context=context;
        }

        public bool CreateLog(EventLog eventLog)
        {
            var descriptionParameter = new SqlParameter("@description", eventLog.Description);
            var eventParameter = new SqlParameter("@event", eventLog.Event);
            var dateParameter = new SqlParameter("@event", eventLog.Date);
            var sqlQuery = @"INSERT INTO EVENTLOG (description, event, date) 
                             VALUES (@description, @event, @date)";
            _context.EvenLogs.FromSqlRaw(sqlQuery, descriptionParameter, eventParameter, dateParameter);

            return true;
        }

        public List<EventLog> Logs()
        {
            var sqlQuery = @"SELECT * FROM EVENTLOG";

            return _context.EvenLogs.FromSqlRaw(sqlQuery).ToList();
        }
    }
}
