using Domain.DataModels;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Repositories;
using Database.Repositories.Interfaces;
using Domain.Entities;
using Mapster;

namespace Services
{
    public class TestService : CrudService<Test, TestEntity>, ITestService
    {
        public TestService(ITestRepository repository) : base(repository)
        {
        }
    }
}
