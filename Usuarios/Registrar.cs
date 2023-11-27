using MongoDB.Bson;
public class Registrar{
    public ObjectId Id {get;set;} 
    public string Nombre { get; set; }=string.Empty;
    public string Correo { get; set; }=string.Empty;
    public string Contraseña { get; set; }=string.Empty;
}
public class Sesion{
    public string Correo { get; set; }=string.Empty;
    public string Contraseña { get; set; }=string.Empty;
    
}
public class Recuperar{
    public string Correo { get; set; }=string.Empty;

    public string Contraseña { get; set; }=string.Empty;
    
}
