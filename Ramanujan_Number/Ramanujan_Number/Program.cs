using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ramanujan_Number
{
        class Program
        {
	static void Main(string[] args)
	{
	        List<int> listcube = new List<int>();		//3승을 저장하는 리스트
	        List<int> listadd = new List<int>();		//3승 합을 저장하는 리스트
	        List<int> listpos = new List<int>();
	        bool sw = true;				//원하는 갯수가 찼을때 탈출용 스위치
	        int num = 0;
	        int result = 0;

	        Console.Write("라마누잔 수열\n");
	        Console.Write("몇개를 출력하시겠습니까? : ");
	        int cnt = Convert.ToInt32(Console.ReadLine());
	        while (sw)
	        {
		listcube.Add((int)Math.Pow(num, 3));				//3승 저장
		for (int i = listcube.Count - 2; i >= 1; i--)
		{
		        listadd.Add(listcube[i] + listcube[num]);			//3승 합 저장
		        listpos.Add(listcube[i]);
		        
		        for(int j = 0; j < listadd.Count - 1; j++)
		        {
			if (listadd[j] == listadd[listadd.Count - 1])
			{
			        Console.Write(Math.Pow(listpos[j], 1.0 / 3.0) + "^3 + " + (Math.Pow(listadd[j] - listpos[j], 1.0/3.0)) + "^3 = ");
			        Console.Write(Math.Pow(listpos[listadd.Count - 1], 1.0 / 3.0) + "^3 + " + (Math.Pow(listadd[listadd.Count - 1] - listpos[listadd.Count - 1], 1.0 / 3.0)) + "^3 ");
			        Console.WriteLine("= " + listadd[listadd.Count - 1]);
			        //Console.Write(listadd[j] + " = " + listadd[listadd.Count - 1]);
			        result++;
			        Console.WriteLine(result);
			        if (result == cnt)
				sw = false;
			}
		        }
		}
		num++;
	        }
	}
        }
}
