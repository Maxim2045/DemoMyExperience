using DemoMyExperience.Domain.DbModels.Contexts.DemoMyExperience;
using DemoMyExperience.Domain.DbModels.Contexts.DemoMyExperience.Models;
using DemoMyExperience.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace DemoMyExperience.Services
{
    public class UserService: ICrud<UserRepository>
    {
        private readonly DemoMyExperienceContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(DemoMyExperienceContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context ?? throw new ArgumentException(nameof(context));
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentException(nameof(httpContextAccessor));
        }

        public async Task<IEnumerable<UserRepository>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<UserRepository> Get(Guid id)
        {
            var image = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (image == null)
            {
                throw new ArgumentException($"Изображение с идентификатором {id} не найдено в БД.");
            }

            return image;
        }

        public async Task Create(UserRepository entity)
        {
            // Guid.Empty - "00000000-0000-0000-0000-000000000000"
            if (entity.Id == Guid.Empty)
            {
                entity.Id = Guid.NewGuid();
            }
            //  entity.CreatedDate = DateTime.UtcNow;
            //  entity.LastSavedDate = DateTime.UtcNow;
            //
            //  if (Guid.TryParse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier),
            //      out var userId))
            //  {
            //      entity.CreatedBy = userId;
            //      entity.LastSavedBy = userId;
            //  }

            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(UserRepository entity)
        {
            //entity.LastSavedDate = DateTime.UtcNow;
            //
            //if (Guid.TryParse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier),
            //    out var userId))
            //{
            //    entity.LastSavedBy = userId;
            //}
            //
            //_imageContext.Image.Update(entity);
            //await _imageContext.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var imageEntity = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (imageEntity == null)
            {
                throw new ArgumentException($"Не найдено изображение с {id} в БД");
            }

            // if (Guid.TryParse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier),
            //     out var userId))
            // {
            //     imageEntity.LastSavedBy = userId;
            // }

            _context.Users.Remove(imageEntity);
            await _context.SaveChangesAsync();
        }
    }
}
