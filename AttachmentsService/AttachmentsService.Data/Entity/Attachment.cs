using System;
using System.Collections.Generic;
using System.Text;

namespace AttachmentsService.Data.Entity
{
    public class Attachment : Base2
    {
        public string FileName { get; set; }

        public long Size { get; set; }

        public string TempName { get; set; }

        public DateTime DeathDate { get; set; }
    }
}
