using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze01
{
        class Program
        {
	static void draw(ref int[,] maze)
	{
	        for(int i = 0; i < maze.GetLength(0); i ++)
	        {
		for (int j = 0; j < maze.GetLength(1); j++)
		{
		        if(maze[i, j] == 1)
		        {
			Console.Write("■");
		        }
		        else
		        {
			Console.Write("　");
		        }
		}
		Console.WriteLine();
	        }
	}
	static void Main(string[] args)
	{
	        int[,] maze = 
{{1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
 {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
 {1, 0, 1, 1, 1, 1, 1, 1, 1, 0, 1},
 {1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1},
 {1, 0, 1, 1, 1, 1, 1, 1, 1, 0, 1},
 {1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1},
 {1, 0, 1, 0, 1, 0, 1, 1, 1, 0, 1},
 {1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 1},
 {1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1},
 {1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1},
 {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}};

	        draw(ref maze);
	}
        }
}
