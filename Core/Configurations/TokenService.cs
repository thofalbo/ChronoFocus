namespace Core.Configurations
{
    public class TokenService
    {
        public static string GenerateToken(Usuario usuario, string chave)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(chave);

            var permissoes = string.Join(",", usuario.PermissoesUsuarios.Select(x => x.IdPermissao));
            var rotas = string.Join(",", usuario.PermissoesUsuarios.Select(x => x.Permissao.Rota));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim("idUsuario", usuario.Id.ToString()),
                new Claim("loginUsuario", usuario.Login),
                new Claim("rotas", rotas)
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
}
