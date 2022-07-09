using APIShapeSkate.Data;
using APIShapeSkate.Data.Dtos;
using AutoMapper;
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
        private IMapper _mapper;

        public ShapeController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] CreateShapeDto shapeDto)
        {
            Shape shape = _mapper.Map<Shape>(shapeDto);
           
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
                ReadShapeDto shapeDto = _mapper.Map<ReadShapeDto>(shape);
             
                return Ok(shapeDto);
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
            _mapper.Map(shapeDto, shape);
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
    

