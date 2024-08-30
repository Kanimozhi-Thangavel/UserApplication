using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UserManagement.DTO.User;
using UserManagement.Models;
using UserManagement.Repositary.IRepository;

namespace UserManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserController(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAll()
        {
            var users = await _userRepository.GetAll();

            var countryDto = _mapper.Map<List<UserDTO>>(users);


            if (users == null)
            {
                return NoContent();
            }

            return Ok(countryDto);

        }


        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<User>> GetById(int id)
        {

            var user = await _userRepository.GetById(id);

            var countrydto = _mapper.Map<UserDTO>(user);

            if (user == null)
            {
                return NotFound();
            }
            return Ok(countrydto);

        }


        [HttpPost]
        public async Task<ActionResult<CreateUserDTO>> Create([FromBody] CreateUserDTO Createuserdto)
        {

            var User = _mapper.Map<User>(Createuserdto);

            await _userRepository.Create(User);

            return CreatedAtAction("GetById", new { id = User.Id }, User);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<User>> Update(int id, [FromBody] UpdateUserDTO Userdto)
        {
            if (Userdto == null || id != Userdto.Id)
            {
                return BadRequest();
            }
            var user = _mapper.Map<User>(Userdto);
            await _userRepository.Update(user);
            return NoContent();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var user = await _userRepository.GetById(id);

            if (user == null)
            {
                return NotFound();
            }
            await _userRepository.Delete(user);
            return NoContent();
        }

    }
}