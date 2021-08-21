using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttachmentsService.Data.Dto;

namespace AttachmentsService.BI.Interfaces
{
    public interface IAttachment
    {
        Task<string> Upload(AttachmentDto attachment);

        Task<AttachmentDto> Get(int attachmentId);
    }
}
