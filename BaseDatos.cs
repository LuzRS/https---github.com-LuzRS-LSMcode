using MongoDB.Driver;
public class BaseDatos{
    private string conexion="mongodb+srv://Rosy:cbtis105@cluster0.lwigszz.mongodb.net/";
    private string baseDatos="Proyecto";
    public IMongoCollection<T>? ObtenerColeccion<T>(string coleccion){
        MongoClient client= new MongoClient(this.conexion);
        IMongoCollection<T>? collection= client.GetDatabase(this.baseDatos).GetCollection<T>(coleccion);
        return collection;
    }
}