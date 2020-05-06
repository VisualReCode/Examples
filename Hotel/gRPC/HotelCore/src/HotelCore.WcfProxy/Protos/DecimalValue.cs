namespace HotelCore.WcfProxy.Protos
{
    public partial class DecimalValue
    {
        private const decimal NanoFactor = 1_000_000_000;

        public DecimalValue(long units, int nanos)
        {
            Units = units;
            Nanos = nanos;
        }

        public static implicit operator decimal(DecimalValue decimalValue) => decimalValue?.ToDecimal() ?? default;

        public static implicit operator decimal?(DecimalValue decimalValue) => decimalValue?.ToDecimal();

        public static implicit operator DecimalValue(decimal value) => FromDecimal(value);
        
        public static implicit operator DecimalValue(decimal? value) => FromDecimal(value);

        public decimal ToDecimal()
        {
            return Units + (Nanos / NanoFactor);
        }

        public static DecimalValue FromDecimal(decimal value)
        {
            var units = decimal.ToInt64(value);
            var nanos = decimal.ToInt32((value - units) * NanoFactor);
            return new DecimalValue(units, nanos);
        }
        
        public static DecimalValue FromDecimal(decimal? value)
        {
            return value.HasValue ? FromDecimal(value.Value) : null;
        }
    }
}
