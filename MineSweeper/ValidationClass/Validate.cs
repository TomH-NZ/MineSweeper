// ReSharper disable once CheckNamespace
namespace MineSweeper_v01
{
    public class Validate
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
    }
}