using GlutenFreeApi.Context;
using GlutenFreeApi.Domains;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GlutenFreeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlacesController : ControllerBase
    {
        private readonly GlutenFreeApiContext? _context;
        public PlacesController(GlutenFreeApiContext context) 
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Place>>> GetPlaces()
        {
            try
            {
                var places = await _context.Places.ToListAsync();
                if (places == null)
                    return NotFound("Lugar não encontrado!");
                return Ok(places);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao processar sua solicitacão");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Place>> GetPlaceById(int id)
        {
            try
            {
                if(id<=0)
                    return BadRequest("Id inválido!");
                var place = await _context.Places.FindAsync(id);
                if (place == null)
                    return NotFound("");
                return Ok(place);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao processar sua solicitacão");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Place>> PostPlace(Place place)
        {
            try
            {
                if (place is null)
                    return BadRequest("Informe uma local correto!");
                _context.Places.Add(place);
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetPlaceById), new { id = place.Id }, place);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao processar sua solicitacão");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> PutPlace(int id, Place place)
        {
            try
            {
                if (id != place.Id)
                    return BadRequest("Id informado diferentre do id do local");
                var existingPlace = await _context.Places.FindAsync(id);
                if (existingPlace == null)
                    return NotFound("Local não encontrado");
                
                _context.Entry(existingPlace).CurrentValues.SetValues(place);
                _context.SaveChanges();

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao processar sua solicitacão");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeletePlace(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Informe um Id válido");

                var existingPlace = await _context.Places.FindAsync(id);
                if (existingPlace == null)
                    return NotFound("Local não encontrado!");

                _context.Places.Remove(existingPlace);
                _context.SaveChanges();

                return NoContent();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao processar sua solicitacão"); ;
            }
        }
    }
}
