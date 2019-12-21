using System;
using System.Collections.Generic;
using System.Linq;
namespace problem
{
    class Program
    {
        static void Main(string[] args)
        {
// input: [["0","INSERT","abcd"],["1","UNDO"],["2","UNDO"],["3","INSERT","abcd"],["4","DELETE"],["5","DELETE"],["6","UNDO"],["7","UNDO"]]
            string result = Solution(new string[][]{
                new string[]{"0", "INSERT", "abcd"},
                new string[]{"1", "UNDO", },
                new string[]{"2", "UNDO", },
                new string[]{"3", "INSERT", "abcd"},
                new string[]{"4", "DELETE",},
                new string[]{"5", "DELETE",},
                new string[]{"6", "UNDO", },
                new string[]{"7", "UNDO", },
            });
            Console.WriteLine(result);
// input: [["0","INSERT","Hello"],["1","INSERT"," World"],["2","INSERT","!"],["3","UNDO"],["4","UNDO"]]
            result = Solution(new string[][]{
                new string[]{"0", "INSERT", "Hello"},
                new string[]{"1", "INSERT", "World" },
                new string[]{"2", "INSERT", "!"},
                new string[]{"3", "UNDO"},
                new string[]{"4", "UNDO"},
            });
            Console.WriteLine(result);

// input: [["0","INSERT","Hello"],["1","INSERT"," World"],["2","UNDO"],["3","REDO"]]
            result = Solution(new string[][]{
                new string[]{"0", "INSERT", "Hello"},
                new string[]{"1", "INSERT", "World" },
                new string[]{"4", "UNDO"},
                new string[]{"4", "REDO"},
            });
            Console.WriteLine(result);


// input: [["0","INSERT","Hello"],["1","UNDO"],["2","INSERT"," World"],["3","REDO"]]
            result = Solution(new string[][]{
                new string[]{"0", "INSERT", "Hello"},
                new string[]{"1", "UNDO"},
                new string[]{"2", "INSERT", " World"},
                new string[]{"3", "REDO"},
            });
            Console.WriteLine(result);

//input: [["1","SELECT","1","2"],["2","SELECT","1","3"],["0","INSERT","Hello World"],["3","DELETE"]]
            result = Solution(new string[][]{
                new string[]{"1", "SELECT", "1","2"},
                new string[]{"2", "SELECT", "1", "3"},
                new string[]{"0", "INSERT", "Hello World"},
                new string[]{"3", "DELETE"},
            });
            Console.WriteLine(result);
        }

        public static string Solution(string[][] input) 
        {
            string s = "";
            input = input.OrderBy(entry => entry[0]).ToArray();
            Stack<string> stringStack = new Stack<string>();
            Stack<string> undoStack = new Stack<string>();
            int[] select_index = new int[2];
            bool isSelect = false;
            bool isUndo = false;
            foreach (string[] inp in input)
            {
                if (inp[1] == "INSERT")
                {
                    if (isSelect)
                    {
                        string to_remove = s.Substring(select_index[0], select_index[1] - select_index[0]);
                        string[] new_inp = new string[]{inp[0], inp[1], to_remove};
                        s = s.Remove(select_index[0], select_index[1] - select_index[0]);
                        stringStack.Push(s);
                        isSelect = false;
                    }
                    else 
                    {
                        isUndo = false;
                        s += inp[2];
                        stringStack.Push(s);
                    }
                }
                else if (inp[1] == "DELETE")
                {
                    if (isSelect)
                    {
                        string to_remove = s.Substring(select_index[0], select_index[1] - select_index[0]);
                        string[] new_inp = new string[]{inp[0], inp[1], to_remove};
                        s = s.Remove(select_index[0], select_index[1] - select_index[0]);
                        stringStack.Push(s);
                        isSelect = false;
                    }
                    else 
                    {
                        isUndo = false;
                        if (s != "")
                        {   
                            // need to store character removed. 
                            string to_remove = s[s.Length  - 1].ToString();
                            string[] new_inp = new string[]{inp[0], inp[1], to_remove};
                            s = s.Remove(s.Length - 1);
                            stringStack.Push(s);
                        }
                    }
                }
                else if (inp[1] == "UNDO")
                {
                    isUndo = true;
                    if (stringStack.Count !=0)
                    {
                        string undid = stringStack.Pop();
                        string previous;
                        if (stringStack.Count != 0)
                        {
                            previous = stringStack.Peek();
                        }
                        else 
                            previous = "";
                        s = previous;
                        undoStack.Push(undid);
                    }
                }
                else if (inp[1] == "REDO")
                {
                    if (isUndo)
                    {
                        if (undoStack.Count != 0)
                        {
                            string redo = undoStack.Pop();
                            s = redo;
                            stringStack.Push(redo);
                        }
                    }
                    isUndo = true;
                }
                else if (inp[1] == "SELECT")
                {
                    select_index[0] = Int32.Parse(inp[2]);
                    select_index[1] = Int32.Parse(inp[3]);
                    isSelect = true;
                }

            }
            return s;
        }
    }
}
