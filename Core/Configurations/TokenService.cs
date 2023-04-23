namespace Core.Configurations;
public class TokenService
{
    public static string GenerateToken(Usuario usuario, string chave)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(chave);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim("idUsuario", usuario.Id.ToString()),
                new Claim("emailUsuario", usuario.Email),
                new Claim(ClaimTypes.Name, usuario.Apelido)
            }),

            Expires = DateTime.UtcNow.AddHours(2),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }

    public static int UsuarioLogado(string jwtToken)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.ReadJwtToken(jwtToken);

        var idUsuarioLogado = int.Parse(token.Claims.FirstOrDefault(c => c.Type == "idUsuario")?.Value);
        return idUsuarioLogado;
    }
}