using System;
using System.IO;
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
            
            //Uploada Inicio
            //Verifica se o usuario anexou um arquivo
            if( form.Files.Count > 0 )
            {
                //Se sim
                //Armazenamos o arquivo na variave file
                var file    = form.Files[0];
                var folder  = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Teams");

                //Verificamos se a pasta existe
                if (!Directory.Exists(folder))
                {
                    //Caso não exista ela será criada
                    Directory.CreateDirectory(folder);
                }

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", folder, file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {   
                    //Salamos o arquivo no caminho especificado
                    file.CopyTo(stream);
                }

                newTeam.Image = file.FileName;
            }
            else
            {
                newTeam.Image = "padrao.png";
            }
            //Upload Termino
            
            //Chamamos o método
            // Create para salvar a
            // newTeam no CSV
            teamModel.Create(newTeam);
            ViewBag.Teams = teamModel.ReadAll();
            return LocalRedirect("~/Team/Listar");
        }
    }
}