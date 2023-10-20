namespace api.Interfaces;

public interface IRegisterRepository
{
    public Task<PlayerDto?> Create(RegisterPlayerDto userInput, CancellationToken cancellationToken);
}
