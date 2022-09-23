namespace BusinessLayer.Services
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using BusinessLayer.Interfaces;
    using DataLayer.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;

    public abstract class Service<TCreateUpdateDTO, TDTO, T> : IService<TCreateUpdateDTO, TDTO, T> where TCreateUpdateDTO 
        : class where TDTO : class where T : class
    {
        private readonly IDataRepository<T> _dataRepository;
        private readonly IMapper _mapper;
        private readonly IDatabaseScope _databaseScope;

        public Service(IDataRepository<T> dataRepository, IMapper mapper, IDatabaseScope databaseScope)
        {
            _dataRepository = dataRepository;
            _mapper = mapper;
            _databaseScope = databaseScope;
        }

        public async Task<IEnumerable<TDTO>> GetAllAsync()
        {
            var items = await _dataRepository.AsReadOnly().ProjectTo<TDTO>(_mapper.ConfigurationProvider).ToListAsync();

            return items;
        }

        public async Task<TDTO> GetAsync(long id)
        {
            var item = await _dataRepository.GetAsync(id);

            if (item == null)
            {
                return null;
            }

            var itemDTO = _mapper.Map<TDTO>(item);

            return itemDTO;
        }

        public abstract Task AddAsync(TCreateUpdateDTO itemDTO);

        public abstract Task UpdateAsync(TCreateUpdateDTO itemDTO, long id);

        public async Task DeleteAsync(long id)
        {
            var item = await _dataRepository.GetAsync(id);
            _dataRepository.Delete(item);
            await _databaseScope.SaveAsync();
        }
    }
}
