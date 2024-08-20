using Microsoft.AspNetCore.Mvc;
using ScreenSound.API.Requests;
using ScreenSound.API.Response;
using ScreenSound.BD;
using ScreenSound.Modelos;

namespace ScreenSound.API.Endpoints
{
    public static class ArtistasExtensions
    {
        public static void AddEndPointsArtistas(this WebApplication app)
        {

            #region Artistas
            app.MapGet("/Artistas", ([FromServices] DAL<Artista> DAL) =>
            {
                return DAL.Listar();
            });

            app.MapGet("/Artistas/{nome}", ([FromServices] DAL<Artista> DAL, string nome) =>
            {
                var artista = DAL.RecuperarPor(a => a.Nome.ToUpper().Equals(nome.ToUpper()));
                if (artista == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(artista);
            });

            app.MapPost("/Artistas", ([FromServices] DAL<Artista> DAL, [FromBody] ArtistaRequest artistaRequest) =>
            {
                var artista = new Artista(artistaRequest.Nome, artistaRequest.Bio);
                DAL.Adicionar(artista);
                return Results.Ok();
            });

            app.MapDelete("/Artistas/{id}", ([FromServices] DAL<Artista> DAL, int id) =>
            {
                var artista = DAL.RecuperarPor(a => a.Id == id);
                if (artista == null)
                {
                    return Results.NotFound();
                }
                DAL.Deletar(artista);
                return Results.NoContent();
            });

            app.MapPut("/Artistas", ([FromServices] DAL<Artista> DAL, [FromBody] ArtistaRequestEdit artista) =>
            {
                var ArtistaAAlterar = DAL.RecuperarPor(a => a.Id == artista.Id);
                if (ArtistaAAlterar == null)
                {
                    return Results.NotFound();
                }
                ArtistaAAlterar.Nome = artista.Nome;
                ArtistaAAlterar.Bio = artista.Bio;
                ArtistaAAlterar.FotoPerfil = artista.FotoDoPerfil;

                DAL.Atualizar(ArtistaAAlterar);
                return Results.Ok();
            });
            #endregion
        }
        private static ICollection<ArtistaResponse> EntityListToResponseList(IEnumerable<Artista> listaDeArtistas)
        {
            return listaDeArtistas.Select(a => EntityToResponse(a)).ToList();
        }

        private static ArtistaResponse EntityToResponse(Artista artista)
        {
            return new ArtistaResponse(artista.Id, artista.Nome, artista.Bio, artista.FotoPerfil);
        }
    }

}

