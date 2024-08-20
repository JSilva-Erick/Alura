using ScreenSound4.Modelos;
using ScreenSound4.Filtros;
using System.Text.Json;
using (HttpClient client = new HttpClient())

{
    try
    {
        string resposta = await client.GetStringAsync("https://guilhermeonrails.github.io/api-csharp-songs/songs.json");
        var musicas = JsonSerializer.Deserialize<List<Musica>>(resposta)!;
        LinqFilter.FiltrarMusicaPorTonalidade(musicas, 6);
        //LinqFilter.FiltrarTodosOsGenerosMusicais(musicas);
        //LinqOrder.ExibirListaDeArtistasOrdenados(musicas);
        //LinqFilter.FiltrarArtistasPorGeneroMusical(musicas, "easy listening");
        //LinqFilter.FiltrarMusicasDeUmArtista(musicas, "U2");
        //LinqFilter.FiltrarMusicasPorAno(musicas, 2000);

        //var musicasPreferidasDoErick = new MusicasPreferidas("Erick");

        //musicasPreferidasDoErick.AdicionarMusicasFavoritas(musicas[500]);
        //musicasPreferidasDoErick.AdicionarMusicasFavoritas(musicas[637]);
        //musicasPreferidasDoErick.AdicionarMusicasFavoritas(musicas[428]);
        //musicasPreferidasDoErick.AdicionarMusicasFavoritas(musicas[13]);
        //musicasPreferidasDoErick.AdicionarMusicasFavoritas(musicas[71]);

        //musicasPreferidasDoErick.ExibirMusicasFavoritas();

        //musicasPreferidasDoErick.GerarArquivoTXT();
        //musicasPreferidasDoErick.GerarArquivoJson();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Temos um problema: {ex.Message}");
    }
}