
namespace TaxServiceProject
{
    public interface ITaxCalculator
    {

        public string GetTaxRateLocation(string zip, dynamic OptionalLocation);
        public string GetTaxRateLocation(string zip);
        public string CalculateTaxOrder(dynamic orderObject);

    }
}
