using AttachmentsService.Data;
using AttachmentsService.Data.Dto;
using AttachmentsService.Data.ViewModel.Input;
using AttachmentsService.Data.Entity;
using AutoMapper;
using AutoMapper.EquivalencyExpression;
using System;
using System.Linq;

namespace AttachmentsService.API.Configurations.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AttachmentViewModel, AttachmentDto>()
                .ForMember(x => x.FileName, s => s.MapFrom(y => y.File.FileName))
                .ForMember(x => x.Size, s => s.MapFrom(y => y.File.Length))
                .ForMember(x => x.Stream, s => s.MapFrom(y => y.File.OpenReadStream()))
                .ForMember(x => x.File, s => s.Ignore())
                .ForMember(x => x.DeathDate, s => s.MapFrom(y => y.LifeTime));

            CreateMap<Attachment, AttachmentDto>();

            CreateMap<AttachmentDto, Attachment>();
        }
    }
}
