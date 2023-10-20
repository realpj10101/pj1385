namespace api.Models
{
    public record Player(
          [property: BsonId, BsonRepresentation(BsonType.ObjectId)] string? Id,
          string Email,
          string Password,
          string ConfrimPassword
    );
    
}