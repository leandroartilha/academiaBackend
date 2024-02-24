using Application.Interfaces;
using AutoMapper;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class GraficoService : IGraficoService
    {
        private IPagamentoRepository _pagamentoRepository;
        public GraficoService(IPagamentoRepository pagamentoRepository)
        {
            _pagamentoRepository = pagamentoRepository;
        }
        public async Task<double> GetFaturamentoTotal()
        {
            double faturamento = 0;
            try
            {
                var pagamentos = await _pagamentoRepository.GetAllPagamentos();


                foreach (var item in pagamentos)
                {
                    faturamento += (double)item.Valor;
                }

                return faturamento;
            }
            catch(Exception ex)
            {
                return faturamento;
            }

        }
    }
}
