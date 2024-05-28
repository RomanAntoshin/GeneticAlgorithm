using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Forms;

namespace GeneticAlgorithm
{
    public static class Reader
    {
        private static void CorrectData(double[,] M)
        {
            double Max = 0;
            for (int i = 0; i < Math.Sqrt(M.Length); i++)
                for (int j = 0; j < Math.Sqrt(M.Length); j++)
                    if (M[i, j] > Max)
                        Max = M[i, j];
            for (int i = 0; i < Math.Sqrt(M.Length); i++)
                M[i, i] = Max * 10;
        }
        public static double[,] GetData(string filename)
        {
            int c = 0;
            string buf;
            double[] buffer;
            int N;
            int i = 0;
            /*OpenFileDialog OD = new OpenFileDialog();
            OD.DefaultExt = ".txt";*/
            /*if (OD.ShowDialog() == DialogResult.OK)
                filename = OD.FileName;*/
            StreamReader sr = new StreamReader(filename);
            buf = sr.ReadLine();
            N = int.Parse(buf);
            double[,] Matr = new double[N, N];
            while (!sr.EndOfStream)
            {
                c++;
                buf = sr.ReadLine();
                buffer = buf.Split(' ').Select(r => Convert.ToDouble(r)).ToArray();
                for (int j = 0; j < buffer.Length; j++)
                    Matr[i, j] = buffer[j];
                i++;
            }
            sr.Close(); // File was been closed
            CorrectData(Matr);
            return Matr;
        }
    }
}
