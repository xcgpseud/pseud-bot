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
    public class TestService : ITestService
    {
        private ITestRepository _testRepository;

        public TestService(ITestRepository testRepository) => _testRepository = testRepository;
        
        public async Task<Test?> GetByGuid(Guid guid)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Test>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Test>> GetAllByPredicate(Func<Test, bool> predicate)
        {
            // (test) => test.Name.ToLower().Contains(param1)
            bool EntityPredicate(TestEntity entity) => predicate(entity.Adapt<Test>());
            
            var results = await _testRepository.GetAllByPredicate(EntityPredicate);

            var modelResults = results.Select(x => x.Adapt<Test>());

            return modelResults;
        }

        public async Task<Test> Edit(Test model)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(Test model)
        {
            throw new NotImplementedException();
        }

        public async Task<Test?> Create(Test model)
        {
            var resultEntity = await _testRepository.Create(model.Adapt<TestEntity>());

            return resultEntity?.Adapt<Test>();
        }
    }
}
