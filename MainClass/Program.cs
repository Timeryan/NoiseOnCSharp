
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Threading;

namespace NoiseOnCSharp
{

    class MainClass
    {
        public static void Main(string[] args)
        {
            int count = 70; //70
            int size = 256; //256
            int probability1 = 10; //10
            int probability2 = 1; //1
            int probability3 = 9; //9

            int probability4 = 10; //10
            int probability5 = 9; //9
            int probability6 = 1; //1
            int count3 = 30; //30
            
            var bmp = new Bitmap(size, size);
            int[,] map = new int[size, size];
            map = generateWater(map, size);
            map = generateGrass(map, size, count, probability1, probability2, probability3);
            map = generateTree(map, size, count3, probability4, probability5, probability6);
            //преобразования в картинку
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (map[i, j] == 1)
                        bmp.SetPixel(i, j, Color.Black);
                    if (map[i, j] == 0)
                        bmp.SetPixel(i, j, Color.White);
                    if (map[i, j] == 2)
                        bmp.SetPixel(i, j, Color.Red);
                }
            }



            bmp.Save("C:\\Users\\Тимерьян\\Desktop\\1.png", ImageFormat.Png);
            Console.WriteLine(map.Length);
        }

        public static int[,] generateWater(int[,] map, int size)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    map[i, j] = 0;
                }
            }

            return map;
        }

        public static int[,] generateGrass(int[,] map, int size, int count, int probability1, int probability2,int probability3)
        {
            Random rand =  new Random();
            for (int i = 0; i < size; i++)
            {
                int temp = rand.Next(size);
                if (rand.Next(probability1) == 0)
                    map[i, temp] = 1;
            }


            while (count != 0)
            {
                for (int i = 0; i < Math.Sqrt(map.Length); i++)
                {
                    for (int j = 0; j < Math.Sqrt(map.Length); j++)
                    {
                        if (map[i, j] == 1)
                        {
                            if (rand.Next(probability3) == 0)
                            {
                                if ((rand.Next(probability2) == 0) && ((i + 1) < size) && ((j + 1) < size))
                                    map[i + 1, j + 1] = 1;
                                if ((rand.Next(probability2) == 0) && ((i - 1) > -1) && ((j + 1) < size))
                                    map[i - 1, j + 1] = 1;
                                if ((rand.Next(probability2) == 0) && ((i + 1) < size) && ((j - 1) > -1))
                                    map[i + 1, j - 1] = 1;
                                if ((rand.Next(probability2) == 0) && ((i - 1) > -1) && ((j - 1) > -1))
                                    map[i - 1, j - 1] = 1;
                                if ((rand.Next(probability2) == 0) && ((j + 1) < size))
                                    map[i, j + 1] = 1;
                                if ((rand.Next(probability2) == 0) && ((i + 1) < size))
                                    map[i + 1, j] = 1;
                                if ((rand.Next(probability2) == 0) && ((j - 1) > -1))
                                    map[i, j - 1] = 1;
                                if ((rand.Next(probability2) == 0) && ((i - 1) > -1))
                                    map[i - 1, j] = 1;
                            }
                        }
                    }
                }

                count -= 1;
            }

            return map;
        }

        public static int[,] generateTree(int[,] map, int size, int count3, int probability4, int probability5,int probability6)
        {
            Random rand = new Random();
            for (int i = 0; i < size; i++)
            {
                int temp = rand.Next(size);
                if ((rand.Next(probability4) == 0) && (map[i, temp] == 1))
                    map[i, temp] = 2;
            }

            while (count3 != 0)
            {
                for (int i = 0; i < Math.Sqrt(map.Length); i++)
                {
                    for (int j = 0; j < Math.Sqrt(map.Length); j++)
                    {
                        if (map[i, j] == 2)
                        {
                            if (rand.Next(probability5) == 0)
                            {
                                if ((rand.Next(probability6) == 0) && ((i + 1) < size) && ((j + 1) < size) &&
                                    (map[i + 1, j + 1] == 1))
                                    map[i + 1, j + 1] = 2;
                                if ((rand.Next(probability6) == 0) && ((i - 1) > -1) && ((j + 1) < size) &&
                                    (map[i - 1, j + 1] == 1))
                                    map[i - 1, j + 1] = 2;
                                if ((rand.Next(probability6) == 0) && ((i + 1) < size) && ((j - 1) > -1) &&
                                    (map[i + 1, j - 1] == 1))
                                    map[i + 1, j - 1] = 2;
                                if ((rand.Next(probability6) == 0) && ((i - 1) > -1) && ((j - 1) > -1) &&
                                    (map[i - 1, j - 1] == 1))
                                    map[i - 1, j - 1] = 2;
                                if ((rand.Next(probability6) == 0) && ((j + 1) < size) && (map[i, j + 1] == 1))
                                    map[i, j + 1] = 2;
                                if ((rand.Next(probability6) == 0) && ((i + 1) < size) && (map[i + 1, j] == 1))
                                    map[i + 1, j] = 2;
                                if ((rand.Next(probability6) == 0) && ((j - 1) > -1) && (map[i, j - 1] == 1))
                                    map[i, j - 1] = 2;
                                if ((rand.Next(probability6) == 0) && ((i - 1) > -1) && (map[i - 1, j] == 1))
                                    map[i - 1, j] = 2;
                            }
                        }
                    }
                }

                count3 -= 1;
            }

            return map;
        }
    }
}