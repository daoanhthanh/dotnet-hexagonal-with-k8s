using Microsoft.AspNetCore.Mvc;

namespace Adapter.RestfulAPI.Src.readiness;

[ApiController]
[Route("/")]
public class ReadinessController: ControllerBase
{
    [HttpGet]
    public string Get()
    {
        return "Hello World!";
    }
}