using BlazorCrudApp.Interfaces;
using BlazorCrudApp.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;

namespace BlazorCrudApp.Services;

public class BookService : IBookService
{
    private readonly HttpClient _http;
    private readonly IConfiguration _configuration;

    public BookService(HttpClient http, IConfiguration configuration)
    {
        _http = http;
        _configuration = configuration;
    }

    public async Task<List<Book>> GetListBooks()
    {
        return await _http.GetFromJsonAsync<List<Book>>($"{_configuration["ApiUrl:GetListBooks"]}");
    }

    public async Task<Book> GetBook(int id)
    {
        try
        {
            var response = await _http.GetAsync($"{_configuration["ApiUrl:GetBook"]}/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Book>();
        }
        catch (HttpRequestException ex)
        {
            // Log the exception or handle it as needed
            Console.WriteLine($"Error fetching book with ID {id}: {ex.Message}");
            return null;
        }

        //var result = await _http.GetFromJsonAsync<Book>($"{_configuration["ApiUrl:GetBook"]}/{id}");

        //return result;
    }

    public async Task<string> CreateBook(Book book)
    {
        var response = await _http.PostAsJsonAsync($"{_configuration["ApiUrl:AddBook"]}", book);

        if (response.IsSuccessStatusCode)
        {
            return "success"; // Retorna un string indicando éxito
        }
        else
        {
            return $"Error {response.StatusCode}: {await response.Content.ReadAsStringAsync()}";
        }
    }


    public async Task<bool> UpdateBook(Book book)
    {
        var response = await _http.PutAsJsonAsync($"{_configuration["ApiUrl:UpdateBook"]}", book);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteBook(int id)
    {
        var url = $"{_configuration["ApiUrl:DeleteBook"]}/{id}";
        var response = await _http.DeleteAsync(url);
        return response.IsSuccessStatusCode;
    }
}