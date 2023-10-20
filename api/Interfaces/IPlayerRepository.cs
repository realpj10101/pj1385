namespace api.Interfaces;

public interface IPlayerRepository
{
    public Task<List<PlayerDto>> GetAllAsync(CancellationToken cancellationToken);
    // public Task<PlayerDto?> GetByEmail(string userEmail);
    // public Task<UpdateResult> UpdatePlayerById(string playerId, Player playerIn);
    // public Task<DeleteResult> Delete(string playerId);
}
