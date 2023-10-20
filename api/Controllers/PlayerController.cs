using api.Controllers.Helpers;

namespace api.Controllers
{
   
    public class PlayerController : BaseApiController
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerController(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerDto>>> GetAll(CancellationToken cancellationToken)
        {
            List<PlayerDto> playerDtos = await _playerRepository.GetAllAsync(cancellationToken);

            if (!playerDtos.Any())
                return NoContent();

            return playerDtos;
        }

        // [HttpGet("get-by-email/{playerEmail}")]
        // public async Task<ActionResult<Player>> GetByEmail(string playerEmail)
        // {
           
        //     Player player = await _collection.Find<Player>(player => player.Email == playerEmail).FirstOrDefaultAsync();

        //     if (player is null)
        //         return NotFound("No user found");

        //     return player;
        // }


        // [HttpPut("update/{playerId}")]
        // public async Task<ActionResult<UpdateResult>> UpdatePlayerById(string playerId, Player playerIn)
        // {

        //     var updatedPlayer = Builders<Player>.Update
        //     .Set(doc => doc.Email, playerIn.Email.ToLower().Trim());
            
        //     return await _collection.UpdateOneAsync<Player>(doc => doc.Email == playerId, updatedPlayer);
        // }

        // [HttpDelete("delete/{playerId}")]
        // public async Task<ActionResult<DeleteResult>> Delete(string playerId)
        // {
        //     return await _collection.DeleteOneAsync<Player>(doc => doc.Id == playerId);
        // }
    }
}