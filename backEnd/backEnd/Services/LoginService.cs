using MySqlConnector;
using System.Security.Claims;

namespace backEnd.Services
{
    public class LoginService
    {
        public async Task<ClaimsPrincipal>? Login(string username, string password)
        {
            MySqlConnection mySqlConnection = new MySqlConnection("server=localhost;initial catalog=logindb;uid=root;password=wml096");
            await mySqlConnection.OpenAsync();

            MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandText = $"SELECT * FROM usuario WHERE username = '{username}' AND password = '{password}'";

            MySqlDataReader reader = mySqlCommand.ExecuteReader();

            if (await reader.ReadAsync())
            {

                //Resgatar ID e Nome de usuário
                int userId = reader.GetInt32(0);
                string name = reader.GetString(1);

                //Direitos de acesso
                List<Claim> direitosAcesso = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier,userId.ToString()),
                    new Claim(ClaimTypes.Name,name)
                };

                var identity = new ClaimsIdentity(direitosAcesso, "Identity.Login");
                var userPrincipal = new ClaimsPrincipal(new[] { identity });

                return userPrincipal;                
            }
            return null;
        }
    }
}
