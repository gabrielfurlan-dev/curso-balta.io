using DependencyRoomBooking.Controllers;
using exercicios.Commands;

namespace exercicios.Repositories.Contracts
{
    public interface IBookRepository
    {
         public Task<Book?> GetBookByRoomId(BookRoomCommand command);
    }
}