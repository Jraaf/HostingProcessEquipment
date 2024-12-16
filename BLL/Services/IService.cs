namespace BLL.Services;

public interface IService<TDTO,CreateTDTO,T>
    where T : class
    where CreateTDTO : class
    where TDTO : class
{
    Task<TDTO> GetAllAsync();
    Task AddAsync(CreateTDTO dto);
}
