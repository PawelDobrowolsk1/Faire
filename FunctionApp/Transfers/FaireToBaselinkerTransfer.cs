using AutoMapper;
using FunctionApp.Models.BaselinkerModels;
using FunctionApp.Models.FaireModels;
using FunctionApp.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FunctionApp.Transfers
{
    public class FaireToBaselinkerTransfer : ITransfer
    {
        private static List<string> ordersId = new List<string>();
        private readonly IFaireService _faire;
        private readonly IBaselinkerService _baselinker;
        private IMapper _mapper;

        public FaireToBaselinkerTransfer(IFaireService faire, IBaselinkerService baselinker)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<FaireOrder, BaselinkerOrder>();
                cfg.CreateMap<FaireItem, BaselinkerItem>();
                cfg.CreateMap<FaireAddress, BaselinkerAddress>();
                cfg.CreateMap<FairePayoutCosts, BaselinkerPayoutCosts>();
            });

            _mapper = config.CreateMapper();
            _faire = faire;
            _baselinker = baselinker;
        }

        public void Transfer()
        {
            var tempOrders = new List<FaireOrder>();

            var FaireOrders = _faire.GetOrders();

            foreach (var order in FaireOrders)
            {
                if (!ordersId.Contains(order.id))
                {
                    ordersId.Add(order.id);
                    tempOrders.Add(order);
                }
            }

            var OrdersForBaselinker = _mapper.Map<List<BaselinkerOrder>>(tempOrders);

            _baselinker.AddOrders(OrdersForBaselinker);
        }
    }
}
