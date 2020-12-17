using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Tests.Mocks;

namespace PaymentContext.Tests.Handlers
{
    [TestClass]
    public class SubscriptionHandlerTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenDocumentExists()
        {
            var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
            var command = new CreateBoletoSubscriptionCommand();

            command.FirstName="Bruce";
            command.LastName="Wayne";
            command.Document="99999999999";
            command.Email="hello@balta.io2";
            command.BarCode="123455678";
            command.BoletoNumber="2343545";
            command.PaymentNumber="14334325435";
            command.PaidDate=DateTime.Now;
            command.ExpireDate=DateTime.Now.AddMonths(1);
            command.Total=60;
            command.TotalPaid=60;
            command.Payer="WAYNE CORP";
            command.PayerDocument="1452534563";        
            command.PayerEmail="batman@balta.io";
            command.PayerDocumentType=EDocumentType.CPF;
            command.Street="sdfgasdfg";
            command.Number="25425";
            command.Neighbourhood="dfasgdfsg";
            command.City="gasfgas";
            command.State="asgas";
            command.Country="agsdfg";
            command.ZipCode="45145436";

            handler.Handle(command);
            Assert.AreEqual(false, handler.Valid);
        }
    }
}