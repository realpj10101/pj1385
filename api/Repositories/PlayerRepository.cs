namespace api.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        #region db and token

           IMongoCollection<Player>? _collection;

        public PlayerRepository(IMongoClient client, IMongoDbSettings dbSettings)
        {
            var database = client.GetDatabase(dbSettings.DatabaseName);
            _collection = database.GetCollection<Player>("players");
            // _tokenService = tokenService;
        }

        #endregion

        public async Task<List<PlayerDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            List<Player> players = await _collection.Find<Player>(new BsonDocument()).ToListAsync(cancellationToken);

            List<PlayerDto> playerDtos = new List<PlayerDto>();

            if (players.Any())
            {
                foreach (Player player in players)
                {
                    PlayerDto playerDto = new PlayerDto(
                        Id: player.Id!,
                        Email: player.Email
                    );

                    playerDtos.Add(playerDto);
                }

                return playerDtos;
            }

            return playerDtos;
        }   


        // public async Task<PlayerDto?> GetByEmail(string playerEmail)
        // {
        //     Player player = await _collection.Find<Player>(player => player.Email == playerEmail).FirstOrDefaultAsync();

        //     return null;

        // }

        //  public async Task<UpdateResult> UpdatePlayerById(string playerId, Player playerIn)
        // {
        //     var updatedPlayer = Builders<Player>.Update
        //     .Set(doc => doc.Email, playerIn.Email.ToLower().Trim());
            

        //     return await _collection.UpdateOneAsync<Player>(doc => doc.Id == playerId, updatedPlayer);
        // }

        //  public async Task<DeleteResult> Delete(string playerId)
        // {
        //     return await _collection.DeleteOneAsync<Player>(doc => doc.Id == playerId);
        // }
        }
    
    }
    

