using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projector.Models.DAL;
using Projector.Models;

namespace Projector.Models
{
    public class PersonService:IDisposable
    {
        private ProjectorContext db;
        public PersonService(ProjectorContext db)
        {
            this.db = db;
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