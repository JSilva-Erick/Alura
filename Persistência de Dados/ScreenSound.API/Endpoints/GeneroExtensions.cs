using Microsoft.AspNetCore.Mvc;
using ScreenSound.API.Requests;
using ScreenSound.BD;
using ScreenSound.Modelos;

namespace ScreenSound.API.Endpoints
{
    public static class GeneroExtensions
    {
        public static void AddEndPointsGenero(this WebApplication app)
        {
            app.MapGet("/Generos", ([FromServices] DAL<Genero> DAL) =>
            {
                return DAL.Listar();
            });

            app.MapGet("/Generos/{id}", ([FromServices] DAL<Genero> dal, int id) =>
            {
                var genero = dal.RecuperarPor(a => a.Id.Equals(id));
                if (genero == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(genero);

            });
            app.MapPost("/Generos", ([FromServices] DAL<Genero> DAL, [FromBody] GeneroRequest generoRequest) =>
            {
                var genero = new Genero(generoRequest.Nome, generoRequest.Descricao);
                DAL.Adicionar(genero);
                return Results.Ok();
            });

            app.MapDelete("/Generos/{id}", ([FromServices] DAL<Genero> DAL, int id) =>
            {
                var genero = DAL.RecuperarPor(a => a.Id == id);
                if (genero == null)
                {
                    return Results.NotFound();
                }
                DAL.Deletar(genero);
                return Results.NoContent();
            });

            app.MapPut("/Generos", ([FromServices] DAL<Genero> DAL, [FromBody] GeneroRequestEdit genero) =>
            {
                var GeneroAAlterar = DAL.RecuperarPor(a => a.Id == genero.Id);
                if (GeneroAAlterar == null)
                {
                    return Results.NotFound();
                }
                GeneroAAlterar.Nome = genero.Nome;
                GeneroAAlterar.Descricao = genero.Descricao;

                DAL.Atualizar(GeneroAAlterar);
                return Results.Ok();
            });

        }
    }
}
