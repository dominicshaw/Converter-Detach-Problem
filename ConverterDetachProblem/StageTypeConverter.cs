using System;
using System.ComponentModel;
using System.Linq;

namespace ConverterDetachProblem
{
    public class StageTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
                return true;

            return base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            if (value is string)
            {
                var child = Stages.AllStages.FirstOrDefault(x => x.Name == (string)value);

                return child;
            }

            return base.ConvertFrom(context, culture, value);
        }

        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                var childObject = (Stage)value;

                return childObject.Name;
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}