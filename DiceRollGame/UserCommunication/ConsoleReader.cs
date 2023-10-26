

namespace DiceRollGame.UserCommunication
{
    // (static = use itselfe fixed ,  cannot create instance)
    // static class Only contain Static methods

    public static class ConsoleReader
    {
        public static int ReadInteger(string meassage)
        {
            int result;
            do
            {
                Console.WriteLine(meassage);
            }
            while (!int.TryParse(Console.ReadLine(), out result));
            return result;
        }
    }


}
