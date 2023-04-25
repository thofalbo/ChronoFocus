namespace Core.Configurations;
public class TokenService
{
    public static string GenerateToken(Usuario usuario, string chave)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(chave);

        var acoes = string.Join(",", usuario.Permissoes.Select(x => new Permissao{
            Id = x.Id,
            IdUsuario = x.IdUsuario,
            IdAcao = x.IdAcao,
            IdControlador = x.IdControlador,
            Acesso = x.Acesso
        }));

        // var controladores = string.Join(",", usuario.Permissoes.Select(x => x.Controlador.Nome));
        // var acoes = string.Join(",", usuario.Permissoes.Select(x => x.Acao.Nome));

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim("idUsuario", usuario.Id.ToString()),
                new Claim("emailUsuario", usuario.Email),
                new Claim("apelidoUsuario", usuario.Apelido),
                new Claim("acoes", acoes)
            }),

            Expires = DateTime.UtcNow.AddHours(2),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }

    public static JwtSecurityToken handler(string jwtToken)
    {
        var handler = new JwtSecurityTokenHandler();
        var token = handler.ReadToken(jwtToken) as JwtSecurityToken;

        return token;
    }

    public static int IdUsuarioLogado(string jwtToken)
    {
        var token = handler(jwtToken);

        int.TryParse(token.Claims.FirstOrDefault(x => x.Type == "idUsuario")?.Value, out int idUsuarioLogado);

        return idUsuarioLogado;
    }

    public static string BuscaAcoes(string jwtToken)
    {
        var token = handler(jwtToken);

        return token.Claims.ToList()[3].Value;
    }
}