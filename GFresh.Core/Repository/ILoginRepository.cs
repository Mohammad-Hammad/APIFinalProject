using GFresh.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace GFresh.Core.Repository
{
    public interface ILoginRepository
    {
        public UserLogin Authintication(UserLogin UserLogIn);
    }
}
