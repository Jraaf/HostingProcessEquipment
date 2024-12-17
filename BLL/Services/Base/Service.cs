using AutoMapper;
using BLL.DTO;
using DAL.Entities;
using DAL.Repositories.Repo;

namespace BLL.Services.Base;

public class Service<T, TDTO, CreateTDTO> : IService<T, TDTO, CreateTDTO>
    where T : class
    where TDTO : class
    where CreateTDTO : class
{
    private readonly IRepo<T, int> _repo;
    private readonly IMapper _mapper;

    public Service(IRepo<T, int> repo,IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<TDTO> AddAsync(CreateTDTO model)
    {
        var data = _mapper.Map<T>(model);
        var result = await _repo.AddAsync(data);
        return _mapper.Map<TDTO>(result);
    }

    public async Task<List<TDTO>> GetAllAsync()
    {
        var data = await _repo.GetAllAsync();
        return _mapper.Map<List<TDTO>>(data);
    }
}
