using RestAPIWithASP_Net5.Data;
using RestAPIWithASP_Net5.Model;
using RestAPIWithASP_Net5.Model.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RestAPIWithASP_Net5.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MySqlContext Context;

        public UserRepository(MySqlContext mySqlContext)
        {
            Context = mySqlContext;
        }

        public User ValidateCredencials(UserVO user)
        {
            //1º ENCRIPTAR A SENHA QUE CHEGA ATRAVES DO USERVO, PASSANDO OS DADOS PARA O METODO
            //DEPOIS RETORNA O USER COM A VERIFICAÇÃO
            var pass = ComputeHash(user.Password, new SHA256CryptoServiceProvider());
            return Context.Users.FirstOrDefault(u => u.UserName == user.UserName && u.Password == pass);
        }

        public User ValidateCredencials(string userName)
        {
            return Context.Users.FirstOrDefault(u => u.UserName == userName);
        }

        //METODO PARA FAZER LOGOFF DA API
        public bool RevokeToken(string userName)
        {
            var user = Context.Users.FirstOrDefault(u => u.UserName == userName);

            if (user is  null) return false;
            user.RefreshToken = null;
            Context.SaveChanges();

            return true;
        }
        //METODO PARA ACTUALIZAROS DADOS DO USER - TOKEN
        public User RefreshUserInfo(User user)
        {
            if (!Context.Users.Any(u => u.Id == user.Id)) return null;
            var result = Context.Users.FirstOrDefault(u => u.Id == user.Id);
            if (result != null)
            {
                try
                {
                    Context.Entry(result).CurrentValues.SetValues(user);
                    Context.SaveChanges();
                    return result;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return result;
        }


        //METODO PARA ENCRIPTAR A PASSWORD RECEBIDA
        private string ComputeHash(string input, SHA256CryptoServiceProvider algotithm)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = algotithm.ComputeHash(inputBytes);
            return BitConverter.ToString(hashBytes);
        }

       
    }
}
