using senai.inlock.webApi.Domains;

namespace senai.inlock.webApi.Interfaces
{
    public interface IEstudioRepository
    {
        /// <summary>
        /// Cadastrar um estudio (objeto)
        /// </summary>
        /// <param name="novoEstudio">objeto do estudio com os dados</param>
        void Cadastrar(EstudioDomain novoEstudio);

        /// <summary>
        /// Deletar um estudio (int id)
        /// </summary>
        /// <param name="id">id do objeto a ser deletado</param>
        void Deletar(int id);

        /// <summary>
        /// Lista e exibe todos os estudios existentes
        /// </summary>
        /// <returns>lista de estudios</returns>
        List<EstudioDomain> ListarTodos();
    }
}
