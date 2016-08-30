using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace triangle
{
    class parser
    {



        static parser()
        {
            Console.WriteLine("Simple = " + anlizer(fileReader("../../simple_triangle.txt")));
            Console.WriteLine("Hard = " + anlizer(fileReader("../../triangle.txt")));
        }

    
        private static int anlizer(int[][] graph)
        {
            int n = graph.Length - 2;

            while(n >=0)
            {
                int i = 0;
                while (i <=n)
                {
                    int j;
                    if (i == 0)
                        j = 0;
                    else
                        j = i - 1;
                    int tmp = 0;
                    while (j <= i+1)
                    {
                        if (tmp < graph[n + 1][j])
                            tmp = graph[n + 1][j];
                        ++j;
                    }
                    graph[n][i] += tmp;
                    ++i;
                }
                --n;
            }

            return graph[0][0];
        }

        private static int[][] fileReader(string fileName) //read file
        {

            string file = File.ReadAllText(fileName);

            int[] nums = file
                .Split(new char[] { ' ', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(n))
                .ToArray();

            int power = Convert.ToInt32(Math.Sqrt(nums.Length * 2));


            int[][] graph = new int[power][];

            int i = 0, sizePower=0;
            
            while(i< nums.Length)
            {
                graph[sizePower] = new int[sizePower + 1];
                int j = 0;
                while (j <= sizePower)
                {
                    graph[sizePower][j++] = nums[i++];
                }
                ++sizePower;
            }

            return graph;
        }
        

        

    }
}
