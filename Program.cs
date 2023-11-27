
using Microsoft.AspNetCore.Http.Json;
var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<JsonOptions>(options=>options.SerializerOptions.PropertyNamingPolicy=null);
builder.Services.AddCors();
var app = builder.Build();
app.UseCors(policy=>policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
app.MapGet("/", () => "Hello World!");
app.MapGet("/calificaciones",CalificacionesRequestHandlers.MostrarCalificaciones);
app.MapGet("/calificaciones/{numControl:long}",CalificacionesRequestHandlers.MostrarCalificacionesAlumno);
app.MapPost("/operaciones",OperacionesRequestHandlers.Calcular);
app.MapGet("/control-escolar/alumnos",AlumnosRequestHandlers.ListarAlumnos);

app.MapPost("/aceptar-nuevo-registro", RegistrarRequestHandler.GenerarUsuario);

app.MapPost("/ingresar",RegistrarRequestHandler.IniciarSesion);

app.MapPost("/aceptar-enviar-contraseña",RegistrarRequestHandler.Recuperar);

app.MapPost("/categorias/crear",CategoriasRequestHandler.Crear);

app.MapGet("/categorias/lista",CategoriasRequestHandler.Listar);

app.MapGet("/lenguaje/{idCategoria}",LenguajeRequestHandler.ListarRegistros);
app.MapPost("/lenguaje",LenguajeRequestHandler.CrearRegistro);
app.MapDelete("/lenguaje/{id}",LenguajeRequestHandler.Eliminar);
app.MapGet("/lenguaje/buscar",LenguajeRequestHandler.Buscar);


app.Run();
