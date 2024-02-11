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
        public float Parametre(float min, float max)
        {
            float result = (float)(r_.NextDouble());
            return (float)(min + Math.Abs(result) * (max - min));
        }
        public float Poisson(double lambda)
        {
            Random rand = new Random();
            double L = Math.Exp(-lambda);
            double p = 1.0;
            int k = 0;
            do
            {
                k++;
                p *= rand.NextDouble();
            }
            while (p > L);
            return k - 1;
        }
        

        public float Parametre_ravn(float min, float max)//равномерное распределение
        {
            return (float)(min + r_.NextDouble() * (max - min));
        }

        public double Generate()
        {

            return 0;
        }

        public double GenerateNormalDistribution(double mean, double stdDev)
        {
            double u1 = 1.0 - r_.NextDouble(); // Равномерно распределенное число от 0 до 1
            double u2 = 1.0 - r_.NextDouble();
            double normal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2); // Используется Box-Muller transform
            return (mean + stdDev * normal) * 60; // Преобразование к нужному среднему и стандартному отклонению
        }
    }
}
