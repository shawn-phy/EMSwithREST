using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using EMSwithREST.Models;

namespace EMSwithREST.DataProvider
{
    public class EventDataProvider : IEventDataProvider
    {
        private readonly string connectionString = "Data Source=localhost,1433;Initial Catalog=Events;Persist Security Info=True;User ID=sa;Password=Password_123#;";//Server=localhost,1433;Database=Events;;

        private SqlConnection sqlConnection;

        public async Task AddEvent(Event evt)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@EventName", evt.EventName);
                dynamicParameters.Add("@EventDate", evt.EventDate);
                dynamicParameters.Add("@EventTime", evt.EventTime);
                dynamicParameters.Add("@Location", evt.Location);
                dynamicParameters.Add("@Description", evt.Description);
                dynamicParameters.Add("@OrganizerID", evt.OrganizerID);

                await sqlConnection.ExecuteAsync(
                    "spAddEvent",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task DeleteEvent(int eventId)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@EventID", eventId);
                await sqlConnection.ExecuteAsync(
                    "spDeleteEvent",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<Event> GetEvent(int eventId)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@EventID", eventId);
                return await sqlConnection.QuerySingleOrDefaultAsync<Event>(
                    "spGetEvent",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<Event>> GetEvents()
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                return await sqlConnection.QueryAsync<Event>(
                    "spGetEvents",
                    null,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task UpdateEvent(Event evt)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@EventID", evt.EventIdentifier);
                dynamicParameters.Add("@EventName", evt.EventName);
                dynamicParameters.Add("@EventDate", evt.EventDate);
                dynamicParameters.Add("@EventTime", evt.EventTime);
                dynamicParameters.Add("@Location", evt.Location);
                dynamicParameters.Add("@Description", evt.Description);
                dynamicParameters.Add("@OrganizerID", evt.OrganizerID);
                await sqlConnection.ExecuteAsync(
                    "spUpdateEvent",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}