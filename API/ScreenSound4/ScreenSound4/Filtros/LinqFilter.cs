using ScreenSound4.Modelos;
    
namespace ScreenSound4.Filtros
{
    internal class LinqFilter
    {
        public static void FiltrarTodosOsGenerosMusicais(List<Musica> musicas)
        {
            var todosOsGenerosMusicais = musicas
                .Select(generos => generos.Genero)
                .Distinct().ToList();
            foreach (var genero in todosOsGenerosMusicais)
            {
                Console.WriteLine($"--{genero}");
            }
        }
        public static void FiltrarArtistasPorGeneroMusical(List<Musica> musicas, string genero)
        {
            var artistasPorGeneroMusical = musicas
                .Where(musica => musica.Genero!.Contains(genero))
                .Select(musica => musica.Artista)
                .Distinct().ToList();
            Console.WriteLine($"Exibindo os artistas por gênero musical >>> {genero}");
            foreach(var artista in artistasPorGeneroMusical)
            {
                Console.WriteLine($"- {artista}");
            }
        }
        public static void FiltrarMusicasDeUmArtista(List<Musica> musicas, string nomeDoArtista)
        {
            var musicasDoArtista = musicas
                .Where(musica => musica.Artista!.Equals(nomeDoArtista))
                .OrderBy(musicas => musicas.Nome)
                .ToList();
            Console.WriteLine(nomeDoArtista);
            foreach(var musica in musicasDoArtista)
            {
                Console.WriteLine($"- {musica.Nome}");
            }
        }
        public static void FiltrarMusicasPorAno(List<Musica> musicas, int ano)
        {
            var musicaPorAno = musicas
                .Where(musica => musica.Ano!.Equals(ano))
                .ToList();
            Console.WriteLine($"Musicas do ano {ano}");
            foreach (var musica in musicaPorAno)
            {
                Console.WriteLine($"- {musica.Nome}");
            }
        }

        public static void FiltrarMusicaPorTonalidade(List<Musica> musicas, int tonalidade)
        {
            var musicaPorTonalidade = musicas
                .Where(musica => musica.Key!.Equals(tonalidade))
                .ToList();
            Console.WriteLine($"Músicas de tonalidade '{musicaPorTonalidade[0].Tonalidade}'");
            foreach (var musica in musicaPorTonalidade)
            {
                Console.WriteLine($"- {musica.Nome}");
            }
        }
    }
}
