namespace Lib_6
{
    public class Calculater
    {
        public static void SumMas(out int sumMas,int[] mas)
        {
            sumMas = 0;
            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i] < 15)
                {
                    sumMas = sumMas + Convert.ToInt32(mas[i]);
                }
            }
        }
    }
}
