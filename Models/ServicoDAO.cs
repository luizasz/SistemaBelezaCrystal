using SistemaBelezaCrystal.Config;
using SistemaBelezaCrystal.Models;

namespace AppExemplo.Models
{
    public class ServicoDAO
    {

    private readonly Conexao _conexao;

    public ServicoDAO(Conexao conexao)
    {
        _conexao = conexao;
    }
    }
}