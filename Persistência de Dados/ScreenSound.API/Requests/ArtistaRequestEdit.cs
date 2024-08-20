namespace ScreenSound.API.Requests
{
    public record ArtistaRequestEdit(int Id, string Nome, string Bio, string FotoDoPerfil) : ArtistaRequest(Nome, Bio);

}
