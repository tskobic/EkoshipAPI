using BusinessLayer.DTOs;
using BusinessLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface ITodoItemService<TSelectionItemDTO, TCreateUpdateDTO, TDTO, T> : IService<TCreateUpdateDTO, TDTO, T>
    {
        public Task<IEnumerable<TSelectionItemDTO>> GetSelectionListAsync();
    }
}
