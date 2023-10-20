namespace api.DTOs
{
    public record RegisterPlayerDto(
        [MaxLength(50), RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,5})+)$", ErrorMessage ="Bad Email Format.")] string Email,
        [DataType(DataType.Password), MinLength(7), MaxLength(20)] string Password,
        [DataType(DataType.Password), MinLength(7), MaxLength(20)] string ConfrimPassword
    );
}