using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace ModelingworkProvaider
{
    public class RandomForAll
    {
        public Random r_ = new Random();
        public float Parametre(float min=10, float max=60)
        {
            float result = (float)(r_.NextDouble());
            return (float)(min + Math.Abs(result) * (max - min));
        }
        
        public double PuassonNextArrivalTime(double lambda=20)
        {
            // Генерация времени до следующего появления пользователя по Пуассоновскому распределению
            double u = r_.NextDouble();
            double data = -Math.Log(1 - u) / lambda;
            return 3600*data;
        }

        public double Parametre_ravn(double min=10, double max=60)//равномерное распределение
        {
            return (min + r_.NextDouble() * (max - min));
        }

        public double ExponecialNextArrivalTime(double lambda = 20)
        {
            return 3600*-Math.Log(r_.NextDouble()) / lambda;
        }

        public double GenerateNormalDistribution(double mean=60, double stdDev=5)
        {
            double u1 = 1.0 - r_.NextDouble(); // Равномерно распределенное число от 0 до 1
            double u2 = 1.0 - r_.NextDouble();
            double normal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2); // Используется Box-Muller transform
            int r = r_.Next(-1, 1);
            if (stdDev > mean)
            {
                stdDev = mean;
            }
            return mean + r*stdDev * normal; // Преобразование к нужному среднему и стандартному отклонению
        }
    }
}
