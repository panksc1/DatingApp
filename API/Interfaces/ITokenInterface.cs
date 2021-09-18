using API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Interfaces
{
    //A contract between itself and any class that implements it
    //Easy to mock an interface when testing the application
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
