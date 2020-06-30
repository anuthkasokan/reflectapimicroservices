using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using CognizantReflect.Api.BusinessLogics.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CognizantReflect.Api.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        private readonly ILogger<SettingsController> _logs;
        private readonly ISettingsBusinessLogics _settingsBusinessLogics;
        public SettingsController(ILogger<SettingsController> logs, ISettingsBusinessLogics settingsBusinessLogics)
        {
            _logs = logs;
            _settingsBusinessLogics = settingsBusinessLogics;
        }

        [HttpPost, DisableRequestSizeLimit]
        public IActionResult Upload()
        {

            var files = Request.Form.Files;
            var folderName = "Files";
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

            if (files != null && files.Any())
            {
                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName
                            .Trim('"');
                        var fullPath = Path.Combine(pathToSave, fileName);
                        try
                        {
                            using var stream = new FileStream(fullPath, FileMode.Create);
                            file.CopyTo(stream);
                            _settingsBusinessLogics.UploadExcel(fullPath);

                            stream.Dispose();
                            System.IO.File.Delete(fullPath);

                        }

                        catch (Exception ex)
                        {
                            System.IO.File.Delete(fullPath);
                            _logs.LogError($"Internal server error: {ex}");
                            return StatusCode(500, $"Internal server error: {ex}");
                        }
                    }
                }
            }
            else
            {
                return BadRequest();
            }
            return Ok();

        }
    }
}
