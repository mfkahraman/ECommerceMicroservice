using ECommerce.Message.Context;
using ECommerce.Message.DTOs;
using ECommerce.Message.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Message.Services
{
    public class UserMessageService(AppDbContext context) : IUserMessageService
    {
        public async Task CreateAsync(CreateUserMessageDto messageDto)
        {
            var message = messageDto.Adapt<UserMessage>();
            await context.AddAsync(message);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var value = await context.UserMessages.FindAsync(id);
            context.Remove(value);
            await context.SaveChangesAsync();
        }

        public async Task<List<ResultUserMessageDto>> GetAllAsync()
        {
            var values = await context.UserMessages.AsNoTracking().ToListAsync();
            return values.Adapt<List<ResultUserMessageDto>>();
        }

        public async Task<ResultUserMessageDto> GetByIdAsync(int id)
        {
            var value = await context.UserMessages.FindAsync(id);
            return value.Adapt<ResultUserMessageDto>();
        }

        public async Task UpdateAsync(int id, UpdateUserMessageDto messageDto)
        {
            var message = await context.UserMessages.FindAsync(id);
            if (message == null)
            {
                throw new Exception("Message not found");
            }

            message.NameSurname = messageDto.NameSurname;
            message.Email = messageDto.Email;
            message.MessageBody = messageDto.MessageBody;
            message.Subject = messageDto.Subject;
            message.IsRead = messageDto.IsRead;

            context.Update(message);
            await context.SaveChangesAsync();
        }
    }
}
