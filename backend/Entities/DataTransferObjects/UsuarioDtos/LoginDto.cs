using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects;
public class LoginDto
{
    public string Email { get; set; }

    [DataType(DataType.Password)]
    public string Senha { get; set; }
}