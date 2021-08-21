using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachmentsService.Data.Dto
{
    public class AttachmentDto : Dates
    {
        public int AttachmentId { get; set; }

        public string FileName { get; set; }

        public long Size { get; set; }

        public string TempName { get; set; }

        public byte[] File { get; set; }

        public Stream Stream { get; set; }

        public DateTime DeathDate { get; set; }
    }
}
