using System.Net.Mime;
using Frontend.Comandos.Usuarios;
using Frontend.Models;
using Frontend.Resultados;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Frontend.Controllers;

[ApiController]

public class UsuarioController : ControllerBase
{
    private readonly FarmFoodNutricionContext _context;

    public UsuarioController(FarmFoodNutricionContext context)
    {
        _context=context;
    }

    [HttpPost]
    [Route("api/usuario/login")]
    
    public async Task<ActionResult<ResultadoLogin>> Login([FromBody] ComandoLogin comando)
    {
        try
        {
            var result= new ResultadoLogin();
            var usuario= await _context.Usuarios.Include(u => u.IdRolNavigation).Where(
                c=>c.Usuario1.Equals(comando.Usuario)&& 
                c.Password.Equals(comando.Password)).FirstOrDefaultAsync();
            if(usuario!=null){
                result.NombreUsuario= usuario.Usuario1;
                result.Rol= usuario.IdRolNavigation.NombreRol;
                result.StatusCode="200";
                return Ok(result);
            }
            else{
                result.SetError("Usuario no encontrado");
                result.StatusCode="500";
                return Ok(result);
            }
        }
        catch (Exception e)
        {
            return BadRequest("Error al obtener el usuario");
            
        }
    }

  
}

        




