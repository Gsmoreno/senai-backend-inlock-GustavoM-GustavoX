﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domains;
using Interfaces;
using Microsoft.AspNetCore.Mvc;



namespace Senai.InLock.WebApi.Controllers
{
    public class JogosController : Controller
    {
        private IJogosRepository _jogosRepository { get; set; }

        public JogosController()
        {
            _jogosRepository = new JogosRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_jogosRepository.Listar());
        }

        [HttpPost]
        public IActionResult Post(JogosDomain novoJogo)
        {
            if (novoJogo.NomeJogo == null)
            {
                return BadRequest("O nome do Estudio é obrigatório!");
            }

            _jogosRepository.Cadastrar(novoJogo);


            return Created("http://localhost:5000/api/Jogos", novoJogo);
        }

    }
}