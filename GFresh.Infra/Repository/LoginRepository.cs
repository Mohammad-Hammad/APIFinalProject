using Dapper;
using GFresh.Core.Common;
using GFresh.Core.Data;
using GFresh.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace GFresh.Infra.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly IDbContext _dbContext;
        public LoginRepository(IDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public UserLogin Authintication(UserLogin UserLogIn)
        {
            var p = new DynamicParameters();
            p.Add("@user_name", UserLogIn.UserName, dbType: DbType.String);
            p.Add("@password_user", UserLogIn.PassWord, dbType: DbType.String);

            IEnumerable<UserLogin> result = _dbContext.Connection.Query<UserLogin>
             ("User_Package.Login", p,commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();

        }

    }
}

