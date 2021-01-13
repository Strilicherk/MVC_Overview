using System;
using E_Players_Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MVC_Overview.Controllers
{
    [Route("News")]
    public class NewsController : Controller
    {
        News newsModel = new News();
        [Route("Listar")]

        public IActionResult Index()
        {
            ViewBag.News = newsModel.ReadAll();
            return View();
        }
        [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection form)
        {
            News newNews = new News();
            newNews.IdNews = Int32.Parse(form["IdNews"]);
            newNews.Title = form["Title"];
            newNews.Text = form["Text"];
            newNews.Image = form["Imagem"];

            newsModel.Create(newNews);
            ViewBag.News = newsModel.ReadAll();

            return LocalRedirect("~/News/Listar");
        }
    }
}