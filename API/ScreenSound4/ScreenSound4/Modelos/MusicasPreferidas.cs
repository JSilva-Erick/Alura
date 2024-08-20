using System.Collections.Concurrent;
using System.Text.Json;

namespace ScreenSound4.Modelos;

internal class MusicasPreferidas
{
    public string? Nome { get; set; }
    public List<Musica> listaDeMusicasFavoritas { get; }

    public MusicasPreferidas(string nome)
    {
        Nome = nome;
        listaDeMusicasFavoritas = new List<Musica>();
    }

    public void AdicionarMusicasFavoritas(Musica musica)
    {
        listaDeMusicasFavoritas.Add(musica);
    }

    public void ExibirMusicasFavoritas()
    {
        Console.WriteLine($"Essas são as músicas favoritas do -> {Nome}");
        foreach(var musica in listaDeMusicasFavoritas)
        {
            Console.WriteLine($"- {musica.Nome} de {musica.Artista}");
        }
    }

    public void GerarArquivoJson()
    {
        string json = JsonSerializer.Serialize(new
        {
            nome = Nome,
            musicas = listaDeMusicasFavoritas
        });

        string nomeDoArquivo = $"musicas-preferidas-{Nome}.json";

        File.WriteAllText(nomeDoArquivo, json);

        Console.WriteLine($"\n O arquivo Json foi gerado no diretório {Path.GetFullPath(nomeDoArquivo)}");
    }

    public void GerarArquivoTXT()
    {
        string nomeDoTXT = $"musicas-preferidas-{Nome}.txt";

        using (StreamWriter arquivo = new StreamWriter(nomeDoTXT))
        {
            arquivo.WriteLine($"Musicas preferidas do {Nome} \n");
            foreach( var musica in listaDeMusicasFavoritas)
            {
                arquivo.WriteLine($"- {musica.Nome}");
            }
            Console.WriteLine($"TXT gerado com sucesso no diretório {Path.GetFullPath(nomeDoTXT)}");
        }
    }
}

