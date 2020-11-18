
namespace BLL
{
    public class Cliente
    {
        public DML.Cliente Consultar(int id)
        {
            DAL.Cliente dalCliente = new DAL.Cliente();
            return dalCliente.Consultar(id);
        }

        public int Salvar(DML.Cliente cliente)
        {
            DAL.Cliente dalCliente = new DAL.Cliente();
            return dalCliente.Salvar(cliente);
        }

        public int Atualizar(DML.Cliente cliente)
        {
            DAL.Cliente dalCliente = new DAL.Cliente();
            return dalCliente.Atualizzar(cliente);
        }

        public int Excluir(int id)
        {
            DAL.Cliente dalCliente = new DAL.Cliente();
            return dalCliente.Excluir(id);
        }
    }
}
