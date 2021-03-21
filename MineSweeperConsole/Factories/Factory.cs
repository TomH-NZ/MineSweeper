
using MineSweeper.Game;
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

        public static IDisplay NewDisplayLogic()
        {
            return new Display();
        }

        public static IConvertUserInput newUserInputConverter()
        {
            return new ConvertUserInput();
        }
    }
}