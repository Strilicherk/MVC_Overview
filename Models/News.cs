using System.Collections.Generic;
using System.IO;
using E_Players_Application.Interfaces;

namespace E_Players_Application.Models
{
    public class News : EPlayersBase , ITeam
    {

        public int IdNews { get; set; }
        
        public string Title { get; set; }
        
        public string Text { get; set; }
        
        public string Image { get; set; }
        
        
        private const string PATH = "Database/News.csv";

        public News()
        {
            CreateFolderAndFile(PATH);
        }

        public string PrepareCSV(News n)
        {
            return $"{n.IdNews};{n.Title};{n.Text};{n.Image}";
        }

        public void Create(News n)
        {
            string[] lines = { PrepareCSV(n)};
            File.AppendAllLines(PATH, lines);
        }

        public List<News> ReadAll()
        {
            List<News> newsList = new List<News>();
            string[] lines = File.ReadAllLines(PATH);

            foreach (var item in lines)
            {
                string[] line = item.Split(";");

                News news = new News();

                news.IdNews = int.Parse(line[0]);
                news.Title = line[1];
                news.Text = line[2];
                news.Image = line[3];

                newsList.Add(news);
            }

            return newsList;
        }

        public void Update(News n)
        {
            List<string> linesUpdate = ReadAllLinesCSV(PATH);

            linesUpdate.RemoveAll( x => x.Split(";")[0] == n.IdNews.ToString());

            linesUpdate.Add(PrepareCSV(n));

            RewriteCSV(PATH, linesUpdate);
        }

        public void Delete(int id)
        {
            List<string> linesRemove = ReadAllLinesCSV(PATH);

            linesRemove.RemoveAll( x => x.Split(";")[0] == id.ToString());

            RewriteCSV(PATH, linesRemove);
        }
    }
}