using Microsoft.AspNetCore.Mvc;
using ScreenSound.API.Requests;
using ScreenSound.API.Response;
using ScreenSound.BD;
using ScreenSound.Modelos;

namespace ScreenSound.API.Endpoints
{
    public static class MusicasExtensions
    {
        public static void AddEndPointsMusicas(this WebApplication app)
        {
            #region Musicas
            app.MapGet("/Musicas", ([FromServices] DAL<Musica> DAL) =>
            {
                return DAL.Listar();
            });

            app.MapGet("/Musicas/{nome}", ([FromServices] DAL<Musica> DAL, string nome) =>
            {
                var musica = DAL.RecuperarPor(a => a.Nome.ToUpper().Equals(nome.ToUpper()));
                if (musica == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(musica);
            });

            app.MapPost("/Musicas", ([FromServices] DAL<Musica> DAL, [FromServices] DAL<Artista> DALArtista, [FromServices] DAL<Genero> DALGenero, [FromBody] MusicaRequest musicaRequest) =>
            {
                var musica = new Musica(musicaRequest.Nome)
                {
                    Artista = DALArtista.RecuperarPor(a => a.Id.Equals(musicaRequest.ArtistaID)),
                    AnoLancamento = musicaRequest.AnoLancamento,
                    Generos = musicaRequest.Generos is not null ? GeneroRequestConverter(musicaRequest.Generos, DALGenero) : new List<Genero>()
                };
                DAL.Adicionar(musica);
                return Results.Ok();
            });

            app.MapDelete("/Musicas/{id}", ([FromServices] DAL<Musica> DAL, int id) =>
            {
                var musica = DAL.RecuperarPor(a => a.Id == id);
                if (musica == null)
                {
                    return Results.NotFound();
                }
                DAL.Deletar(musica);
                return Results.NoContent();
            });

            app.MapPut("/Musicas", ([FromServices] DAL<Musica> DAL, [FromBody] MusicaRequestEdit musica) =>
            {
                var MusicaAAlterar = DAL.RecuperarPor(a => a.Id == musica.Id);
                if (MusicaAAlterar == null)
                {
                    return Results.NotFound();
                }
                MusicaAAlterar.Nome = musica.Nome;
                MusicaAAlterar.AnoLancamento = musica.AnoLancamento;

                DAL.Atualizar(MusicaAAlterar);
                return Results.Ok();
            });
            #endregion
        }

        private static ICollection<Genero> GeneroRequestConverter(ICollection<GeneroRequest> generos, DAL<Genero> DALGenero)
        {
            var listaGeneros = new List<Genero>();
            foreach (var genero in generos)
            {
                var entity = RequestToEntity(genero);
                var verificaGenero = DALGenero.RecuperarPor(g => g.Nome.ToUpper().Equals(entity.Nome.ToUpper()));
                if (verificaGenero is not null)
                {
                    listaGeneros.Add(verificaGenero);
                }
                else listaGeneros.Add(entity); 
            }
            return listaGeneros;
        }

        private static Genero RequestToEntity(GeneroRequest genero)
        {
            return new Genero() { Nome = genero.Nome, Descricao = genero.Descricao };

        }

        private static ICollection<MusicaResponse> EntityListToResponseList(IEnumerable<Musica> listaDeMusicas)
        {
            return listaDeMusicas.Select(a => EntityToResponse(a)).ToList();
        }

        private static MusicaResponse EntityToResponse(Musica musica)
        {
            return new MusicaResponse(musica.Id, musica.Nome, musica.AnoLancamento, musica.Artista!.Id, musica.Artista!.Nome);
        }
    }
}
