namespace API
{
    using AutoMapper;
    using BusinessLayer.DTOs;
    using DataLayer.Models;

    public class DTOMapping : Profile
    {
        public DTOMapping()
        {
            CreateMap<User, UserDTO>();
            CreateMap<TodoItem, TodoItemDTO>();
            CreateMap<TodoItem, TodoItemSelectionListDTO>();
        }
    }
}
