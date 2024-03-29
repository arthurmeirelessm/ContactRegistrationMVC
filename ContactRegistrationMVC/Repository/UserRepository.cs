﻿using ContactRegistrationMVC.Data;
using ContactRegistrationMVC.Helpers;
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
            _dataContext = dataContext;
        } 
        public UserModel Add(UserModel user)
        {
            // Registration in Database

            UserModel identificationIfSameLogin = SameLogin(user);
            UserModel userModelSameEmail = SameEmail(user);
         
            user.CreatedAt = DateTime.Now;
            user.SetPasswordHash();
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

        public UserModel SameLogin(UserModel user)
        {
            var identificationNumber = _dataContext.Users.FirstOrDefault(x => x.Login == user.Login);

            return identificationNumber;
        }
        public UserModel SameEmail(UserModel user)
        {
            var identificationEmail = _dataContext.Users.FirstOrDefault(x => x.Email == user.Email);

            return identificationEmail;
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

        public List<UserModel> SeachAll()
        {
             return _dataContext.Users.ToList();
        }

        public UserModel ComparateUserName(DataLoginModel dataLoginModel)
        {
            var comparateIfUserNameIsSame = _dataContext.Users.FirstOrDefault(x => x.Login == dataLoginModel.UserName);

            return comparateIfUserNameIsSame;
        }

        public UserModel ComparatePassword(DataLoginModel dataLoginModel)
        {

            //O hash entra aqui tambem passado no password digitado pelo usuario e que esta como paramentro 
            var comparateIfPasswordIsSame = _dataContext.Users.FirstOrDefault(x => x.Password == dataLoginModel.Password.GenerateHash());


            return comparateIfPasswordIsSame;
        }

        public UserModel ComparateUserNameAndEmailToReset(string userName, string email)
        {
            var comparateIfUserNameAndEmailIsSame = _dataContext.Users.FirstOrDefault(x => x.Login == userName && x.Email == email);

            return comparateIfUserNameAndEmailIsSame;
        }
    }
}



