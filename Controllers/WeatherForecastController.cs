using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WeatherAPI.Models;

namespace WeatherAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ColourContext _context;
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, ColourContext context)
    {
        _context = context;
        _logger = logger;
    }
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    //[HttpGet(Name = "GetWeatherForecast")]
    //public IEnumerable<WeatherForecast> Get()
    //{
    //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
    //    {
    //        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
    //        TemperatureC = Random.Shared.Next(-20, 55),
    //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
    //    })
    //    .ToArray();
    //}


    [HttpGet(Name = "GetColourList")]
    public IEnumerable<Models.Colour> GetColourList()
    {
        try
        {
            DbSet<Colour> list = _context.Colour;
            //string connetionString;
            //SqlConnection cnn;
            //connetionString = ;
            //cnn = new SqlConnection(connetionString);
            //cnn.Open();

            //cnn.Close();
            //return new List<Colour> { new Colour { Id = 1, ColourName= "Success" } };
            return list.ToList();
        }       
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Error, ex.Message);
            return new List<Colour> { new Colour
                { Id = 1, ColourName = ex.Message } };
        }

    }
}
