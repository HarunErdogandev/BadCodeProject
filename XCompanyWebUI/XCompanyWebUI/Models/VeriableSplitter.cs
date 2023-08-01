using XCompanyWebUI.Models.Entities;

namespace XCompanyWebUI.Models
{
    public class VeriableSplitter
    {

        public static decimal Split(decimal value)
        {

            char separator = ',';

            string amaount = value.ToString();
            int index = amaount.IndexOf(separator);
            if (index > 0)
            {
                decimal modifiedamount = Convert.ToDecimal(amaount.Substring(0, index));
                value = modifiedamount;
            }

            return value;
        }
       
    }
}
