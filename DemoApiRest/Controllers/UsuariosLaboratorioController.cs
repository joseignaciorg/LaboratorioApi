using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.DynamicData;
using System.Web.Http;
using System.Web.Http.Description;
using DemoApiRest.Models;

namespace DemoApiRest.Controllers
{
    public class UsuariosLaboratorioController : ApiController
    {
        private RedSocial13_dbEntities db =new RedSocial13_dbEntities(); //conexion a la base de datos

        public IHttpActionResult GetUsuario()
        {
            var data = db.Usuario.ToList();
            if (!data.Any())
                return NotFound();
            return Ok(data.ToList());

        }

        public IHttpActionResult GetUsuario(int id)
        {
            var data = db.Usuario.Find(id);
            if (data == null)
                return NotFound();

           return Ok(data);
        }

        public IHttpActionResult GetBuscarPorNombre(string nombre)
        {
            var data = db.Usuario.Where(user => user.nombre.Contains(nombre)).ToList();
            if (!data.Any())
                return NotFound();
            return Ok(data);
        }

        public IHttpActionResult PutUsuario(int id, Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            

        }

    }
}
