using AutoMapper;
using AutoMapper.Collection;
using AutoMapper.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AttachmentsService.BI.Interfaces;
using AttachmentsService.Data.Dto;
using AttachmentsService.Data.ViewModel.Input;
using Microsoft.AspNetCore.Http;

namespace AttachmentsService.API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AttachmentController : ControllerBase
    {
        private readonly ILogger<AttachmentController> _logger;
        private readonly IMapper _mapper;
        private readonly IAttachment _attachment;

        public AttachmentController(ILogger<AttachmentController> logger, IMapper mapper, IAttachment attachment)
        {
            _logger = logger;
            _mapper = mapper;
            _attachment = attachment;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] AttachmentViewModel file)
        {
            if (file.File == null || file.File.Length == 0)
                BadRequest("Данные о файле недоступны!");

            var result = await _attachment.Upload(_mapper.Map<AttachmentDto>(file));
            if (String.IsNullOrEmpty(result))
                return BadRequest("Не удалось сохранить файл!");
            return Ok(result);
        }

        [HttpGet("{fileId}")]
        public async Task<IActionResult> Get(int fileId)
        {
            try
            {
                var result = await _attachment.Get(fileId);
                return File((result.Stream as MemoryStream).ToArray(), "application/octet-stream", result.FileName);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetTest()
        {
            return Ok("Done");
        }
    }
}
