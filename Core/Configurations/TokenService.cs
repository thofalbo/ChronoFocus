namespace Core.Configurations;
public class TokenService
{
    public static string GenerateToken(Usuario usuario, string chave)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(chave);

        // foreach (var permissao in usuario.Permissoes){}

        // var usuarios = string.Join(",", usuario.Permissoes.Select(x => x.IdUsuario));
        // var controladores = string.Join(",", usuario.Permissoes.Select(x => x.IdControlador));
        // var acoes = string.Join(",", usuario.Permissoes.Select(x => x.IdAcao));
        // var rotasControladores = string.Join(",", usuario.Permissoes.Select(x => x.Controlador.Nome));
        // var rotasAcao = string.Join(",", usuario.Permissoes.Select(x => x.Acao.Nome));

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim("idUsuario", usuario.Id.ToString()),
                new Claim("loginUsuario", usuario.Login)
                // new Claim("rotasControladores", rotasControladores),
                // new Claim("rotasAcao", rotasAcao),
                // new Claim("usuarios", usuarios),
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

    public static string BuscaPermissoes(string jwtToken, int claim)
    {
        var token = handler(jwtToken);

        return token.Claims.ToList()[claim].Value;
    }
}