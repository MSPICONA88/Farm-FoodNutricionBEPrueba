using Frontend.Models;
using Frontend.Resultados.Usuarios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Frontend.Controllers;

[ApiController]

public class AlimentoController : ControllerBase
{
    private readonly FarmFoodNutricionContext _context;

    public AlimentoController(FarmFoodNutricionContext context)
    {
        _context=context;
    }

    [HttpGet]
    [Route("api/alimento/traerTodos")]
    
    public async Task<ActionResult<ResultadoListAlimentos>> GetAlimentos()
    
    {
        try
        {
            var result= new ResultadoListAlimentos();
            var alimentos=  await _context.Alimentos.ToListAsync();
            if(alimentos!=null){
                foreach (var ali in alimentos){
                    var resultAux = new ResultadoListAlimentosItem
                    {
                        NombreAlimento = ali.NombreAlimento
                        
                    };
                    result.listaAlimentos.Add(resultAux);
                    result.StatusCode= "200";
                }
                return Ok(result);
            }

            else
            {
                return Ok(result);
            }
        }

        catch(Exception e)
        {
            return BadRequest("Error al obtener los alimentos");
        }

        
        

    
    }
}