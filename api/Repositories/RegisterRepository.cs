namespace api.Repositories
{
    public class RegisterRepository : IRegisterRepository
    {
        private const string _collectionName = "players";
        private readonly IMongoCollection<Player>? _collection;

        public RegisterRepository(IMongoClient client, IMongoDbSettings dbSettings)
        {
            var database = client.GetDatabase(dbSettings.DatabaseName);
            _collection = database.GetCollection<Player>(_collectionName);
        }

        public async Task<PlayerDto?> Create(RegisterPlayerDto userInput, CancellationToken cancellationToken)
        {
            bool doesPlayerExist = await _collection.Find<Player>(player =>
            player.Email == userInput.Email.ToLower().Trim()).AnyAsync(cancellationToken);

            if (doesPlayerExist)
                return null;

            //if player doesnot exist create a new
            Player player = new Player(
                Id: null,
                Email: userInput.Email.ToLower().Trim(),
                Password: userInput.Password,
                ConfrimPassword: userInput.ConfrimPassword
            );

            if (_collection is not null)
                await _collection.InsertOneAsync(player, null, cancellationToken);

            if (player.Id is not null)
            {
                PlayerDto playerDto = new PlayerDto(
                    Id: player.Id,
                    Email: player.Email
                );

                return playerDto;
            }

            return null;
        }
    }
}