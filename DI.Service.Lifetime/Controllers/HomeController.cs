using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DI.Service.Lifetime.Models;
using DI.Service.Lifetime.Services;
using System.Text;

namespace DI.Service.Lifetime.Controllers;

public class HomeController : Controller
{
    private readonly IScopedService _scoped1;
    private readonly IScopedService _scoped2;

    private readonly ISinglelton _singleton1;
    private readonly ISinglelton _singleton2;

    private readonly Itransient _transient1;
    private readonly Itransient _transient2;

    public HomeController(IScopedService scoped1, IScopedService scoped2,
        ISinglelton singleton1, ISinglelton singleton2, Itransient transient1, 
        Itransient transient2)
    {
        _singleton1 = singleton1;
        _singleton2 = singleton2;

        _scoped1 = scoped1;
        _scoped2 = scoped2;

        _transient1 = transient1;
        _transient2 = transient2;

    }

    public IActionResult Index()
    {
        StringBuilder messages = new StringBuilder();
        messages.Append($"Transient 1:{ _transient1.GetGuid()}\n");
        messages.Append($"Transient 2:{_transient2.GetGuid()}\n\n\n");
        messages.Append($"Scoped 1: {_scoped1.GetGuid()}\n");
        messages.Append($"Scoped 1: {_scoped2.GetGuid()}\n\n\n");
        messages.Append($"Singelton 1:{_singleton1.GetGuid()}\n");
        messages.Append($"Singelton 2:{_singleton2.GetGuid()}\n");

        return Ok(messages.ToString());
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
