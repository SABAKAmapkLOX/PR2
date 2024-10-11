namespace LibMas
{
    public class randomMas
    {
        public static void InitMas(out int[] mas, int column, int randMax)
        {
            Random rnd; rnd = new Random();
            mas = new int[column]; 
            for (int i = 0; i < column; i++)
            {
                mas[i] = rnd.Next(randMax);
            }
        }
    }
}
