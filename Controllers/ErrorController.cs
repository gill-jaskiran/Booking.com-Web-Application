using Microsoft.AspNetCore.Mvc;

public class ErrorController : Controller
{
    [Route("/Error/{statusCode}")]
    public IActionResult HandleError(int statusCode)
    {
        switch (statusCode)
        {
            case 404:
                return View("NotFound");
            case 500:
                return View("InternalServerError");
            default:
                return View("Error");
        }
    }
}

