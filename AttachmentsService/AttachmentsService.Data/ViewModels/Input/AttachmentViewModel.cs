using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace AttachmentsService.Data.ViewModel.Input
{
    public class AttachmentViewModel
    {
        public DateTime LifeTime { get; set; }

        public IFormFile File { get; set; }
    }
}
