namespace BLL.Services.Base;


public interface IService<T, TDTO, CreateTDTO>
    where T : class
    where TDTO : class
    where CreateTDTO : class
{
    Task<List<TDTO>> GetAllAsync();
    Task<TDTO> AddAsync(CreateTDTO model);
}

