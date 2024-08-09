using SistemaControleElevadores.Interfaces;
using SistemaControleElevadores.Services;

string opcaoMenu = "0";
string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\input.json");
IElevadorService elevadorService = new ElevadorService(Path.GetFullPath(filePath));


while (opcaoMenu != "7")
{
  Console.WriteLine("Selecione uma opção:\n" +
    "Digite 1 para listar o(s) andar(es) menos utilizados.\n" +
    "Digite 2 para listar o(s) elevador(es) mais frequentados.\n" +
    "Digite 3 para listar o(s) períodos de maior fluxo do elevador mais frequentado.\n" +
    "Digite 4 para listar o(s) elevador(es) menos frequentados.\n" +
    "Digite 5 para listar o(s) período(s) de menor fluxo do elevador menos frequentado.\n" +
    "Digite 6 para listar o(s) período(s) de maior utilização do conjunto de elevadores.\n" +
    "Digite 7 para exibir o percentual de uso de cada elevador.");

  opcaoMenu = Console.ReadLine() ?? "0";

  switch (opcaoMenu)
  {
    case "1":
      Console.WriteLine("Andar(es) menos utilizado(s):");
      PrintList(elevadorService.andarMenosUtilizado());
      break;
    case "2":
      Console.WriteLine("Elevador(es) mais frequentado(s):");
      PrintList(elevadorService.elevadorMaisFrequentado());
      break;
    case "3":
      Console.WriteLine("Período(s) de maior fluxo do(s) elevador(es) mais frequentado(s):");
      var elevadoresMaisFrequentados = elevadorService.elevadorMaisFrequentado();
      var periodosMaiorFluxo = elevadorService.periodoMaiorFluxoElevadorMaisFrequentado();

      IList<string> andarPeriodosMaiorFluxo = new List<string>();
      for (int i = 0; i < elevadoresMaisFrequentados.Count(); i++)
      {
        andarPeriodosMaiorFluxo.Add($"Elevador: {elevadoresMaisFrequentados[i].ToString()} - Período: {periodosMaiorFluxo[i].ToString()}");
      }

      PrintList(andarPeriodosMaiorFluxo);
      break;
    case "4":
      Console.WriteLine("Elevador(es) menos frequentado(s):");
      PrintList(elevadorService.elevadorMenosFrequentado());
      break;
    case "5":
      Console.WriteLine("Período(s) de menor fluxo do(s) elevador(es) menos frequentado(s):");
      var elevadoresMenosFrequentados = elevadorService.elevadorMenosFrequentado();
      var periodosMenorluxo = elevadorService.periodoMenorFluxoElevadorMenosFrequentado();

      IList<string> andarPeriodosMenorFluxo = new List<string>();
      for (int i = 0; i < elevadoresMenosFrequentados.Count(); i++)
      {
        andarPeriodosMenorFluxo.Add($"Elevador: {elevadoresMenosFrequentados[i].ToString()} - Período: {periodosMenorluxo[i].ToString()}");
      }

      PrintList(andarPeriodosMenorFluxo);
      break;
    case "6":
      Console.WriteLine("Período(s) de maior utilização do conjunto de elevadores:");
      PrintList(elevadorService.periodoMaiorUtilizacaoConjuntoElevadores());
      break;
    case "7":
      Console.WriteLine("Percentual de uso do elevador A: " + elevadorService.percentualDeUsoElevadorA() + "%");
      Console.WriteLine("Percentual de uso do elevador B: " + elevadorService.percentualDeUsoElevadorB() + "%");
      Console.WriteLine("Percentual de uso do elevador C: " + elevadorService.percentualDeUsoElevadorC() + "%");
      Console.WriteLine("Percentual de uso do elevador D: " + elevadorService.percentualDeUsoElevadorD() + "%");
      Console.WriteLine("Percentual de uso do elevador E: " + elevadorService.percentualDeUsoElevadorE() + "%");
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