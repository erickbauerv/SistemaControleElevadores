using SistemaControleElevadores.Interfaces;
using SistemaControleElevadores.Services;

string opcaoMenu = "0";
string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\input.json");
IElevadorService elevadorService = new ElevadorService(Path.GetFullPath(filePath));

while (opcaoMenu != "7")
{
  Console.WriteLine("Selecione uma opção:\n" +
    "Digite 1 para listar o(s) andar(es) menos utilizados.\n" +
    "Digite 2 para listar o(s) elevador(es) mais frequentado(s) junto ao período com maior fluxo.\n" +
    "Digite 3 para listar o(s) elevador(es) menos frequentado(s) junto ao período com menor fluxo.\n" +
    "Digite 4 para listar o(s) período(s) de maior utilização do conjunto de elevadores.\n" +
    "Digite 5 para exibir o percentual de uso de cada elevador.");

  opcaoMenu = Console.ReadLine() ?? "0";

  switch (opcaoMenu)
  {
    case "1":
      Console.WriteLine("Andar(es) menos utilizado(s):");
      PrintList(elevadorService.andarMenosUtilizado());
      break;
    case "2":
      Console.WriteLine("Elevador(es) mais frequentado(s) junto ao período com maior fluxo:");
      var elevadoresMaisFrequentados = elevadorService.elevadorMaisFrequentado();
      var periodosMaiorFluxo = elevadorService.periodoMaiorFluxoElevadorMaisFrequentado();

      IList<string> elevadorPeriodoMaiorFluxo = new List<string>();
      for (int i = 0; i < elevadoresMaisFrequentados.Count(); i++)
      {
        elevadorPeriodoMaiorFluxo.Add($"Elevador: {elevadoresMaisFrequentados[i].ToString()} - Período: {periodosMaiorFluxo[i].ToString()}");
      }

      PrintList(elevadorPeriodoMaiorFluxo);
      break;
    case "3":
      Console.WriteLine("Elevador(es) menos frequentado(s) junto ao período com menor fluxo:");
      var elevadoresMenosFrequentados = elevadorService.elevadorMenosFrequentado();
      var periodosMenorluxo = elevadorService.periodoMenorFluxoElevadorMenosFrequentado();

      IList<string> elevadorPeriodoMenorFluxo = new List<string>();
      for (int i = 0; i < elevadoresMenosFrequentados.Count(); i++)
      {
        elevadorPeriodoMenorFluxo.Add($"Elevador: {elevadoresMenosFrequentados[i].ToString()} - Período: {periodosMenorluxo[i].ToString()}");
      }

      PrintList(elevadorPeriodoMenorFluxo);
      break;
    case "4":
      Console.WriteLine("Período(s) de maior utilização do conjunto de elevadores:");
      PrintList(elevadorService.periodoMaiorUtilizacaoConjuntoElevadores());
      break;
    case "5":
      Console.WriteLine("Percentual de uso de cada elevador:");
      Console.WriteLine($"Percentual de uso do elevador A: {elevadorService.percentualDeUsoElevadorA()}%");
      Console.WriteLine($"Percentual de uso do elevador B: {elevadorService.percentualDeUsoElevadorB()}%");
      Console.WriteLine($"Percentual de uso do elevador C: {elevadorService.percentualDeUsoElevadorC()}%");
      Console.WriteLine($"Percentual de uso do elevador D: {elevadorService.percentualDeUsoElevadorD()}%");
      Console.WriteLine($"Percentual de uso do elevador E: {elevadorService.percentualDeUsoElevadorE()}%");
      break;
    default:
      Console.WriteLine("Opção inválida");
      break;
  }

  Console.ReadLine();
  Console.Clear();
}

static void PrintList<T>(IList<T> list)
{
  foreach (var item in list)
  {
    Console.WriteLine(item);
  }
}