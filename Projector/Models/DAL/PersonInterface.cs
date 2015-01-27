using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projector.Models;

namespace Projector.Models.DAL
{
    interface PersonInterface:IDisposable
    {
        void Save(Person person);
        Boolean SignIn(SignInInputModel user);
    }
}
