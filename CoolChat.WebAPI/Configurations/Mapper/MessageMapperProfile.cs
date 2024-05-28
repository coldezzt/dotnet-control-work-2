using AutoMapper;
using CoolChat.Domain.Entities;
using CoolChat.WebAPI.Dto;

namespace CoolChat.WebAPI.Configurations.Mapper;

public class MessageMapperProfile : Profile
{
    public MessageMapperProfile()
    {
        CreateMap<MessageDto, Message>();
        CreateMap<Message, MessageDto>();
    }
}