namespace MVCPractices.SharedKernel
{
    public static class UtilityExtenions
    {


        public static int ToInt(this string input)
        {
            if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))
                return 0;


            if (int.TryParse(input, out var value))
            {
                return value;
            }

            return 0;


        }


        
    }
}