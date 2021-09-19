using ApiCatalogoDeJogos.ImputModel;
using ApiCatalogoDeJogos.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoDeJogos.Services
{
    public interface IJogoService : IDisposable
    {
        Task<List<JogoViewModel>> Obter(int pagina, int quantidade);
        Task<JogoViewModel> Obter(Guid id);
        Task<JogoViewModel> Inserir(JogoImputModel jogo);
        Task Atualizar(Guid id, JogoImputModel jogo);
        Task Atualizar(Guid id, Double jogo);
        Task Remover(Guid id);
    }
}
