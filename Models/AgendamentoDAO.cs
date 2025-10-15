using SistemaBelezaCrystal.Config;
using SistemaBelezaCrystal.Models;

namespace AppExemplo.Models
{
    public class AgendamentoDAO
    {

    private readonly Conexao _conexao;

    public AgendamentoDAO(Conexao conexao)
    {
        _conexao = conexao;
    }
    }
}