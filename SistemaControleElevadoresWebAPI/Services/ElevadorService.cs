using Newtonsoft.Json;
using SistemaControleElevadores.Entities;
using SistemaControleElevadores.Interfaces;

namespace SistemaControleElevadores.Services
{
  internal class ElevadorService : IElevadorService
  {
    private List<DadosElevador> _dadosElevadores;

    public ElevadorService(List<DadosElevador> dadosElevadores)
    {
      _dadosElevadores = dadosElevadores;
    }

    public List<int> andarMenosUtilizado()
    {
      var andares = _dadosElevadores.GroupBy(d => d.Andar)
                                   .OrderBy(g => g.Count())
                                   .Select(g => g.Key)
                                   .ToList();

      int menorUso = _dadosElevadores.GroupBy(d => d.Andar).Min(g => g.Count());

      return andares.Where(a => _dadosElevadores.Count(d => d.Andar == a) == menorUso).ToList();
    }

    public List<char> elevadorMaisFrequentado()
    {
      var elevadores = _dadosElevadores.GroupBy(d => d.Elevador)
                                      .OrderByDescending(g => g.Count())
                                      .Select(g => g.Key)
                                      .ToList();

      int maiorUso = _dadosElevadores.GroupBy(d => d.Elevador).Max(g => g.Count());

      return elevadores.Where(e => _dadosElevadores.Count(d => d.Elevador == e) == maiorUso).ToList();
    }

    public List<char> periodoMaiorFluxoElevadorMaisFrequentado()
    {
      var elevadoresMaisFrequentados = elevadorMaisFrequentado();

      return elevadoresMaisFrequentados.SelectMany(e => _dadosElevadores.Where(d => d.Elevador == e)
                                      .GroupBy(d => d.Turno)
                                      .OrderByDescending(g => g.Count())
                                      .Select(g => g.Key)
                                      .Take(1)).ToList();
    }

    public List<char> elevadorMenosFrequentado()
    {
      var elevadores = _dadosElevadores.GroupBy(d => d.Elevador)
                                      .OrderBy(g => g.Count())
                                      .Select(g => g.Key)
                                      .ToList();

      int menorUso = _dadosElevadores.GroupBy(d => d.Elevador).Min(g => g.Count());

      return elevadores.Where(e => _dadosElevadores.Count(d => d.Elevador == e) == menorUso).ToList();
    }

    public List<char> periodoMenorFluxoElevadorMenosFrequentado()
    {
      var elevadoresMenosFrequentados = elevadorMenosFrequentado();

      return elevadoresMenosFrequentados.SelectMany(e => _dadosElevadores.Where(d => d.Elevador == e)
                                        .GroupBy(d => d.Turno)
                                        .OrderBy(g => g.Count())
                                        .Select(g => g.Key)
                                        .Take(1)).ToList();
    }

    public List<char> periodoMaiorUtilizacaoConjuntoElevadores()
    {
      return _dadosElevadores.GroupBy(d => d.Turno)
                            .OrderByDescending(g => g.Count())
                            .Select(g => g.Key)
                            .ToList();
    }

    public float percentualDeUsoElevadorA()
    {
      return CalcularPercentualUso('A');
    }

    public float percentualDeUsoElevadorB()
    {
      return CalcularPercentualUso('B');
    }

    public float percentualDeUsoElevadorC()
    {
      return CalcularPercentualUso('C');
    }

    public float percentualDeUsoElevadorD()
    {
      return CalcularPercentualUso('D');
    }

    public float percentualDeUsoElevadorE()
    {
      return CalcularPercentualUso('E');
    }

    private float CalcularPercentualUso(char elevador)
    {
      int totalUso = _dadosElevadores.Count;
      int usoElevador = _dadosElevadores.Count(d => d.Elevador == elevador);
      return (float)Math.Round((double)usoElevador / totalUso * 100, 2);
    }
  }
}
