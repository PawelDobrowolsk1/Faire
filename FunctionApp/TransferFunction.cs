using System;
using AutoMapper;
using FunctionApp.Models.BaselinkerModels;
using FunctionApp.Models.FaireModels;
using FunctionApp.Services;
using FunctionApp.Transfers;
using Google.Protobuf.WellKnownTypes;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;

namespace FunctionApp
{
    public class TransferFunction
    {
        private readonly ILogger _logger;

        ITransfer faireToBaselinkerTransfer = new FaireToBaselinkerTransfer(new FaireService(), new BaselinkerService());

        public TransferFunction(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<TransferFunction>();
        }

        [Function("TransferFunction")]
        public void Run([TimerTrigger("0 */10 * * * *")] MyInfo myTimer)
        {
            _logger.LogInformation($"Faire to Baselinker transfer executed at: {DateTime.Now}");

            faireToBaselinkerTransfer.Transfer();

        }
    }

    public class MyInfo
    {
        public MyScheduleStatus ScheduleStatus { get; set; }

        public bool IsPastDue { get; set; }
    }

    public class MyScheduleStatus
    {
        public DateTime Last { get; set; }

        public DateTime Next { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}
