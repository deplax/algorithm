using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Maze01
{
        class MyStack
        {
	private int[,] stack;
	private int sp = 0;

	public MyStack(int stackSize)
	{
	        stack = new int[stackSize, 2];
	}
	public int Pop()
	{
	        if (sp >= 0)
	        {
		sp--;
		return 0;
	        }
	        Console.WriteLine("stack bottom!!");
	        return -1;
	}

	public int CurrentStackX()
	{
	        return stack[sp - 1 , 0];
	}
	public int CurrentStackY()
	{
	        return stack[sp - 1 , 1];
	}

	public int Push(int x, int y)
	{
	        if(sp < stack.GetLength(0))
	        {
		stack[sp, 0] = x;
		stack[sp, 1] = y;
		sp++;
		return 0;
	        }
	        Console.WriteLine("stack Limit!!");
	        return -1;
	}
	public void PrintStack()
	{
	        for(int i = 0; i < sp; i++)
	        {
		Console.WriteLine("{0,2}: {1,2}, {2,2}", i, stack[i, 0], stack[i, 1]);
	        }
	}

	public void Draw(int[,] maze)
	{
	        for (int i = 0; i < maze.GetLength(0); i++)
	        {
		for (int j = 0; j < maze.GetLength(1); j++)
		{
		        if (maze[i, j] == 1)
		        {
			Console.Write("■");
		        }
		        else if(maze[i, j] == 3)
		        {
			Console.Write("○");
		        }
		        else
		        {
			Console.Write("　");
		        }
		}
		Console.WriteLine();
	        }
	}

	public void PrintStackAni(int[,] maze)
	{
	    
	        for (int i = 0; i < sp; i++)
	        {
		Console.Clear();
		maze[stack[i, 0], stack[i, 1]] = 3;
		Draw(maze);
		System.Threading.Thread.Sleep(100);
	        }
	        
	}

        }
         class InputText
        {
	StreamReader sr = new StreamReader("maze1.txt", Encoding.GetEncoding("euc-kr"));
	public string alltext = "";
                public void ReadText()
	{
	        string line = "";
	        while (sr.Peek() != -1)
	        {
		line = sr.ReadLine();
		alltext += line + "\r\n";
	        }
        	}

	public void PrintText()
	{
	        Console.Write(alltext);
	}

	public void ReplaceText()
	{
	       alltext = alltext.Replace("1 ", "1, ");
	       alltext = alltext.Replace("0 ", "0, ");
	       alltext = alltext.Replace("[", "{");
	       alltext = alltext.Replace("]", "}");
	       alltext = alltext.Replace("}\r\n", "},\r\n");
	       alltext = alltext.Replace("}},", "}}");
	}
        }
        class Program
        {
	
	static void Main(string[] args)
	{
	        InputText ip = new InputText();
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

	        

	        int x = 1, y = 1;			

	        MyStack st = new MyStack(100);
	        st.Draw(maze);
	        st.Push(x, y);				//start point
	        MoveMaze(st, maze, x, y);
	       st.PrintStackAni(maze);
	        st.PrintStack();
   
	   

	}
	static void MoveMaze(MyStack st, int[,] maze, int x, int y)
	{
	        if (maze.GetLength(0) - 2 == x && maze.GetLength(1) - 2 == y)
	        {
		return;
	        }
	        if(maze[x - 1, y] == 0) //위쪽
	        {
		st.Push(x - 1, y);
		maze[x , y] = 2;
		MoveMaze(st, maze, x - 1, y);
	        }
	        else if(maze[x, y - 1] == 0) //왼쪽
	        {
		st.Push(x, y - 1);
		maze[x, y] = 2;
		MoveMaze(st, maze, x, y - 1);
	        }
	        else if (maze[x + 1, y] == 0) //아래쪽
	        {
		st.Push(x + 1, y);
		maze[x, y] = 2;
		MoveMaze(st, maze, x + 1, y);
	        }
	        else if (maze[x, y + 1] == 0) //오른쪽
	        {
		st.Push(x, y + 1);
		maze[x, y] = 2;
		MoveMaze(st, maze, x, y + 1);
	        }
	        else
	        {
		maze[x, y] = 2;
		st.Pop();
		MoveMaze(st, maze, st.CurrentStackX() , st.CurrentStackY() );
		return;
	        }
	}
        }
}
