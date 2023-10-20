using api.Controllers.Helpers;

namespace api.Controllers
{
   
    public class RegisterController : BaseApiController
    {

        #region token
        private readonly IRegisterRepository _registerRepository;

        public RegisterController(IRegisterRepository registerRepository)
        {
            _registerRepository = registerRepository;
        }
        #endregion

        [HttpPost("register")]
        public async Task<ActionResult<PlayerDto>> Register(RegisterPlayerDto userInput, CancellationToken cancellationToken)
        {
            if (userInput.Password != userInput.ConfrimPassword)
                return BadRequest("Passwords dont match");

            PlayerDto? playerDto = await _registerRepository.Create(userInput, cancellationToken);

            if (playerDto is null)
                return BadRequest("Email is taken.");

            return playerDto;
        }
     
    }
}