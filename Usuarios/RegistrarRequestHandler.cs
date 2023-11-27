using MongoDB.Driver;
public static class RegistrarRequestHandler{
    public static IResult GenerarUsuario(Registrar datos){
        if(string.IsNullOrWhiteSpace(datos.Nombre)){
            return Results.BadRequest("El nombre es requerido");
         }else{
            if(string.IsNullOrWhiteSpace(datos.Correo)){
            return Results.BadRequest("El correo es requerido");
         }else{
            if(string.IsNullOrWhiteSpace(datos.Contraseña)){
            return Results.BadRequest("La contraseña es requerida");
         }
         }
         }

         //separador separandoo :D;
        BaseDatos bd=new BaseDatos();
        var coleccion=bd.ObtenerColeccion<Registrar>("Usuarios");
        if(coleccion==null){
            throw new Exception("No existe la coleccion de usuarios");
         }
        FilterDefinitionBuilder<Registrar> filterBuilder=new FilterDefinitionBuilder<Registrar>();
        var filter=filterBuilder.Eq(x => x.Correo,datos.Correo);

        Registrar? usuarioExistente=coleccion.Find(filter).FirstOrDefault();
        if(usuarioExistente != null){
            return Results.BadRequest($"Ya existe un usuario con el correo{datos.Correo}");
        }
        coleccion.InsertOne(datos);
        return Results.Ok();
    }
    //Separarcion Inicio de sesion;
     public static IResult IniciarSesion(Sesion datos){
        if(string.IsNullOrWhiteSpace(datos.Correo)){
            return Results.BadRequest("El correo es requerido");
         }else{
            if(string.IsNullOrWhiteSpace(datos.Contraseña)){
            return Results.BadRequest("La contraseña es requerida");
         }
         

         //separador separandoo :D;
        BaseDatos bd=new BaseDatos();
        var coleccion=bd.ObtenerColeccion<Registrar>("Usuarios");
        if(coleccion==null){
            throw new Exception("No existe la coleccion de usuarios");
         }
        FilterDefinitionBuilder<Registrar> filterBuilder=new FilterDefinitionBuilder<Registrar>();
        var filtro=filterBuilder.Eq(x => x.Contraseña,datos.Contraseña);
        var filter=filterBuilder.Eq(x=>x.Correo,datos.Correo);

        Registrar? usuarioExistente=coleccion.Find(filter).FirstOrDefault();
        if(usuarioExistente != null){
             if (usuarioExistente.Contraseña == datos.Contraseña) {
                return Results.Ok("Se inicio sesion  correctamente");
             }else{
            return Results.BadRequest("Cuenta correcta y contraseña incorrecta");
        }
        }else{
            return Results.NotFound("No existe correo");
        }
    }
         }
//Separacion Recuperar Contraseña;
public static IResult Recuperar(Recuperar datos) {
      if (string.IsNullOrWhiteSpace(datos.Correo)){
            return Results.BadRequest("El Correo es requerido");
        }
        BaseDatos bd = new BaseDatos();
        var coleccion = bd.ObtenerColeccion<Registrar>("Usuarios");
        if(coleccion == null){
            throw new Exception("No existe la coleccion Usuarios");
        }
        FilterDefinitionBuilder<Registrar> filterBuilder = new FilterDefinitionBuilder<Registrar>();
        var filter = filterBuilder.Eq(x =>x.Correo, datos.Correo);
         
        Registrar? usuarioExistente = coleccion.Find(filter).FirstOrDefault();
         if(usuarioExistente == null){
            return Results.BadRequest($"El correo es incorrecto {datos.Correo}");
         } else if(usuarioExistente.Correo==datos.Correo){
            Correo c = new Correo();
            c.Destinatario = usuarioExistente.Correo;
            c.Asunto = "Recuperar contraseña";
            c.Mensaje = "Contraseña: "+usuarioExistente.Contraseña;
            c.Enviar();
         }

         return Results.Ok();
    }
}
    