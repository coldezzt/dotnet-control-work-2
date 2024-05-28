﻿using CoolChat.Application.Abstractions.Repositories;
using CoolChat.Domain.Entities;

namespace CoolChat.Infrastructure.Repositories;

public class MessageRepository(ApplicationDbContext dbContext) : IMessageRepository
{
    public Task<List<Message>> GetMessagesList()
    {
        return Task.FromResult(dbContext.Messages);
    }

    public Task<Message> SendMessage(Message m)
    {
        dbContext.Messages.Add(m);
        return Task.FromResult(m);
    }
}