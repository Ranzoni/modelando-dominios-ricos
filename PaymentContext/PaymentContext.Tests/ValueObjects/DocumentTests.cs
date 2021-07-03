using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests
{
    [TestClass]
    public class DocumentTests
    {
        [TestMethod]
        [DataTestMethod]
        [DataRow("123")]
        [DataRow("450899718031561")]
        public void ShouldReturnErrorWhenCNPJIsInvalid(string cnpj)
        {
            var doc = new Document(cnpj, EDocumentType.CNPJ);
           Assert.IsTrue(!doc.IsValid);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("39010418000115")]
        [DataRow("53113791000122")]
        [DataRow("06990590000123")]
        public void ShouldReturnSuccessWhenCNPJIsValid(string cnpj)
        {
            var doc = new Document(cnpj, EDocumentType.CNPJ);
           Assert.IsTrue(doc.IsValid);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("123")]
        [DataRow("450899718031561")]
        public void ShouldReturnErrorWhenCPFIsInvalid(string cpf)
        {
           var doc = new Document(cpf, EDocumentType.CPF);
           Assert.IsTrue(!doc.IsValid);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("45089971803")]
        [DataRow("43574114672")]
        [DataRow("16412595074")]
        public void ShouldReturnSuccessWhenCPFIsValid(string cpf)
        {
           var doc = new Document(cpf, EDocumentType.CPF);
           Assert.IsTrue(doc.IsValid);
        }
    }
}
