using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projector.Models.DAL;
using Projector.Models;
using System.Text.RegularExpressions;

namespace Projector.Models
{
    public class PersonService:IDisposable
    {
        
        private ProjectorContext db;
        public PersonService(ProjectorContext db)
        {
            this.db = db;
        }
        public Boolean IsNotNull(Person person)
        {
            if (!person.first_name.Equals(null) && !person.first_name.Equals(" ") && !person.last_name.Equals(null) && !person.last_name.Equals(" ")
                && !person.username.Equals(null) && !person.username.Equals(" ") && !person.password.Equals(null) && !person.password.Equals(" "))
            {
                return true;
            }
            else
            {
                return false;
            }
           
                      
        }
        
        public Boolean IsLengthRight(Person person)
        {
            int firstnamelength = person.first_name.Count();
            int lastnamelength = person.last_name.Count();
            int usernamelength = person.password.Count();
            int passwordlength = person.password.Count();
            if (firstnamelength > 2 && firstnamelength < 51 && lastnamelength > 2 && lastnamelength < 51 &&
                usernamelength > 4 && passwordlength > 6 && passwordlength < 12)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean IsInputMatchesRegex(Person person)
        {
            string namePattern = @"^[^\d^`~!@#\$%\^&\*\(\)\-_\+=<>\?,;:'\|/\[\]\{\}""]+[^\d^`~!@#\$%\^&\*\(\)\-_\+=<>\?,;:\|/\[\]\{\}""]$";
            string passwordPattern = @"^[^\s^<>]*$";
            string emailPattern = @"[\w-]+@([\w-]+\.)+[\w-]+";
            Regex nameRegex = new Regex(namePattern);
            Regex passwordRegex = new Regex(passwordPattern);
            Regex emailRegex = new Regex(emailPattern);
            if (nameRegex.IsMatch(person.first_name) && nameRegex.IsMatch(person.last_name) && passwordRegex.IsMatch(person.password) && emailRegex.IsMatch(person.username))
            {
                return true;
            }
            else
            {
                return false;
            }
            

        }


        public void Save(Projector.Models.Person person)
        {
            //Save Person to dbase
            db.Persons.Add(person);
            db.SaveChanges();
        }
        public Boolean SignIn(SignInInputModel signinInput)
        {
            //check if there is such user
            var sqlresult = db.Persons.Where(person => person.username == signinInput.UserName && person.password == signinInput.Password).ToList();
            if (sqlresult.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
        public Person userLogged(SignInInputModel user)
        {
            //Get user logged in profile
            var sql = db.Persons.Where(p => p.username == user.UserName && p.password == user.Password).First();
            return sql;
        }

        public Boolean IsUserNameExist(string userName)
        {
            var result=db.Persons.Where(person=> person.username==userName ).ToList();

            return result.Count>0;
            

        }
        
       
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}