using Faturamento.Executer;
using Faturamento.Models;
using Newtonsoft.Json;

//Colocar caminho do arquivo na máquina atual
var json = await File.ReadAllTextAsync(".\\dados.json");
var extratos = JsonConvert.DeserializeObject<List<DiaFaturamento>>(json);

var menorDia = extratos.MenorFaturamento();
var maiorDia = extratos.MaiorFaturamento();
var diasMaioresQueAMedia = extratos.FaturamentoMaiorQueMedia();

Console.WriteLine($"Dia com menor faturamento = Dia:{menorDia.Dia} Valor:{menorDia.Valor}");
Console.WriteLine($"Dia com maior faturamento = Dia:{maiorDia.Dia} Valor:{maiorDia.Valor}");

Console.WriteLine("Dias com faturamento maior que a média: ");
foreach (var dia in diasMaioresQueAMedia)
{
    Console.WriteLine($"Dia:{dia.Dia} Valor: {dia.Valor}");
}