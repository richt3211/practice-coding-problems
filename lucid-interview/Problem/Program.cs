using System;
using System.Collections.Generic;

namespace Problem
{
    class Part1
    {
        /*
        * Sort a list of people by age ascending.  For person's with
        * the same age, sort ascending alphabetically by name
        *
        * For example:
        *   Person("Bob", 28)
        *   Person("Jill", 31)
        *   Person("Andy", 32)
        *   Person("Sam", 32)
        */

        public class Person
        {
            public int age;
            public string name;
            public Person(string name, int age)
            {
                this.name = name;
                this.age = age;
            }
            
            public override string ToString()
            {
                return "Person(\"" + this.name + "\", " + this.age + ")";	
            }
        }
        
        public static Person[] People =
        {
            new Person("Matt", 50),
            new Person("Lulu", 5),
            new Person("Laura", 49),
            new Person("Abby", 50),
            new Person("Chris", 1),
            new Person("Jen", 35),
            new Person("Flavia", 12),
            new Person("Alicia", 21),
            new Person("Greg", 78),
            new Person("Boris", 9),
        };

        public static void SortData()
        {
            Array.Sort(People, (s1, s2) =>
                {
                    if (s1 != s2)
                        return s1.age.CompareTo(s2.age);
                    else 
                    {
                        // need to come back to this, the compare by name isn't working correctly for some reason
                        return String.Compare(s1.name.ToLower(), s2.name.ToLower());
                    }
                }
            );
        }
    }

    class Part2
    {
        /*
        * Given a string with a comma separated list of sock colors, determine how
        * many pairs of each color sock can be made, output the number of pairs you
        * can make that match
        * for example:
        *     `red,blue,red,green,green,red`
        * would yield the following in the output:
        *     Sock Pairs: 2
        */
        public static int SockPairs(string socks)
        {
            // loop through list using a dictionary to keep track of each color. 
            // sum up all numbers divided by 2 to get answer
            Dictionary<string,int> colors = new Dictionary<string, int>();
            string[] colorsArray = socks.Split(',');
            foreach(string color in colorsArray)
            {
                if (colors.ContainsKey(color)) 
                {
                    colors[color]++;
                }
                else 
                {
                    colors.Add(color, 1);
                }
            }
            int count = 0;
            foreach(KeyValuePair<string,int> pair in colors) 
            {
                count += pair.Value / 2;
            }
            // appears to be working.
            return count;
        }
    }

    class Part3
    {
        /*
	    Part 3: Implement the board game Othello/Reversi on the following board.
	    Alternate black and white turns, and don't allow illegal moves.
		
	    Extra credit: Have one human play against a computer that always makes a
	    legal move.

	    Extra extra credit: Have the computer make at least somewhat strategic moves
	    rather than just some legal move.
	    */
        public class Othello
        {
            enum COLOR { NONE, WHITE, BLACK };
            int size;
            private COLOR[,] spaces;

            private COLOR turn;

            public Othello() : this(8)
            {
            }
            public Othello(int size)
            {
                this.size = size;
                this.spaces = new COLOR[size, size];
                for (int y = 0; y < size; y++)
                {
                    for (int x = 0; x < size; x++)
                    {
                        spaces[x, y] = COLOR.NONE;
                    }
                }
                spaces[3, 4] = COLOR.WHITE;
                spaces[4, 3] = COLOR.WHITE;
                spaces[3, 3] = COLOR.BLACK;
                spaces[4, 4] = COLOR.BLACK;
                this.turn = COLOR.WHITE;
            }
            private string renderSpace(int x, int y)
            {
                switch (spaces[x, y])
                {
                    case COLOR.WHITE:
                        return "W";
                    case COLOR.BLACK:
                        return "B";
                    default:
                        return " ";
                }
            }

            public void render()
            {
                Console.Out.Write(" ");
                for (int i = 0; i < size; i++)
                {
                    Console.Out.Write(" " + (char)(i + 'a'));
                }
                Console.Out.Write("\n");

                for (int y = 0; y < size; y++)
                {
                    Console.Out.Write((y + 1));
                    for (int x = 0; x < size; x++)
                    {
                        Console.Out.Write(" " + renderSpace(x, y));
                    }
                    Console.Out.Write("\n");
                }
            }

