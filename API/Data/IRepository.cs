using API.Dtos;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Data
{
    public interface IRepository
    {
        Task<List<Song>> GetAll();
        Task<Song> Get(int id);
        Task<bool> Add(AddSong item);
        Task<Song> Update(UpdateSong item);
        Task<bool> Delete(int id);
    }
}
