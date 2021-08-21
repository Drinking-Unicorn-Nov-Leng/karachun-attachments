using AutoMapper;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttachmentsService.BI.Interfaces;
using AttachmentsService.BI.Options;
using AttachmentsService.Data.Dto;
using AttachmentsService.EF;
using Microsoft.EntityFrameworkCore;
using AttachmentsService.Data.Entity;
using AttachmentsService.General.Expansions;

namespace AttachmentsService.BI.Services
{
    public class AttachmentService : IAttachment
    {
        private AttachmentOptions _config;
        private ServiceDbContext _context;
        private readonly IMapper _mapper;

        public AttachmentService(IMapper mapper, ServiceDbContext context, AttachmentOptions config)
        {
            _mapper = mapper;
            _context = context;
            _config = config;

            if (!Directory.Exists(_config.Path))
                Directory.CreateDirectory(_config.Path);
        }

        public async Task<string> Upload(AttachmentDto attachment)
        {
            attachment.TempName = Path.GetRandomFileName();
            using (var file = File.Create(GetPath(attachment.TempName)))
            {
                await attachment.Stream.CopyStreamTo(file);
            }
            var attach = _mapper.Map<Attachment>(attachment);

            await _context.AddAsync(attach);
            await _context.SaveChangesAsync();

            return String.Format($"{_config.UrlAttachmentService.FixUrl()}{attach.Id}");
        }

        public async Task<AttachmentDto> Get(int attachmentId)
        {
            var a = await _context.Attachments.SingleOrDefaultAsync(x => x.Id == attachmentId);
            if (a == null)
                throw new Exception("Файла с указанным ID не найдено!");

            var attachment = _mapper.Map<AttachmentDto>(a);

            MemoryStream ms = new MemoryStream();

            using (FileStream fs = File.Open(GetPath(attachment.TempName), FileMode.Open))
            {
                fs.CopyTo(ms);
            }

            attachment.Stream = ms;

            return attachment;
        }

        private string GetPath(string nameFile)
        {
            return _config.Path + "/" + nameFile;
        }
    }
}
