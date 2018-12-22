using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Validators.Services
{
    public interface IMyService
    {
        bool UserExists(string user);
    }

    public class MyService : IMyService
    {
        public bool UserExists(string user)
        {
            // TODO: inject Database access
            return true;
        }
    }
}
