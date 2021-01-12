using System;
using E_Players_Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EPlayer_AspNetCore.Controllers
{   
    // https://localhost:5001/Team
    [Route("Team")]
    public class TeamController : Controller
    {
        Team teamModel = new Team();
        [Route("Listar")]
        public IActionResult Index()
        {
            ViewBag.Teams = teamModel.ReadAll();
            return View();
        }
        [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection form)
        {
            // Criamos uma nova instância de Team e
            // armazenamos os dados enviados pelo usuario através do formulario
            // e salvamos no objeto newTeam
            Team newTeam = new Team();
            newTeam.IdTeam = Int32.Parse(form["IdTeam"]);
            newTeam.Name = form["Name"];
            newTeam.Image = form["Image"];

            //Chamamos o método
            // Create para salvar a
            // newTeam no CSV
            teamModel.Create(newTeam);
            ViewBag.Teams = teamModel.ReadAll();
            return LocalRedirect("~/Team/Listar");
        }
    }
}