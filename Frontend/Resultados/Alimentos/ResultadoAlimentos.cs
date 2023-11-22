using System.Collections.Generic;
namespace Frontend.Resultados.Usuarios;

public class ResultadoListAlimentos: ResultadoBase
{
    public List<ResultadoListAlimentosItem> listaAlimentos {get; set;} = new List<ResultadoListAlimentosItem>();
}

public class ResultadoListAlimentosItem{ 
    public string NombreAlimento {get; set;}= null!;

}