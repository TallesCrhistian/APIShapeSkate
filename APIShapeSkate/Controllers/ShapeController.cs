using APIShapeSkate.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;


namespace APIShapeSkate.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShapeController : ControllerBase
    {
       private DataContext _context;

        public ShapeController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] Shape shape)
        {
            _context.Shapes.Add(shape);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaFilmesPorId), new { Id = shape.Id }, shape);
        }

        [HttpGet]
        public IEnumerable<Shape> RecuperaFilmes()
        {
            return _context.Shapes;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaFilmesPorId(int id)
        {
            Shape shape = _context.Shapes.FirstOrDefault(shape => shape.Id == id);
            if (shape != null)
            {
                return Ok(shape);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaShape(int id, [FromBody] Shape shapeNovo)
        {
            Shape shape = _context.Shapes.FirstOrDefault(shape => shape.Id == id);
            if(shape == null)
            {
                return NotFound();
            }
            shape.Madeira = shapeNovo.Madeira;
            shape.Tamanho = shapeNovo.Tamanho;
            shape.Valor = shapeNovo.Valor;
            _context.SaveChanges();

            return NoContent();
        }
        [HttpDelete ("{id}")]
        public IActionResult DeletaShape(int id)
        {
            var shape = _context.Shapes.FirstOrDefault(shape => shape.Id == id);    
            if(shape == null)
            {
                return NotFound();
            }
            _context.Remove(shape);
            _context.SaveChanges();
            return NoContent();
        }
    }




}
    

