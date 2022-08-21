using Microsoft.AspNetCore.Mvc;
using DemoMyExperience.Domain.DbModels.Contexts.DemoMyExperience;
using DemoMyExperience.Interfaces;
using DemoMyExperience.Services;
using DemoMyExperience.Domain.DbModels.Contexts.DemoMyExperience.Models;
using AutoMapper;
using DemoMyExperience.Models;

namespace DemoMyExperience.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        
        private readonly ILogger<UsersController> _logger;
        private readonly ICrud<UserRepository> _service;
        private readonly IMapper _mapper;

        public UsersController(ILogger<UsersController> logger, ICrud<UserRepository> service, IMapper mapper)
        {
            _logger = logger;
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> GetAll()
        {
            var userRepository = await _service.GetAll();
            return _mapper.Map<IEnumerable<User>>(userRepository);
        }

        [HttpGet("{id}")]
        public async Task<User> Get(Guid id)
        {
            var imageRepository = await _service.Get(id);
            return _mapper.Map<User>(imageRepository);
        }

        [HttpPost]
        public async Task Create(User user)
        {
            var imageRepository = _mapper.Map<UserRepository>(user);
            await _service.Create(imageRepository);
        }

        [HttpPut]
        public async Task Update(User user)
        {
            var imageRepository = _mapper.Map<UserRepository>(user);
            await _service.Update(imageRepository);
        }

        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await _service.Delete(id);
        }
    }
}