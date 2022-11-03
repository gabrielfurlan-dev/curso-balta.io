using Dapper;
using exercicios.Commands;
using exercicios.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using RestSharp;

namespace DependencyRoomBooking.Controllers;

[ApiController]
public class BookController : ControllerBase
{
    SqlConnection _connection;
    ICustomerRepository _customerRepository;
    IBookRepository _bookRepository;
    IPaymentRepository _paymentRepository;

    public BookController(SqlConnection connection, ICustomerRepository costumerRepository, IBookRepository bookRepository, IPaymentRepository paymentRepository)
    {
        _connection = connection;
        _customerRepository = costumerRepository;
        _bookRepository = bookRepository;
        _paymentRepository = paymentRepository;
    }

    public async Task<IActionResult> Book(BookRoomCommand command)
    {
        var customer = _customerRepository.GetCustomerByEmail(command.Email);

        if (customer == null)
            return NotFound();

        var room = await _bookRepository.GetBookByRoomId(command);

        if (room is not null)
            return BadRequest();

        var response = await _paymentRepository.GetPaymentResponse(command.Email, command.CreditCard);

        if (response is null)
            return BadRequest();

        if (response?.Status != "paid")
            return BadRequest();

        // Cria a reserva
        var book = new Book(command.Email, command.RoomId, command.Day);

        // Salva os dados
        await _connection.ExecuteAsync("INSERT INTO [Book] VALUES(@date, @email, @room)", new
        {
            book.Date,
            book.Email,
            book.Room
        });

        // Retorna o número da reserva
        return Ok();
    }
}


public record PaymentResponse(int Code, string Status);

public record Customer(string Email);

public record Room(Guid Id, string Name);

public record Book(string Email, Guid Room, DateTime Date);

public record CreditCard(string Number, string Holder, string Expiration, string Cvv);