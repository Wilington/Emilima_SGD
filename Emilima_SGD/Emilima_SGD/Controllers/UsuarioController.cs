using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using Emilima_SGD.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Emilima_SGD.Controllers
{
    
    public class UsuarioController : Controller
    {
        UsuarioDataAccess objusuario = new UsuarioDataAccess();

        // GET: api/<controller>
        [HttpGet]
        [Route("api/Usuario/Index")]
        public IEnumerable<Usuario> Index()
        {
            return objusuario.GetAllUsuarios();
        }

        [HttpPost]
        [Route("api/Usuario/Nuevo")]
        public string Nuevo([FromBody] Usuario usuario)
        {
            return objusuario.NuevoUsuario(usuario);
        }
        //// GET api/<controller>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<controller>
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/<controller>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
