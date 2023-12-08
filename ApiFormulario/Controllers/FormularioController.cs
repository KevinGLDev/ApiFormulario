using ApiFormulario.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiFormulario.Controllers
{
    [Route("Formulario")]
    [ApiController]
    public class FormularioController : ControllerBase
    {
        [HttpGet]
        [Route("Lista")]
        public IEnumerable<Contact> Lista() {
        
        return new DataBaseWoodensonContext().Contacts.ToList();
        }
        [HttpPost]
        [Route("Crear")]
        public IActionResult FormularioPost([FromBody] Contact contact)
        {
          
            if (contact != null)
            {
                
                using (var db = new DataBaseWoodensonContext())
                {
                    db.Add(contact);
                    db.SaveChanges();
                    return Ok();
                }
            }
            
            return BadRequest();
        }
        [HttpPost]
        [Route("Delete/{id}")]
        public IActionResult DeleteContact(string id)
        {
            using (var db = new DataBaseWoodensonContext())
            {
                if (id == null || db.Contacts == null)
                {
                    return NotFound();
                }

                var contact = db.Contacts.FirstOrDefault(x => x.Id == Int32.Parse(id));
                
                if(contact == null)
                {
                    return NotFound(id);
                }
                db.Contacts.Remove(contact);
                db.SaveChanges();

                return Ok();

            }
        }
    }
}
