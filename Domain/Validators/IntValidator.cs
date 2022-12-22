namespace WebApi_SQL_SAMPLE.Validators
{
    public class IntValidator
    {
        public bool ValidateInt(int idNum)
        {
            try
            {
                var isNumeric = idNum.GetType() == typeof(int);
                return isNumeric;
            }
            catch
            {
                return false;
            }
        }
    }
}
