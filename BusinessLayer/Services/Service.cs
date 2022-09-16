namespace BusinessLayer.Services
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using BusinessLayer.Interfaces;
    using DataLayer;
    using DataLayer.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;

    public abstract class Service<TDTO, T> : IService<TDTO, T> where TDTO : class where T : class
    {
        private readonly IDataRepository<T> _dataRepository;
        private readonly IMapper _mapper;
        private readonly DatabaseScope _databaseScope;

        public Service(IDataRepository<T> dataRepository, IMapper mapper, DatabaseScope databaseScope)
        {
            _dataRepository = dataRepository;
            _mapper = mapper;
            _databaseScope = databaseScope;
        }

        public async Task<IEnumerable<TDTO>> GetAll()
        {
            var items = await _dataRepository.GetAll().ProjectTo<TDTO>(_mapper.ConfigurationProvider).ToListAsync();

            return items;
        }

        public async Task<TDTO> Get(long id)
        {
            var item = await _dataRepository.Get(id);

            if (item == null)
            {
                return null;
            }

            var itemDTO = _mapper.Map<TDTO>(item);

            return itemDTO;
        }

        public abstract Task Add(TDTO itemDTO);

        public abstract Task Update(TDTO itemDTO, long id);

        public async Task Delete(long id)
        {
            var item = await _dataRepository.Get(id);
            _dataRepository.Delete(item);
            _databaseScope.Save();
        }
    }
}
