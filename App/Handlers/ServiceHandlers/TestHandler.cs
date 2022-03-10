using App.Handlers.ServiceHandlers.Interfaces;
using Domain.DataModels;
using Services.Interfaces;

namespace App.Handlers.ServiceHandlers;

public class TestHandler : ITestHandler
{
    private ITestService _testService;

    public TestHandler(ITestService testService) => _testService = testService;
    
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
        return await _testService.GetAllByPredicate(predicate);
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
        return await _testService.Create(model);
    }
}