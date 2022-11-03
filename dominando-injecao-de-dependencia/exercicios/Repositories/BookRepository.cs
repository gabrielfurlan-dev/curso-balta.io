using Dapper;
using DependencyRoomBooking.Controllers;
using exercicios.Commands;
using exercicios.Repositories.Contracts;
using Microsoft.Data.SqlClient;

namespace exercicios.Repositories
{
    public class BookRepository : IBookRepository
    {
        private SqlConnection _connection;

        public BookRepository(SqlConnection connection) 
            => _connection = connection;

        public async Task<Book?> GetBookByRoomId(BookRoomCommand command)
        {
            return await _connection.QueryFirstOrDefaultAsync<Book?>(
            "SELECT * FROM [Book] WHERE [Room]=@room AND [Date] BETWEEN @dateStart AND @dateEnd",
            new
            {
                Room = command.RoomId,
                DateStart = command.Day.Date,
                DateEnd = command.Day.Date.AddDays(1).AddTicks(-1),
            });
        }
    }
}