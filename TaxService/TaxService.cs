
namespace TaxServiceProject
{
    public class TaxService
    {
        private ITaxCalculator taxCalculator;

        public TaxService(ITaxCalculator taxCalculator)
        {
            this.taxCalculator = taxCalculator;
        }

        public string GetTaxRateLocation(string zip, dynamic OptionalLocation)
        {
            return taxCalculator.GetTaxRateLocation(zip, OptionalLocation);
        }
        public string GetTaxRateLocation(string zip)
        {
            return taxCalculator.GetTaxRateLocation(zip);
        }
        public string CalculateTaxOrder(dynamic orderObject)
        {
            return taxCalculator.CalculateTaxOrder(orderObject);
        }
    }
}
