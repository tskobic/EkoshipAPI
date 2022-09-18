namespace BusinessLayer.Services
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using BusinessLayer.Interfaces;
    using DataLayer.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;

    public abstract class Service<TDTO, T> : IService<TDTO, T> where TDTO : class where T : class
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
            var items = await _dataRepository.GetAll().ProjectTo<TDTO>(_mapper.ConfigurationProvider).ToListAsync();

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

        public abstract Task AddAsync(TDTO itemDTO);

        public abstract Task UpdateAsync(TDTO itemDTO, long id);

        public async Task DeleteAsync(long id)
        {
            var item = await _dataRepository.GetAsync(id);
            _dataRepository.Delete(item);
            _databaseScope.SaveAsync();
        }
    }
}
