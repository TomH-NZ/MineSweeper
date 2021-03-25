
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

        public static IMessageDisplay NewMessageDisplay()
        {
            return new MessageDisplay();
        }

        public static IUserInputConverter NewUserInputConverter()
        {
            return new UserInputConverter();
        }

        public static IGameCellUpdater NewCellUpdater()
        {
            return new GameCellUpdater();
        }
    }
}