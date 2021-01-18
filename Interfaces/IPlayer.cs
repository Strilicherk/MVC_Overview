using System.Collections.Generic;
using E_Players_Application.Models;

namespace MVC_Overview.Interfaces
{
    public interface IPlayer
    {
         void Create (Player p);
         List<Player> ReadAll();
         void Update(Player p);
         void Delete(int id);
    }
}