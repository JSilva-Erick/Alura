﻿namespace ScreenSound.API.Requests
{
    public record MusicaRequestEdit(int Id, string Nome, int ArtistaID, int? AnoLancamento) : MusicaRequest(Nome, ArtistaID, AnoLancamento);

}
