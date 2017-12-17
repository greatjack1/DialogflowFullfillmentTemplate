using System;
namespace DialogflowFullfillmentTemplate.ExtensionMethods
{
    public static class DateTimeExtensionMethods
    {
        public static String formatDate(this DateTime? dt)
        {
            String formatter = "{0:h:mm:sstt}";
            return String.Format(formatter, dt.GetValueOrDefault());
        }
    }
}
