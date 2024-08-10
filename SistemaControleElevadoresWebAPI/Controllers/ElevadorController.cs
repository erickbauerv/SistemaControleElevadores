using Microsoft.AspNetCore.Mvc;
using SistemaControleElevadores.Entities;
using SistemaControleElevadores.Interfaces;
using SistemaControleElevadores.Services;

namespace SistemaControleElevadores.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class ElevadorController : ControllerBase
  {
    [HttpPost]
    [Route("AndarMenosUtilizado")]
    public IList<int> AndarMenosUtilizado([FromBody]List<DadosElevador> dadosElevadores)
    {
      IElevadorService elevadorService = new ElevadorService(dadosElevadores);
      return elevadorService.andarMenosUtilizado();
    }

    [HttpPost]
    [Route("ElevadorMaisFrequentadoPeriodoMaiorFluxo")]
    public IList<string> ElevadorMaisFrequentadoPeriodoMaiorFluxo([FromBody]List<DadosElevador> dadosElevadores)
    {
      IElevadorService elevadorService = new ElevadorService(dadosElevadores);

      var elevadoresMaisFrequentados = elevadorService.elevadorMaisFrequentado();
      var periodosMaiorFluxo = elevadorService.periodoMaiorFluxoElevadorMaisFrequentado();

      IList<string> elevadorPeriodoMaiorFluxo = new List<string>();
      for (int i = 0; i < elevadoresMaisFrequentados.Count(); i++)
      {
        elevadorPeriodoMaiorFluxo.Add($"Elevador: {elevadoresMaisFrequentados[i].ToString()} - Período: {periodosMaiorFluxo[i].ToString()}");
      }

      return elevadorPeriodoMaiorFluxo;
    }

    [HttpPost]
    [Route("ElevadorMenosFrequentadoPeriodoMenorFluxo")]
    public IList<string> ElevadorMenosFrequentadoPeriodoMenorFluxo([FromBody] List<DadosElevador> dadosElevadores)
    {
      IElevadorService elevadorService = new ElevadorService(dadosElevadores);

      var elevadoresMaisFrequentados = elevadorService.elevadorMenosFrequentado();
      var periodosMaiorFluxo = elevadorService.periodoMenorFluxoElevadorMenosFrequentado();

      IList<string> elevadorPeriodoMenorFluxo = new List<string>();
      for (int i = 0; i < elevadoresMaisFrequentados.Count(); i++)
      {
        elevadorPeriodoMenorFluxo.Add($"Elevador: {elevadoresMaisFrequentados[i].ToString()} - Período: {periodosMaiorFluxo[i].ToString()}");
      }

      return elevadorPeriodoMenorFluxo;
    }

    [HttpPost]
    [Route("PeriodoMaiorUtilizacaoConjuntoElevadores")]
    public IList<char> PeriodoMaiorUtilizacaoConjuntoElevadores([FromBody] List<DadosElevador> dadosElevadores)
    {
      IElevadorService elevadorService = new ElevadorService(dadosElevadores);
      return elevadorService.periodoMaiorUtilizacaoConjuntoElevadores();
    }

    [HttpPost]
    [Route("PercentualDeUsoElevadores")]
    public IList<string> PercentualDeUsoElevadores([FromBody] List<DadosElevador> dadosElevadores)
    {
      IElevadorService elevadorService = new ElevadorService(dadosElevadores);
      IList<string> listaPercentualDeUsoElevadores = new List<string>();

      listaPercentualDeUsoElevadores.Add($"Percentual de uso do elevador A: {elevadorService.percentualDeUsoElevadorA()}%");
      listaPercentualDeUsoElevadores.Add($"Percentual de uso do elevador B: {elevadorService.percentualDeUsoElevadorB()}%");
      listaPercentualDeUsoElevadores.Add($"Percentual de uso do elevador C: {elevadorService.percentualDeUsoElevadorC()}%");
      listaPercentualDeUsoElevadores.Add($"Percentual de uso do elevador D: {elevadorService.percentualDeUsoElevadorD()}%");
      listaPercentualDeUsoElevadores.Add($"Percentual de uso do elevador E: {elevadorService.percentualDeUsoElevadorE()}%");

      return listaPercentualDeUsoElevadores;
    }
  }
}
