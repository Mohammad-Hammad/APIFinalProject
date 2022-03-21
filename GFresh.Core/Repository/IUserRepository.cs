﻿using GFresh.Core.Data;
using GFresh.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GFresh.Core.Repository
{
    public interface IUserRepository
    {
        public string Register(RegisterUser registerUser);
        public Task<List<Category>> GetAllCategorsAndProduct();
        public List<ProductSearch> SearchOfProduct(Product product);


    }
}
