using bytebank_GeradorChavePix;

var chaves = GeradorPix.GetChavesPix(3);

foreach (var chave in chaves)
{
    Console.WriteLine(chave);
}