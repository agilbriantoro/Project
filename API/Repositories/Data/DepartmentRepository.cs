﻿using API.Contexts;
using API.Models;

namespace API.Repositories.Data
{
    public class DepartmentRepository : GeneralRepository<int, Department>
    {
        public DepartmentRepository(MyContext context) : base(context)
        {
        }
    }
}
