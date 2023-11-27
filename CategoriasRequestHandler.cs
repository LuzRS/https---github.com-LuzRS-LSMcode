using MongoDB.Driver;

public static class CategoriasRequestHandler{
    public static IResult Crear (CategoriaDTO dto){

        var filterBuilder=new FilterDefinitionBuilder<CategoriaDbMap>();
        var filter=filterBuilder.Eq(x => x.Nombre, dto.Nombre);

        BaseDatos bd= new BaseDatos();
        var coleccion= bd.ObtenerColeccion<CategoriaDbMap>("Categorias");
        CategoriaDbMap? registro= coleccion.Find(filter).FirstOrDefault();

        if (registro != null){
            return Results.BadRequest($"La categoría'{dto.Nombre}' ya existe en la base de datos");
        }else if(string.IsNullOrWhiteSpace(dto.Nombre)){
            return Results.BadRequest("El nombre de la categoria es necesario");
        }else if(string.IsNullOrWhiteSpace(dto.UrlIcono)){
            return Results.BadRequest("El Url  es necesario");

        }
        registro=new CategoriaDbMap();
        registro.Nombre=dto.Nombre;
        registro.UrlIcono=dto.UrlIcono;
        coleccion!.InsertOne(registro);
        string nuevoId= registro.Id.ToString();

        return Results.Ok(nuevoId);
    }
public static IResult Listar(){
        var filterBuilder=new FilterDefinitionBuilder<CategoriaDbMap>();
        var filter=filterBuilder.Empty;
        BaseDatos bd= new BaseDatos();
        var coleccion= bd.ObtenerColeccion<CategoriaDbMap>("Categorias");
        List<CategoriaDbMap>mongoDbList=coleccion.Find(filter).ToList();

        var lista=mongoDbList.Select(x => new{
            Id=x.Id.ToString(),
            Nombre=x.Nombre,
            UrlIcono=x.UrlIcono
        }).ToList();

        return Results.Ok(lista);
}
}