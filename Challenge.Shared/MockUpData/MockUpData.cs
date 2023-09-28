using Challenge.ExternalServices;
using Challenge.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Challenge.Shared.PolyEnums.Countries;

namespace Challenge.Shared.MockUpData
{
    public class MockUpData
    {
        public List<User> users;
        public List<Payment> payments;
        public MockUpData()
        {

            Random random = new Random();
            PolyEnumsSingleton singleton = PolyEnumsSingleton.GetInstance();
            double uSDPrice = CurrencyConverter.GetUSDPrice();

            users = new();
            users.Add(createUser(Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"), "9/26/2023 8:39:38 PM"));
            users.Add(createUser(Guid.Parse("4ba90b99-7a1f-4c51-8350-9e90b1e6c0c5"), "9/26/2023 8:39:38 PM"));
            users.Add(createUser(Guid.Parse("6e5c06f7-4d1f-4311-8778-64c5e6c2a940"), "9/16/2023 8:39:38 PM"));
            users.Add(createUser(Guid.Parse("87c6d31e-102b-4e97-aa0e-0efbdf497147"), "9/16/2023 8:39:38 PM"));
            users.Add(createUser(Guid.Parse("9d37641c-5ebc-40f4-b42e-63d22db21b9a"), "9/26/2023 8:39:38 PM"));

            payments = new();
            payments.Add(createPayment(
                Guid.NewGuid(),
                users[random.Next(0, 4)].Id,
                singleton.statuses[random.Next(0, 3)].Id,
                singleton.countries[0].Id,
                singleton.countries[0].Name,
                singleton.countries[0].Currency,
                random.Next(500, 99999),
                DateTime.Parse("9/26/2023 8:39:38 PM"),
                uSDPrice
                ));
            payments.Add(createPayment(
                Guid.NewGuid(),
                users[random.Next(0, 4)].Id,
                singleton.statuses[random.Next(0, 3)].Id,
                singleton.countries[0].Id,
                singleton.countries[0].Name,
                singleton.countries[0].Currency,
                random.Next(500, 99999),
                DateTime.Parse("9/26/2023 8:39:38 PM"),
                uSDPrice
                ));
            payments.Add(createPayment(
                Guid.NewGuid(),
                users[random.Next(0, 4)].Id,
                singleton.statuses[random.Next(0, 3)].Id,
                singleton.countries[0].Id,
                singleton.countries[0].Name,
                singleton.countries[0].Currency,
                random.Next(500, 99999),
                DateTime.Parse("9/26/2023 8:39:38 PM"),
                uSDPrice
                ));
            payments.Add(createPayment(
                Guid.NewGuid(),
                users[random.Next(0, 4)].Id,
                singleton.statuses[random.Next(0, 3)].Id,
                singleton.countries[0].Id,
                singleton.countries[0].Name,
                singleton.countries[0].Currency,
                random.Next(500, 99999),
                DateTime.Parse("9/26/2023 8:39:38 PM"),
                uSDPrice
                ));
            payments.Add(createPayment(
                Guid.NewGuid(),
                users[random.Next(0, 4)].Id,
                singleton.statuses[random.Next(0, 3)].Id,
                singleton.countries[0].Id,
                singleton.countries[0].Name,
                singleton.countries[0].Currency,
                random.Next(500, 99999),
                DateTime.Parse("9/26/2023 8:39:38 PM"),
                uSDPrice
                ));
            payments.Add(createPayment(
                Guid.NewGuid(),
                users[random.Next(0, 4)].Id,
                singleton.statuses[random.Next(0, 3)].Id,
                singleton.countries[0].Id,
                singleton.countries[0].Name,
                singleton.countries[0].Currency,
                random.Next(500, 99999),
                DateTime.Parse("9/26/2023 8:39:38 PM"),
                uSDPrice
                ));
            payments.Add(createPayment(
                Guid.NewGuid(),
                users[random.Next(0, 4)].Id,
                singleton.statuses[random.Next(0, 3)].Id,
                singleton.countries[0].Id,
                singleton.countries[0].Name,
                singleton.countries[0].Currency,
                random.Next(500, 99999),
                DateTime.Parse("9/26/2023 8:39:38 PM"),
                uSDPrice
                ));
            payments.Add(createPayment(
                Guid.NewGuid(),
                users[random.Next(0, 4)].Id,
                singleton.statuses[random.Next(0, 3)].Id,
                singleton.countries[0].Id,
                singleton.countries[0].Name,
                singleton.countries[0].Currency,
                random.Next(500, 99999),
                DateTime.Parse("9/26/2023 8:39:38 PM"),
                uSDPrice
                ));
            payments.Add(createPayment(
                Guid.NewGuid(),
                users[random.Next(0, 4)].Id,
                singleton.statuses[random.Next(0, 3)].Id,
                singleton.countries[0].Id,
                singleton.countries[0].Name,
                singleton.countries[0].Currency,
                random.Next(500, 99999),
                DateTime.Parse("9/26/2023 8:39:38 PM"),
                uSDPrice
                ));
            payments.Add(createPayment(
                Guid.NewGuid(),
                users[random.Next(0, 4)].Id,
                singleton.statuses[random.Next(0, 3)].Id,
                singleton.countries[0].Id,
                singleton.countries[0].Name,
                singleton.countries[0].Currency,
                random.Next(500, 99999),
                DateTime.Parse("9/26/2023 8:39:38 PM"),
                uSDPrice
                ));
            payments.Add(createPayment(
                Guid.NewGuid(),
                users[random.Next(0, 4)].Id,
                singleton.statuses[random.Next(0, 3)].Id,
                singleton.countries[0].Id,
                singleton.countries[0].Name,
                singleton.countries[0].Currency,
                random.Next(500, 99999),
                DateTime.Parse("9/26/2023 8:39:38 PM"),
                uSDPrice
                ));
            payments.Add(createPayment(
                Guid.NewGuid(),
                users[random.Next(0, 4)].Id,
                singleton.statuses[random.Next(0, 3)].Id,
                singleton.countries[0].Id,
                singleton.countries[0].Name,
                singleton.countries[0].Currency,
                random.Next(500, 99999),
                DateTime.Parse("9/26/2023 8:39:38 PM"),
                uSDPrice
                ));
            payments.Add(createPayment(
                Guid.NewGuid(),
                users[random.Next(0, 4)].Id,
                singleton.statuses[random.Next(0, 3)].Id,
                singleton.countries[0].Id,
                singleton.countries[0].Name,
                singleton.countries[0].Currency,
                random.Next(500, 99999),
                DateTime.Parse("9/26/2023 8:39:38 PM"),
                uSDPrice
                ));
            payments.Add(createPayment(
                Guid.NewGuid(),
                users[random.Next(0, 4)].Id,
                singleton.statuses[random.Next(0, 3)].Id,
                singleton.countries[0].Id,
                singleton.countries[0].Name,
                singleton.countries[0].Currency,
                random.Next(500, 99999),
                DateTime.Parse("9/26/2023 8:39:38 PM"),
                uSDPrice
                ));
            payments.Add(createPayment(
                Guid.NewGuid(),
                users[random.Next(0, 4)].Id,
                singleton.statuses[random.Next(0, 3)].Id,
                singleton.countries[0].Id,
                singleton.countries[0].Name,
                singleton.countries[0].Currency,
                random.Next(500, 99999),
                DateTime.Parse("9/26/2023 8:39:38 PM"),
                uSDPrice
                ));
            payments.Add(createPayment(
                Guid.NewGuid(),
                users[random.Next(0, 4)].Id,
                singleton.statuses[random.Next(0, 3)].Id,
                singleton.countries[0].Id,
                singleton.countries[0].Name,
                singleton.countries[0].Currency,
                random.Next(500, 99999),
                DateTime.Parse("9/26/2023 8:39:38 PM"),
                uSDPrice
                ));
            payments.Add(createPayment(
                Guid.NewGuid(),
                users[random.Next(0, 4)].Id,
                singleton.statuses[random.Next(0, 3)].Id,
                singleton.countries[0].Id,
                singleton.countries[0].Name,
                singleton.countries[0].Currency,
                random.Next(500, 99999),
                DateTime.Parse("9/26/2023 8:39:38 PM"),
                uSDPrice
                ));
            payments.Add(createPayment(
                Guid.NewGuid(),
                users[random.Next(0, 4)].Id,
                singleton.statuses[random.Next(0, 3)].Id,
                singleton.countries[0].Id,
                singleton.countries[0].Name,
                singleton.countries[0].Currency,
                random.Next(500, 99999),
                DateTime.Parse("9/26/2023 8:39:38 PM"),
                uSDPrice
                ));
            payments.Add(createPayment(
                Guid.NewGuid(),
                users[random.Next(0, 4)].Id,
                singleton.statuses[random.Next(0, 3)].Id,
                singleton.countries[0].Id,
                singleton.countries[0].Name,
                singleton.countries[0].Currency,
                random.Next(500, 99999),
                DateTime.Parse("9/26/2023 8:39:38 PM"),
                uSDPrice
                ));
            payments.Add(createPayment(
                Guid.NewGuid(),
                users[random.Next(0, 4)].Id,
                singleton.statuses[random.Next(0, 3)].Id,
                singleton.countries[0].Id,
                singleton.countries[0].Name,
                singleton.countries[0].Currency,
                random.Next(500, 99999),
                DateTime.Parse("9/26/2023 8:39:38 PM"),
                uSDPrice
                ));
            payments.Add(createPayment(
                Guid.NewGuid(),
                users[random.Next(0, 4)].Id,
                singleton.statuses[random.Next(0, 3)].Id,
                singleton.countries[0].Id,
                singleton.countries[0].Name,
                singleton.countries[0].Currency,
                random.Next(500, 99999),
                DateTime.Parse("9/26/2023 8:39:38 PM"),
                uSDPrice
                ));
        }
        private User createUser(Guid id, string date) => new User() { CreatedDate = DateTime.Parse(date), Id = id };
        private Payment createPayment(
                Guid id,
                Guid userId,
                Guid statusId,
                Guid countryId,
                string country,
                string currency,
                double ammount,
                DateTime paymentDate,
                double uSDPrice
            )
        {
            return new Payment()
            {
                Id = id,
                UserId = userId,
                StatusId = statusId,
                CountryId = countryId,
                Country = country,
                Currency = currency,
                Ammount = ammount,
                AmmountUSD = CurrencyConverter.ConvertARStoUSD(ammount, uSDPrice),
                PaymentDate = (paymentDate)
            };
        }

    }
}
