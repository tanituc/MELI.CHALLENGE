using Challenge.ExternalServices;
using Challenge.Service;
using Challenge.Shared;
using Challenge.Shared.Models;
using Challenge.Shared.DTOs;
using static Challenge.Shared.PolyEnums.Countries;
using Challenge.Service.Interfaces;

namespace Challenge.Tests
{
    public class RiskmentShould
    {
        [Fact]
        public void ValidateTotalAmmount()
        {
            //Arrange
            PolyEnumsSingleton singleton = PolyEnumsSingleton.GetInstance();
            User user = new User()
            {
                Id = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
            };
            List<Payment> payments = new List<Payment>();
            payments.Add(new Payment {
                Id = Guid.NewGuid(),
                UserId = user.Id,
                StatusId = singleton.statuses.Find(x => x.Value == "Approved").Id,
                CountryId = singleton.countries.First().Id,
                Country = singleton.countries.First().Name,
                Currency = singleton.countries.First().Currency,
                Ammount = 8400,
                AmmountUSD = CurrencyConverter.ConvertARStoUSD(8400, 200),
                PaymentDate = DateTime.Now
            });
            payments.Add(new Payment
            {
                Id = Guid.NewGuid(),
                UserId = user.Id,
                StatusId = singleton.statuses.Find(x => x.Value == "Rejected").Id,
                CountryId = singleton.countries.First().Id,
                Country = singleton.countries.First().Name,
                Currency = singleton.countries.First().Currency,
                Ammount = 8400,
                AmmountUSD = CurrencyConverter.ConvertARStoUSD(8400, 200),
                PaymentDate = DateTime.Now.AddDays(-8)
            });
            payments.Add(new Payment
            {
                Id = Guid.NewGuid(),
                UserId = user.Id,
                StatusId = singleton.statuses.Find(x => x.Value == "Rejected").Id,
                CountryId = singleton.countries.First().Id,
                Country = singleton.countries.First().Name,
                Currency = singleton.countries.First().Currency,
                Ammount = 8400,
                AmmountUSD = CurrencyConverter.ConvertARStoUSD(8400, 200),
                PaymentDate = DateTime.Now
            });

            UserRiskValidationResponse expected = new()
            { 
                IsNewId = true,
                RejectedPaymentsQuantityLastDay = 1,
                TotalAmmountLastWeek = 42,
            };
            RiskmentService riskmentService = new RiskmentService();
            //Act
            var result = riskmentService.CreateUserRiskValidation(payments, user);
            //Assert
            Assert.Equal(expected.TotalAmmountLastWeek, result.TotalAmmountLastWeek);
        }
        [Fact]
        public void InvalidateTotalAmmount() {
            //Arrange
            PolyEnumsSingleton singleton = PolyEnumsSingleton.GetInstance();
            User user = new User()
            {
                Id = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
            };
            List<Payment> payments = new List<Payment>();
            payments.Add(new Payment
            {
                Id = Guid.NewGuid(),
                UserId = user.Id,
                StatusId = singleton.statuses.Find(x => x.Value == "Approved").Id,
                CountryId = singleton.countries.First().Id,
                Country = singleton.countries.First().Name,
                Currency = singleton.countries.First().Currency,
                Ammount = 8400,
                AmmountUSD = CurrencyConverter.ConvertARStoUSD(8400, 200),
                PaymentDate = DateTime.Now
            });
            payments.Add(new Payment
            {
                Id = Guid.NewGuid(),
                UserId = user.Id,
                StatusId = singleton.statuses.Find(x => x.Value == "Rejected").Id,
                CountryId = singleton.countries.First().Id,
                Country = singleton.countries.First().Name,
                Currency = singleton.countries.First().Currency,
                Ammount = 8400,
                AmmountUSD = CurrencyConverter.ConvertARStoUSD(8400, 200),
                PaymentDate = DateTime.Now.AddDays(-8)
            });
            payments.Add(new Payment
            {
                Id = Guid.NewGuid(),
                UserId = user.Id,
                StatusId = singleton.statuses.Find(x => x.Value == "Approved").Id,
                CountryId = singleton.countries.First().Id,
                Country = singleton.countries.First().Name,
                Currency = singleton.countries.First().Currency,
                Ammount = 8400,
                AmmountUSD = CurrencyConverter.ConvertARStoUSD(8400, 200),
                PaymentDate = DateTime.Now
            });

            UserRiskValidationResponse expected = new()
            {
                IsNewId = true,
                RejectedPaymentsQuantityLastDay = 1,
                TotalAmmountLastWeek = 42,
            };
            RiskmentService riskmentService = new RiskmentService();
            //Act
            var result = riskmentService.CreateUserRiskValidation(payments, user);
            //Assert
            Assert.NotEqual(expected.TotalAmmountLastWeek, result.TotalAmmountLastWeek);
        }
        [Fact]
        public void ValidateIsNewId()
        {
            //Arrange
            PolyEnumsSingleton singleton = PolyEnumsSingleton.GetInstance();
            User user = new User()
            {
                Id = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
            };
            List<Payment> payments = new List<Payment>();
            payments.Add(new Payment
            {
                Id = Guid.NewGuid(),
                UserId = user.Id,
                StatusId = singleton.statuses.Find(x => x.Value == "Approved").Id,
                CountryId = singleton.countries.First().Id,
                Country = singleton.countries.First().Name,
                Currency = singleton.countries.First().Currency,
                Ammount = 8400,
                AmmountUSD = CurrencyConverter.ConvertARStoUSD(8400, 200),
                PaymentDate = DateTime.Now
            });
            payments.Add(new Payment
            {
                Id = Guid.NewGuid(),
                UserId = user.Id,
                StatusId = singleton.statuses.Find(x => x.Value == "Rejected").Id,
                CountryId = singleton.countries.First().Id,
                Country = singleton.countries.First().Name,
                Currency = singleton.countries.First().Currency,
                Ammount = 8400,
                AmmountUSD = CurrencyConverter.ConvertARStoUSD(8400, 200),
                PaymentDate = DateTime.Now.AddDays(-8)
            });
            payments.Add(new Payment
            {
                Id = Guid.NewGuid(),
                UserId = user.Id,
                StatusId = singleton.statuses.Find(x => x.Value == "Approved").Id,
                CountryId = singleton.countries.First().Id,
                Country = singleton.countries.First().Name,
                Currency = singleton.countries.First().Currency,
                Ammount = 8400,
                AmmountUSD = CurrencyConverter.ConvertARStoUSD(8400, 200),
                PaymentDate = DateTime.Now
            });

            UserRiskValidationResponse expected = new()
            {
                IsNewId = true,
                RejectedPaymentsQuantityLastDay = 1,
                TotalAmmountLastWeek = 42,
            };
            RiskmentService riskmentService = new RiskmentService();
            //Act
            var result = riskmentService.CreateUserRiskValidation(payments, user);
            //Assert
            Assert.Equal(expected.IsNewId, result.IsNewId);
        }
        [Fact]
        public void InvalidateIsNewId()
        {
            //Arrange
            PolyEnumsSingleton singleton = PolyEnumsSingleton.GetInstance();
            User user = new User()
            {
                Id = Guid.NewGuid(),
                CreatedDate = DateTime.Now.AddDays(-8),
            };
            List<Payment> payments = new List<Payment>();
            payments.Add(new Payment
            {
                Id = Guid.NewGuid(),
                UserId = user.Id,
                StatusId = singleton.statuses.Find(x => x.Value == "Approved").Id,
                CountryId = singleton.countries.First().Id,
                Country = singleton.countries.First().Name,
                Currency = singleton.countries.First().Currency,
                Ammount = 8400,
                AmmountUSD = CurrencyConverter.ConvertARStoUSD(8400, 200),
                PaymentDate = DateTime.Now
            });
            payments.Add(new Payment
            {
                Id = Guid.NewGuid(),
                UserId = user.Id,
                StatusId = singleton.statuses.Find(x => x.Value == "Rejected").Id,
                CountryId = singleton.countries.First().Id,
                Country = singleton.countries.First().Name,
                Currency = singleton.countries.First().Currency,
                Ammount = 8400,
                AmmountUSD = CurrencyConverter.ConvertARStoUSD(8400, 200),
                PaymentDate = DateTime.Now.AddDays(-8)
            });
            payments.Add(new Payment
            {
                Id = Guid.NewGuid(),
                UserId = user.Id,
                StatusId = singleton.statuses.Find(x => x.Value == "Approved").Id,
                CountryId = singleton.countries.First().Id,
                Country = singleton.countries.First().Name,
                Currency = singleton.countries.First().Currency,
                Ammount = 8400,
                AmmountUSD = CurrencyConverter.ConvertARStoUSD(8400, 200),
                PaymentDate = DateTime.Now
            });

            UserRiskValidationResponse expected = new()
            {
                IsNewId = true,
                RejectedPaymentsQuantityLastDay = 1,
                TotalAmmountLastWeek = 42,
            };
            RiskmentService riskmentService = new RiskmentService();
            //Act
            var result = riskmentService.CreateUserRiskValidation(payments, user);
            //Assert
            Assert.NotEqual(expected.IsNewId, result.IsNewId);
        }
        [Fact]
        public void ValidateRejectedPaymentsQuantityLastDay()
        {
            //Arrange
            PolyEnumsSingleton singleton = PolyEnumsSingleton.GetInstance();
            User user = new User()
            {
                Id = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
            };
            List<Payment> payments = new List<Payment>();
            payments.Add(new Payment
            {
                Id = Guid.NewGuid(),
                UserId = user.Id,
                StatusId = singleton.statuses.Find(x => x.Value == "Approved").Id,
                CountryId = singleton.countries.First().Id,
                Country = singleton.countries.First().Name,
                Currency = singleton.countries.First().Currency,
                Ammount = 8400,
                AmmountUSD = CurrencyConverter.ConvertARStoUSD(8400, 200),
                PaymentDate = DateTime.Now
            });
            payments.Add(new Payment
            {
                Id = Guid.NewGuid(),
                UserId = user.Id,
                StatusId = singleton.statuses.Find(x => x.Value == "Rejected").Id,
                CountryId = singleton.countries.First().Id,
                Country = singleton.countries.First().Name,
                Currency = singleton.countries.First().Currency,
                Ammount = 8400,
                AmmountUSD = CurrencyConverter.ConvertARStoUSD(8400, 200),
                PaymentDate = DateTime.Now.AddDays(-8)
            });
            payments.Add(new Payment
            {
                Id = Guid.NewGuid(),
                UserId = user.Id,
                StatusId = singleton.statuses.Find(x => x.Value == "Rejected").Id,
                CountryId = singleton.countries.First().Id,
                Country = singleton.countries.First().Name,
                Currency = singleton.countries.First().Currency,
                Ammount = 8400,
                AmmountUSD = CurrencyConverter.ConvertARStoUSD(8400, 200),
                PaymentDate = DateTime.Now
            });

            UserRiskValidationResponse expected = new()
            {
                IsNewId = true,
                RejectedPaymentsQuantityLastDay = 1,
                TotalAmmountLastWeek = 42,
            };
            RiskmentService riskmentService = new RiskmentService();
            //Act
            var result = riskmentService.CreateUserRiskValidation(payments, user);
            //Assert
            Assert.Equal(expected.RejectedPaymentsQuantityLastDay, result.RejectedPaymentsQuantityLastDay);
        }
        [Fact]
        public void InvalidateRejectedPaymentsQuantityLastDay()
        {
            //Arrange
            PolyEnumsSingleton singleton = PolyEnumsSingleton.GetInstance();
            User user = new User()
            {
                Id = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
            };
            List<Payment> payments = new List<Payment>();
            payments.Add(new Payment
            {
                Id = Guid.NewGuid(),
                UserId = user.Id,
                StatusId = singleton.statuses.Find(x => x.Value == "Approved").Id,
                CountryId = singleton.countries.First().Id,
                Country = singleton.countries.First().Name,
                Currency = singleton.countries.First().Currency,
                Ammount = 8400,
                AmmountUSD = CurrencyConverter.ConvertARStoUSD(8400, 200),
                PaymentDate = DateTime.Now
            });
            payments.Add(new Payment
            {
                Id = Guid.NewGuid(),
                UserId = user.Id,
                StatusId = singleton.statuses.Find(x => x.Value == "Rejected").Id,
                CountryId = singleton.countries.First().Id,
                Country = singleton.countries.First().Name,
                Currency = singleton.countries.First().Currency,
                Ammount = 8400,
                AmmountUSD = CurrencyConverter.ConvertARStoUSD(8400, 200),
                PaymentDate = DateTime.Now.AddDays(-8)
            });
            payments.Add(new Payment
            {
                Id = Guid.NewGuid(),
                UserId = user.Id,
                StatusId = singleton.statuses.Find(x => x.Value == "Approved").Id,
                CountryId = singleton.countries.First().Id,
                Country = singleton.countries.First().Name,
                Currency = singleton.countries.First().Currency,
                Ammount = 8400,
                AmmountUSD = CurrencyConverter.ConvertARStoUSD(8400, 200),
                PaymentDate = DateTime.Now
            });

            UserRiskValidationResponse expected = new()
            {
                IsNewId = true,
                RejectedPaymentsQuantityLastDay = 1,
                TotalAmmountLastWeek = 42,
            };
            RiskmentService riskmentService = new RiskmentService();
            //Act
            var result = riskmentService.CreateUserRiskValidation(payments, user);
            //Assert
            Assert.NotEqual(expected.RejectedPaymentsQuantityLastDay, result.RejectedPaymentsQuantityLastDay);
        }
    }
}