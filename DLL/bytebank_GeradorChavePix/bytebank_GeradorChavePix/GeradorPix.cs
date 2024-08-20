namespace bytebank_GeradorChavePix
{
    /// <summary>
    /// Classe que gera chaves Pix usando o formato Guid. 
    /// </summary>
    public static class GeradorPix
    {
        /// <summary>
        /// Método que retorna uma chave Pix
        /// </summary>
        /// <returns>Retorna uma chave aleatória Pix no formato string</returns>
        public static string GetPix()
        {
            return Guid.NewGuid().ToString();
        }
        /// <summary>
        /// Método que retorna uma lista de chaves Pix
        /// </summary>
        /// <param name="numeroChaves">Quantidade de chaves a serem geradas</param>
        /// <returns>Uma lista de string de chaves Pix</returns>
        public static List<string> GetChavesPix(int numeroChaves)
        {
            if (numeroChaves <= 0)
            {
                return null;
            }
            else
            {
                var chaves = new List<string>();
                for (int i = 0; i < numeroChaves; i++)
                {
                    chaves.Add(Guid.NewGuid().ToString());
                }

                return chaves;
            }
        }
    }
}
