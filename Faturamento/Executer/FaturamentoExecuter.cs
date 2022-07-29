using Faturamento.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faturamento.Executer
{
    public static class FaturamentoExecuter
    {
        public static DiaFaturamento MenorFaturamento(this IEnumerable<DiaFaturamento> faturamento)
        {        
            var diasComFaturamento = ExcluirDiasInvalidos(faturamento);
            var menorExtrato = diasComFaturamento.MinBy(x => x.Valor);

            return menorExtrato!;
        }

        public static DiaFaturamento MaiorFaturamento(this IEnumerable<DiaFaturamento> faturamento)
        {         
            var diasComFaturamento = ExcluirDiasInvalidos(faturamento);
            var maiorExtrato = diasComFaturamento.MaxBy(x => x.Valor);

            return maiorExtrato!;
        }

        public static IEnumerable<DiaFaturamento> FaturamentoMaiorQueMedia(this IEnumerable<DiaFaturamento> faturamento)
        {
            var media = MediaFaturamento(faturamento);

            var diasMaioresQueMedia = faturamento.Where(x => x.Valor > media);

            return diasMaioresQueMedia;
        }

        private static double MediaFaturamento(IEnumerable<DiaFaturamento> faturamento)
        {

            if (faturamento == null)
                throw new ArgumentNullException(nameof(faturamento));

            var diasComFaturamento = ExcluirDiasInvalidos(faturamento);

            var valores = diasComFaturamento.Select(x => x.Valor);
            var result = valores.Sum() / valores.Count();

            return result!;
        }
        private static IEnumerable<DiaFaturamento> ExcluirDiasInvalidos(IEnumerable<DiaFaturamento> faturamento)
        {
            var diasComFaturamento = faturamento.Where(x => x.Valor > 0);
            return diasComFaturamento;
        }

    }
}