            private class Coordinate
            {
                public int x;
                public int y;

                public Coordinate(int x, int y)
                {
                    this.x = x;
                    this.y = y;
                }
            }

            private Coordinate getMoveInput()
            {
                try
                {
                    string text = Console.ReadLine();
                    int x = Math.Max(0, Math.Min(size - 1, text[0] - 'a'));
                    int y = Math.Max(0, Math.Min(size - 1, Int32.Parse(text.Substring(1)) - 1));
                    return new Coordinate(x, y);
                }
                catch
                {
                    return getMoveInput();
                }
            }


            public void play()
            {
                while(true)
                {
                    Console.WriteLine(this.turn.ToString() + " turn");
                    render();
                    Coordinate c = getMoveInput();

                    // to implement turns, keep track of turns in class 
                    COLOR other = this.turn == COLOR.WHITE ? COLOR.BLACK : COLOR.WHITE;

                    //TODO: Fill in this function with the actual game logic.
                    // valid move only the current color crosses out at least one of the other. 

                    // first need to check if there is even a neighbor. 
                    // need to find all of the valid pieces. 
                    // store in data structure, can find direction based on data
                    List<int[]> validOptions = new List<int[]>();
                    // 8 cases ignoring bounds. 
                    // case 1
                    if (spaces[c.x -1, c.y-1 ] == other) 
                    {
                        validOptions.Add(new int[]{-1,-1});
                    }
                    // case 2
                    if (spaces[c.x -1, c.y] == other) 
                    {
                        validOptions.Add(new int[]{-1,0});
                    }
                    // case 3
                    if (spaces[c.x -1, c.y + 1] == other) 
                    {
                        validOptions.Add(new int[]{-1,1});
                    }
                    // case 4
                    if (spaces[c.x + 1, c.y - 1] == other) 
                    {
                        validOptions.Add(new int[]{1,-1});
                    }
                    // case 5
                    if (spaces[c.x + 1, c.y] == other) 
                    {
                        validOptions.Add(new int[]{1,0});
                    }
                    // case 6
                    if (spaces[c.x + 1, c.y + 1] == other) 
                    {
                        validOptions.Add(new int[]{1,1});
                    }
                    // case 7
                    if (spaces[c.x, c.y - 1] == other) 
                    {
                        validOptions.Add(new int[]{0,-1});
                    }
                    // case 8
                    if (spaces[c.x, c.y + 1] == other) 
                    {
                        validOptions.Add(new int[]{0,1});
                    }
                    int count = 1;
                    foreach(int[] option in validOptions)
                    {
                        // dont have a check to see if it ends in current color. 
                        while (spaces[c.x + option[0] * count, c.y + option[1] * count] == other)
                        {
                            count++;
                            // spaces[c.x + option[0], c.y + option[1]] = this.turn;
                        }
                        if (spaces[c.x + option[0] * (count) , c.y + option[1] * (count)] != this.turn)
                        {
                            // invalid move
                            count = 0;
                        }
                        if (count > 0)
                        {
                            spaces[c.x,c.y] = this.turn;
                            for(int i =1; i < count + 1; i++)
                            {
                                spaces[c.x + option[0], c.y + option[1]] = this.turn;
                            }
                        }
                    }
                    if (count == 0) 
                    {
                        Console.WriteLine("Invalid move");
                    }
                    else
                    this.turn = other;
                }
            }
        }
    }

    public class Test
    {
        static void Main(string[] args)
        {
            Console.Out.WriteLine("Part 1:");
            Part1.SortData();
            foreach (Part1.Person person in Part1.People)
            {
                Console.Out.WriteLine(person);
            }
            Console.Out.WriteLine("\n");

            Console.Out.WriteLine("Part 2:");
            Console.Out.WriteLine("Sock Pairs: " + Part2.SockPairs("red,blue,purple,red,green,green,purple,red,yellow,red,red,yellow,red,purple"));
            Console.Out.WriteLine("\n");
            // 6 red 3
            // 1 blue
            // 3 purple 1 
            // 2 green 1 
            // 2 yellow 1
            // 6 total

            Console.Out.WriteLine("Part 3:");
            Part3.Othello b = new Part3.Othello();
            b.play();
        }
    }
}
