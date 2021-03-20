using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMode.SQL.Model.Data.SQL;
using System.Security.Cryptography;
using Microsoft.AspNet.Identity;

namespace CRUD_WinForm.Data.Services.Services
{
    public class NetUsersRepository
    {
        private readonly CRUD_WinFormEntities db = new CRUD_WinFormEntities();

        public bool IniciarSesion(string user, string pass) 
        {
            NetUser model = (from dbContext in db.NetUser where dbContext.UserName == user select dbContext).Single();
            if(ValidationPassWord(model.IDUser, model.UserPass))
            {
                return true;
            }
            
            return false;
        }

        public bool CrearUsuario(NetUser model)
        {
            try
            {
                db.NetUser.Add(model);
                db.SaveChanges();
            }catch(Exception e)
            {
                return false;
            }

            return true;
        }

        public string Encrypt(string pass)
        {
            byte[] salt;
            byte[] bytes;
            if(pass == null)
            {
                pass = "DummyPass123";
            }

            using(Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(pass, 16, 1000))
            {
                salt = rfc2898DeriveBytes.Salt;
                bytes = rfc2898DeriveBytes.GetBytes(32);
            }
            byte[] numArray = new byte[49];
            Buffer.BlockCopy(salt, 0, numArray, 1, 16);
            Buffer.BlockCopy(bytes, 0, numArray, 17, 32);

            return Convert.ToBase64String(numArray);
        }

        public bool ValidationPassWord(int idUser, string pass)
        {
            bool Exito = false;
            var hasher = new PasswordHasher();

            var User = (from contextoData in db.NetUser where contextoData.IDUser == idUser select contextoData).Single();
            var Result = hasher.VerifyHashedPassword(User.UserPass, pass);

            if(Result != PasswordVerificationResult.Failed)
            {
                return Exito = true;
            }

            return Exito;
        }
    }
}
