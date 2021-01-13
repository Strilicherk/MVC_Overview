using System.Collections.Generic;
using E_Players_Application.Models;

namespace MVC_Overview.Interfaces
{
    public interface INews
    {
         void Create(News n);
         List<News> ReadAll();
         void Update(News n);
         void Delete(int id);
    }
}