using Newtonsoft.Json;
using System.Xml.Serialization;

namespace ExportarDados
{
    public static class ExportarDados<T> where T : class
    {
        public static void SalvarDados(string caminho, FormatoArquivos formato, List<T> lista)
        {
            if (string.IsNullOrEmpty(caminho)) { throw new Exception("Caminho não informado"); }
            if (formato != FormatoArquivos.Json)
            {
                if (formato != FormatoArquivos.Xml)
                {
                    throw new Exception("Formato de arquivo desejado não encontrado");
                }
            }
            if (lista == null) { throw new Exception("Não possui dados para exportar!..."); };
            ExportaDados(caminho, formato, lista);
        }

        private static void ExportaDados(string caminho, FormatoArquivos formato, List<T> lista)
        {
            if (formato == FormatoArquivos.Json)
            {
                try
                {
                    string json = JsonConvert.SerializeObject(lista, Formatting.Indented);
                    FileStream fs = new(caminho + "\\dados.json", FileMode.Create);
                    using (StreamWriter sw = new(fs))
                    {
                        sw.WriteLine(json);
                    }
                    Console.WriteLine($"Arquivo criado no diretório {caminho}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ocorrido {ex.Message}");
                }
            }

            if (formato == FormatoArquivos.Xml)
            {
                try
                {
                    var xml = new XmlSerializer(typeof(List<T>));
                    FileStream fs = new(caminho + "\\dados.xml", FileMode.Create);
                    using (StreamWriter writer = new(fs))
                    {
                        xml.Serialize(writer, lista);
                    }
                    Console.WriteLine($"Arquivo salvo em {caminho}");
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }

}

public enum FormatoArquivos
{
    Xml = 1,
    Json = 2
}