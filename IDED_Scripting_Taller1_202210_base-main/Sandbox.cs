using System;
using System.Collections.Generic;
using System.Linq;

namespace TestProject1
{
    internal class Sandbox
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello world");
            Console.WriteLine("Here you can write console prints to test your implementation outside the testing environment");

            Stack<int> sourceStack = new Stack<int>();
            sourceStack.Push(10);
            sourceStack.Push(20);
            sourceStack.Push(3);
            sourceStack.Push(15);
            sourceStack.Push(8);

            Console.WriteLine("sourcestack cantidad" + sourceStack.Count);

            Stack<int> copia1 = new Stack<int>();
            Stack<int> copia2 = new Stack<int>();
            List<int> copia = new List<int>();
            List<int> tenedor = new List<int>(); //tendrá los elementos al compararlos

            Console.WriteLine("copia1 inicial cantidad" + copia1.Count);
            Console.WriteLine("sourcestack después del = " + sourceStack.Count);
            copia = sourceStack.ToList();
            Console.WriteLine("elementos en copia"+copia.Count);
            for (int i = 0; i < copia.Count; i++)
            {
                Console.WriteLine("elemento en copia " + copia[i]);
            }
            Console.WriteLine("sourcestack después del primer ciclo que muestra la lista " + sourceStack.Count);

            while (copia1.Count > 0)
            {
                copia2.Push(copia1.Pop());//tenemos el copia 2 con los elementos del stack invertidos
            }
            Console.WriteLine("sourcestack después del primer ciclo que vacía copia1 " + sourceStack.Count);

            while (copia2.Count > 0)
            {
                copia.Add(copia2.Pop());//ahora tenemos una lista con los elementos del stack original en su orden
            }
            copia1 = sourceStack; //tenemos una copia también de la original en su stack
            Console.WriteLine("sourcestack otra cantidad" + sourceStack.Count);

            Console.WriteLine("copia cantidad" + copia1.Count);

            int numactual = 0;
            int numMayor = 0;
            while (copia1.Count > 0)
            {
                //analizo cuál es el número mayor
                numactual = copia1.Pop();

                if (numactual > numMayor)//comparo si el número actual del stack es mayor o si el mayor sigue siendo mayor
                {
                    numMayor = numactual;
                }
                if (numMayor == numactual)
                {
                    tenedor.Add(-1);
                }
                else
                {
                    tenedor.Add(numMayor);//están en el orden
                }
            }
            copia1.Clear();

            Stack<int> result = new Stack<int>();

            for (int i = 0; i < tenedor.Count; i++)
            {
                copia1.Push(tenedor[i]);
            }
            while (copia1.Count > 0)
            {
                result.Push(copia1.Pop());
            }
            Console.WriteLine("result cantidad" + result.Count); 
            while(result.Count >0)
            {
                Console.WriteLine(result.Pop());
            }

        }
    }
}