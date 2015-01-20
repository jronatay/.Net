using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projector.Models.DAL;
using Projector.Models;

namespace Projector.Models
{
    public class PersonService:PersonInterface ,IDisposable
    {
        private ProjectorContext db;
        public PersonService(ProjectorContext db)
        {
            this.db = db;
        }
        public void Save(Projector.Models.Person person)
        {
            db.Persons.Add(person);
            db.SaveChanges();
        }
        public Boolean SignIn(SignInInputModel user)
        {
            var sql = db.Persons.Where(p => p.username == user.UserName && p.password == user.Password).ToList();
            if (sql.Count > 0)
            {
                Person p = new Person();
                foreach (var loggedin in sql)
                {
                    p = loggedin;
                }
                HttpContext.Current.Session["user_firstname"] = p.first_name;
                HttpContext.Current.Session["user_id"] = p.id;
            }
            else
            {
                return false;
            }
            return true;
        }
        public Boolean IsLoggedIn()
        {
            if (HttpContext.Current.Session["user"] != null || !HttpContext.Current.Session.IsNewSession) return true; else return false;
        }
        public void signout()
        {
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session.Abandon();
            
           
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