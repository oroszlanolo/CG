using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

class Player
{
    static void Main(string[] args)
    {
        int firstInitInput = int.Parse(Console.ReadLine());
        int secondInitInput = int.Parse(Console.ReadLine());
        int thirdInitInput = int.Parse(Console.ReadLine());
        Console.Error.WriteLine(firstInitInput);
        Console.Error.WriteLine(secondInitInput);
        Console.Error.WriteLine(thirdInitInput);
        
        int N_size = 40;
        
        char[,] map = new char[N_size,N_size];
        for(int x = 0;x<N_size;x++)
        {
            for(int y = 0;y<N_size;y++)
            {
                map[x,y]='.';
            }
        }
        
        int currpos_X = N_size/2;
        int currpos_Y = N_size/2;
        map[currpos_X,currpos_Y]='o';
        
        int helper = 0;
        while (true)
        {
            string firstInput = Console.ReadLine();
            string secondInput = Console.ReadLine();
            string thirdInput = Console.ReadLine();
            string fourthInput = Console.ReadLine();
            
            Console.Error.WriteLine(firstInput+"\t"+secondInput+"\t"+thirdInput+"\t"+fourthInput);
            
            for (int i = 0; i < thirdInitInput; i++)
            {
                string[] inputs = Console.ReadLine().Split(' ');
                int fifthInput = int.Parse(inputs[0]);
                int sixthInput = int.Parse(inputs[1]);
                Console.Error.WriteLine(fifthInput.ToString()+"\t"+sixthInput.ToString());
            }
            
            if(map[currpos_X,currpos_Y+1] != 'o')
                map[currpos_X,currpos_Y+1]=firstInput[0];
            if(map[currpos_X,currpos_Y-1]!='o')
                map[currpos_X,currpos_Y-1]=thirdInput[0];
            if(map[currpos_X+1,currpos_Y]!='o')
                map[currpos_X+1,currpos_Y]=secondInput[0];
            if(map[currpos_X-1,currpos_Y]!='o')
                map[currpos_X-1,currpos_Y]=fourthInput[0];
            
            
            map[currpos_X,currpos_Y]='o';
            if(map[currpos_X - 1,currpos_Y]=='_')
            {
                currpos_X--;
                map[currpos_X,currpos_Y]='X';
                Console.WriteLine("E");
            }
            else if(map[currpos_X,currpos_Y-1]=='_')
            {
                currpos_Y--;
                map[currpos_X,currpos_Y]='X';
                Console.WriteLine("D");
            }
            else if(map[currpos_X,currpos_Y+1]=='_')
            {
                currpos_Y++;
                map[currpos_X,currpos_Y]='X';
                Console.WriteLine("C");
            }
            else if(map[currpos_X+1,currpos_Y]=='_')
            {
                currpos_X++;
                map[currpos_X,currpos_Y]='X';
                Console.WriteLine("A");
            }else
            {
                Console.WriteLine("A");
            }
            
            for(int y =0;y<N_size;y++)
            {
                string linestring = "";
                for(int x =0;x<N_size;x++)
                {
                    linestring = linestring+map[x,y];
                }
                Console.Error.WriteLine(linestring);
            }
            
        }
    }
}