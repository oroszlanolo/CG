using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

class Player
{
    class Coord
    {
        public int x;
        public int y;

        public char before;
        public char sign;
        public Coord(int _x, int _y)
        {
            x = _x;
            y = _y;
            sign = '!';
            before = ' ';
        }
    }
    static char[,] map;
    static int N_size, currpos_X, currpos_Y;
    static int firstInitInput;
    static int secondInitInput;
    static int thirdInitInput;

    static string firstInput;
    static string secondInput;
    static string thirdInput;
    static string fourthInput;

    static Coord[] maybeCoords;

    
    static void ClearConsole()
    {
        firstInput = Console.ReadLine();
        secondInput = Console.ReadLine();
        thirdInput = Console.ReadLine();
        fourthInput = Console.ReadLine();
        
        Console.Error.WriteLine(firstInput+"\t"+secondInput+"\t"+thirdInput+"\t"+fourthInput);

        for (int i = 0; i < thirdInitInput; i++)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            int fifthInput = int.Parse(inputs[0]);
            int sixthInput = int.Parse(inputs[1]);
            if(i == 4)
            {
                currpos_X = fifthInput;
                currpos_Y = sixthInput;
            }else
            {
                maybeCoords[i].x = fifthInput;
                maybeCoords[i].y = sixthInput;
            }
            Console.Error.WriteLine(fifthInput.ToString()+"\t"+sixthInput.ToString());
        }
    }

    static void print()
    {
        for(int i = 0; i < thirdInitInput - 1; i++)
        {
            maybeCoords[i].before = map[maybeCoords[i].x,maybeCoords[i].y];
            map[maybeCoords[i].x,maybeCoords[i].y] = maybeCoords[i].sign;
            
        }
        for(int y =0;y<firstInitInput;y++)
        {
            string linestring = "";
            for(int x =0;x<secondInitInput;x++)
            {
                if(x==currpos_X&&y==currpos_Y)
                {
                    linestring = linestring + "X";
                }
                else
                {
                    linestring = linestring+map[x,y];
                }
            }
            Console.Error.WriteLine(linestring);
        }
        Console.Error.WriteLine(currpos_X + " " + currpos_Y);
        
        for(int i = 0; i < thirdInitInput - 1; i++)
        {
            map[maybeCoords[i].x,maybeCoords[i].y] = maybeCoords[i].before;
        }
    }
    
    static void Stepper()
    {

        ClearConsole();

        if(map[currpos_X,currpos_Y-1] != 'o')
            map[currpos_X,currpos_Y-1]=(char)firstInput[0];
        if(map[currpos_X,currpos_Y+1]!='o')
            map[currpos_X,currpos_Y+1]=(char)thirdInput[0];
        if(map[currpos_X+1,currpos_Y]!='o')
            map[currpos_X+1,currpos_Y]=(char)secondInput[0];
        if(map[currpos_X-1,currpos_Y]!='o')
            map[currpos_X-1,currpos_Y]=(char)fourthInput[0];
            
        //map[28,12] = '#';
        //map[currpos_X-coordX,currpos_Y+coordY] = '%';
        map[currpos_X,currpos_Y]='o';
        
        print();
        
        if(map[currpos_X,currpos_Y-1]=='_')
        {
            Console.WriteLine("C");
            Stepper();
            Console.WriteLine("D");
            ClearConsole();
        }
        if(map[currpos_X-1,currpos_Y]=='_')
        {
            Console.WriteLine("E");
            Stepper();
            Console.WriteLine("A");
            ClearConsole();
        }
        if(map[currpos_X+1,currpos_Y]=='_')
        {
            Console.WriteLine("A");
            Stepper();
            Console.WriteLine("E");
            ClearConsole();
        }
        if(map[currpos_X,currpos_Y+1]=='_')
        {
            Console.WriteLine("D");
            Stepper();
            Console.WriteLine("C");
            ClearConsole();
        }
    }
    
    static void Main(string[] args)
    {
        firstInitInput = int.Parse(Console.ReadLine());
        secondInitInput = int.Parse(Console.ReadLine());
        thirdInitInput = int.Parse(Console.ReadLine());
        Console.Error.WriteLine(firstInitInput);
        Console.Error.WriteLine(secondInitInput);
        Console.Error.WriteLine(thirdInitInput);
        
        //N_size = 40;
        map = new char[secondInitInput,firstInitInput]; //[x,y]
        maybeCoords = new Coord[thirdInitInput - 1];
        for(int i = 0; i < thirdInitInput - 1; i++)
        {
            maybeCoords[i] = new Coord(0,0);
        }
        
        for(int x = 0;x<secondInitInput;x++)
        {
            for(int y = 0;y<firstInitInput;y++)
            {
                map[x,y]='.';
            }
        }
        map[0,0] = '%';
        
        Stepper();
    }
}