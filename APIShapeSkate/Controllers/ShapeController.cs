using APIShapeSkate.Data;
using APIShapeSkate.Data.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
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
        public IActionResult AdicionaFilme([FromBody] CreateShapeDto shapedto)
        {
            Shape shape = new Shape
            {
                Madeira = shapedto.Madeira,
                Tamanho = shapedto.Tamanho,
                Valor = shapedto.Valor
            };
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
                ReadShapeDto shapeDto = new ReadShapeDto
                {
                    Id = shape.Id,
                    Madeira = shape.Madeira,
                    Tamanho = shape.Tamanho,
                    Valor = shape.Valor,
                    HoraDaConsulta = DateTime.Now
                };
                return Ok(shape);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaShape(int id, [FromBody] UpdateShapeDto shapeDto)
        {
            Shape shape = _context.Shapes.FirstOrDefault(shape => shape.Id == id);
            if(shape == null)
            {
                return NotFound();
            }
            shape.Madeira = shapeDto.Madeira;
            shape.Tamanho = shapeDto.Tamanho;
            shape.Valor = shapeDto.Valor;
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
    

