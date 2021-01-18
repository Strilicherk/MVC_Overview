using System;
using System.Collections.Generic;
using System.IO;
using MVC_Overview.Interfaces;

namespace E_Players_Application.Models
{
    public class Player : EPlayersBase , IPlayer
    {
        
        public int IdPlayer { get; set; }
        
        public string Name { get; set; }
        
        public int IdTeam { get; set; }
        
        private const string PATH = "Database/Player.csv";

        public Player()
        {
            CreateFolderAndFile(PATH);
        }
        public string PrepareCSV(Player p)
        {
            return $"{p.IdPlayer};{p.Name};{p.IdPlayer}";
        }
        public void Create(Player p)
        {
            string[] lines = {PrepareCSV(p)};
            File.AppendAllLines(PATH, lines);
        }
        public List<Player> ReadAll()
        {
            List<Player> playerList = new List<Player>();
            string[] lines = File.ReadAllLines(PATH);

            foreach (var item in lines)
            {
                string[] line = item.Split(";");

                Player player = new Player();

                player.IdPlayer = Int32.Parse(line[0]);
                player.Name = line[1];
                player.IdTeam = int.Parse(line[2]);

                playerList.Add(player);
            }

            return playerList;
        }
        public void Update(Player p)
        {
            
            List<string> linesUpdate = ReadAllLinesCSV(PATH);
        

            linesUpdate.RemoveAll( x => x.Split(";")[0] == p.IdPlayer.ToString() ); 
        

            linesUpdate.Add( PrepareCSV(p) );


            RewriteCSV(PATH,linesUpdate);

        }
    
    
        
        public void Delete(int id)
        {
            
            List<string> linesUpdate = ReadAllLinesCSV(PATH);
        

            linesUpdate.RemoveAll( x => x.Split(";")[0] == id.ToString() ); 
        
            
            RewriteCSV(PATH,linesUpdate);
        
        }
        


    }
}