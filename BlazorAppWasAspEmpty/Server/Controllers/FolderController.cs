using Microsoft.AspNetCore.Mvc;

namespace BlazorAppWasAspEmpty.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FolderController : ControllerBase  
    {
        
        [HttpGet("open")]
        public void Open()
        {
            //open a folder
            System.Diagnostics.Process.Start("explorer.exe", @"H:\ENG_APLICACAO\HSA\03 PROPOSTA\HSAELC0032");
        }
    }
}
