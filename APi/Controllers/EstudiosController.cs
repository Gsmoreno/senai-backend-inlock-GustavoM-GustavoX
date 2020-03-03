﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domains;
using Interfaces;
using Repositories;

namespace Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]

    [Authorize]
    public class EstudiosController : ControllerBase
    {
        private IEstudiosRepository _estudiosRepository { get; set; }

        public EstudiosController()
        {
            _estudiosRepository = new EstudiosRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_estudiosRepository.Listar());
        }

        [HttpPost]
        public IActionResult Post(EstudiosDomain novoEstudio)
        {
            if (novoEstudio.NomeEstudio == null)
            {
                return BadRequest("O nome do Estudio é obrigatório!");
            }
            
            _estudiosRepository.Cadastrar(novoEstudio);

           
            return Created("http://localhost:5000/api/Estudios", novoEstudio);
        }


    }
}