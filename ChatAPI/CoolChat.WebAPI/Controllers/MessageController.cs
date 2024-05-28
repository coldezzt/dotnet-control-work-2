﻿using AutoMapper;
using CoolChat.Domain.Abstractions.Services;
using CoolChat.Domain.Entities;
using CoolChat.WebAPI.Controllers.Hubs;
using CoolChat.WebAPI.Dto;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace CoolChat.WebAPI.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class MessageController(
    IMapper mapper,
    ChatHub chatHub,
    IMessageService service,
    IValidator<MessageDto> validator) : ControllerBase
{
    [HttpGet("list")]
    public async Task<IActionResult> GetMessagesList()
    {
        var response = await service.GetMessagesListAsync();
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> SendMessage(MessageDto dto)
    {
        var validationResult = await validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            return UnprocessableEntity(validationResult);

        var message = mapper.Map<Message>(dto);
        await chatHub.SendMessageAsync(message.Username, message.Content);
        
        return Ok(message);
    }
}