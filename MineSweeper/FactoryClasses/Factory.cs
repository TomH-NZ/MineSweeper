// ReSharper disable once CheckNamespace
namespace MineSweeper_v01
{
    public class Factory
    {
        public static IValidate NewUserInputValidation()
        {
            return new Validate();
        }
    }
}