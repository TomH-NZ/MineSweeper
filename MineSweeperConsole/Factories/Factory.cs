
using MineSweeper.Interfaces;
using MineSweeper.Validation;

namespace MineSweeper.Factories
{
    public class Factory
    {
        public static IValidate NewUserInputValidation()
        {
            return new Validate();
        }
    }
}