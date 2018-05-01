using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using MoneyXChangeServer.Controllers;
using MoneyXChangeServer.Core.DTO;
using MoneyXChangeServer.Core.Manager.Abstract;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace ApiXUnitTestProject
{
    public class ApiControllerUnitTest
    {
        [Fact]
        public void Get_All_Currencies()
        {
            var currencyManagerMock = new Mock<ICurrencyManager>();
            currencyManagerMock.Setup(x => x.GetAllCurrency()).Returns(() => new SymbolsDto()
            {
                symbols = new Dictionary<string, string>
                {
                    { "ARS", "Argentine peso" },
                    { "EUR", "Euro" },
                    { "USD", "United States dollar" }
                }
            });

            var currencyController = new ApiController(currencyManagerMock.Object);
            var result = currencyController.GetCurrencies();
            // Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var symbolsDto = okResult.Value.Should().BeAssignableTo<SymbolsDto>().Subject;
            symbolsDto.symbols["EUR"].Should().Be("Euro");
        }

        [Fact]
        public void Get_Exchange_Rate_From_USD_To_EUR()
        {
            var currencyManagerMock = new Mock<ICurrencyManager>();
            currencyManagerMock.Setup(x => x.GetConversionRate("USD", "EUR")).Returns(() => 
            new SymbolRatesDto()
            {
                @base = "USD",
                date = $"{DateTime.Now:yyyy/MM/dd}",
                rates = new Dictionary<string, float>
                {
                    { "EUR", 0.82f },
                }
            });

            var currencyController = new ApiController(currencyManagerMock.Object);
            var result = currencyController.GetExchangeRates("USD", "EUR");
            // Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var symbolRatesDto = okResult.Value.Should().BeAssignableTo<SymbolRatesDto>().Subject;
            symbolRatesDto.rates["EUR"].Should().Be(0.82f);
        }

        [Fact]
        public void Get_Exchange_Rate_From_USD2_To_EUR()
        {
            var currencyManagerMock = new Mock<ICurrencyManager>();
            currencyManagerMock.Setup(x => x.GetConversionRate("USD2", "EUR")).Returns(() =>
                null);

            var currencyController = new ApiController(currencyManagerMock.Object);
            var result = currencyController.GetExchangeRates("USD2", "EUR");
            // Assert
            var noContentResult = result.Should().BeOfType<NoContentResult>().Subject;
        }
    }
}
