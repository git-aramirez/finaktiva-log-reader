using LogReader.Domain.IRepositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

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
            try
            {
                var descriptionParameter = new SqlParameter("@description", eventLog.Description);
                var eventParameter = new SqlParameter("@event", eventLog.Event);
                var dateParameter = new SqlParameter("@date", eventLog.Date);
                var sqlQuery = @"INSERT INTO EVENTLOG (description, event, date) 
                             VALUES (@description, @event, @date)";
                _context.Database.ExecuteSqlRaw(sqlQuery, descriptionParameter, eventParameter, dateParameter);

                return true;
            }
            catch (Exception e)
            {
                throw new Exception("Something in the request was bad! "+ e.Message);
            }
        }

        public List<EventLog> Logs()
        {
            try
            {
                var sqlQuery = @"SELECT * FROM EVENTLOG";
                var result = _context.EvenLogs.FromSqlRaw(sqlQuery).ToList();

                return result;
            }
            catch(Exception e)
            {
                throw new Exception("Something in the request was bad! "+ e.Message);
            }
        }
    }
}
