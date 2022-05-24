using ContactRegistrationMVC.Data;
using ContactRegistrationMVC.Models;
using ContactRegistrationMVC.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ContactRegistrationMVC.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dataContext;

        public UserRepository(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }
        public UserModel Add(UserModel user)
        {
            // Registration in Database

            user.CreatedAt = DateTime.Now;
            _dataContext.Users.Add(user);
            _dataContext.SaveChanges();

            return user;
        }

        public bool Delete(int id)
        {
            UserModel identificationDb = ListById(id);

            if (identificationDb is null)
            {
                throw new System.Exception("Error of delete (No Id compatible)");
            }

            _dataContext.Users.Remove(identificationDb);

            _dataContext.SaveChanges();

            return true;

        }

        public UserModel ListById(int id)
        {
            var identification = _dataContext.Users.FirstOrDefault(x => x.Id == id);

            return identification;
        }

        public List<UserModel> SeachAll()
        {
            return _dataContext.Users.ToList();
        }

        public UserModel UpdateEdit(UserModel user)
        {
            UserModel identificationDb = ListById(user.Id);

            if (identificationDb is null)
            {
                throw new System.Exception("Error of update (No Id compatible)");
            }

            identificationDb.Name = user.Name;
            identificationDb.Login = user.Login;
            identificationDb.Email = user.Email;
            identificationDb.UserType = user.UserType;
            identificationDb.DateUpAt = DateTime.Now;

            _dataContext.Users.Update(identificationDb);
            _dataContext.SaveChanges();

            return identificationDb;
        }
    }
}
