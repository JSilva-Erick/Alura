namespace ScreenSound.BD
{
    public class DAL<T> where T : class
    {
        public readonly ScreenSoundContext contexto;

        public DAL(ScreenSoundContext contexto)
        {
            this.contexto = contexto;
        }

        public IEnumerable<T> Listar()
        {
            return contexto.Set<T>().ToList();
        }
        public void Adicionar(T objeto)
        {
            contexto.Set<T>().Add(objeto);
            contexto.SaveChanges();
        }
        public void Deletar(T objeto)
        {
            contexto.Set<T>().Remove(objeto);
            contexto.SaveChanges();
        }
        public void Atualizar(T objeto)
        {
            contexto.Set<T>().Update(objeto);
            contexto.SaveChanges();
        }
        public T? RecuperarPor(Func<T, bool> condicao)
        {
            return contexto.Set<T>().FirstOrDefault(condicao);
        }
        public IEnumerable<T> ListarPor(Func<T, bool> condicao)
        {
            return contexto.Set<T>().Where(condicao);
        }
    }
}
