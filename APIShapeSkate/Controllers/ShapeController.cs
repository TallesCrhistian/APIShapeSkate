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
        private static List<Shape> shapes = new List<Shape>();
        private static int id = 1;

        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] Shape shape)
        {
            shape.Id = id++;
            shapes.Add(shape);
            return CreatedAtAction(nameof(RecuperaFilmesPorId), new { Id = shape.Id }, shape);
        }

        [HttpGet]
        public IActionResult RecuperaFilmes()
        {
            return Ok(shapes);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaFilmesPorId(int id)
        {
            Shape shape = shapes.FirstOrDefault(shape => shape.Id == id);
            if (shape != null)
            {
                return Ok(shape);
            }
            return NotFound();
        }
    }




}
    

