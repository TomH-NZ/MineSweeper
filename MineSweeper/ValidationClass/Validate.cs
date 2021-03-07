// ReSharper disable once CheckNamespace
namespace MineSweeper_v01
{
    public class Validate : IValidate
    {
        public bool UserGridMove(string userMove)
        {
            var output = false;
            var validatedUserInput = int.TryParse(userMove, out var number);

            if (validatedUserInput && number >= 0 && number <= 9)
            {
                output = true;
            }

            return output;
        }

        public bool InitialGridSize(string userInput)
        {
            var output = false;
            var validatedUserInput = int.TryParse(userInput, out var number);

            if (validatedUserInput && number >= 2 && number <= 10)
            {
                output = true;
            }

            return output;
        }
    }
}