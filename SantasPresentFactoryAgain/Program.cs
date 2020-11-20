using System;
using System.Linq;
using System.Collections.Generic;

namespace SantasPresentFactoryAgain
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] materials = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] magicValues = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int doll = 150;
            int train = 250;
            int bear = 300;
            int bicycle = 400;

            int dollCounter = 0;
            int trainCounter = 0;
            int bearCounter = 0;
            int bicycleCounter = 0;

            Stack<int> materilasStack = new Stack<int>(materials);
            Queue<int> magicValueQueue = new Queue<int>(magicValues);
            Dictionary<string, int> craftedToys = new Dictionary<string, int>();

            while (materilasStack.Count > 0 && magicValueQueue.Count > 0)
            {
                int currentMaterial = materilasStack.Peek();
                int currentMagic = magicValueQueue.Peek();
                int currentSum = 0;

                if (currentMaterial == 0 && currentMagic == 0)
                {
                    materilasStack.Pop();
                    magicValueQueue.Dequeue();
                    continue;
                }
                else if (currentMaterial == 0)
                {
                    materilasStack.Pop();
                    continue;
                }
                else if (currentMagic == 0)
                {
                    magicValueQueue.Dequeue();
                    continue;
                }

                if (currentMaterial * currentMagic < 0)
                {
                    currentSum = currentMaterial + currentMagic;
                    materilasStack.Pop();
                    magicValueQueue.Dequeue();
                    materilasStack.Push(currentSum);
                    currentSum = 0;
                    continue;
                }

                if (currentMaterial * currentMagic != doll
                    && currentMaterial * currentMagic != train
                    && currentMaterial * currentMagic != bear
                    && currentMaterial * currentMagic != bicycle)
                {
                    magicValueQueue.Dequeue();
                    materilasStack.Pop();
                    materilasStack.Push(currentMaterial + 15);
                    continue;
                }

                if (currentMaterial * currentMagic == doll)
                {
                    dollCounter++;
                    if (craftedToys.ContainsKey("Doll"))
                    {
                        craftedToys["Doll"] += 1;
                        materilasStack.Pop();
                        magicValueQueue.Dequeue();
                    }
                    craftedToys.Add("Doll", 1);
                    materilasStack.Pop();
                    magicValueQueue.Dequeue();
                }
                else if (currentMaterial * currentMagic == train)
                {
                    trainCounter++;
                    if (craftedToys.ContainsKey("Wooden train"))
                    {
                        craftedToys["Wooden train"] += 1;
                        materilasStack.Pop();
                        magicValueQueue.Dequeue();
                    }
                    craftedToys.Add("Wooden train", 1);
                    materilasStack.Pop();
                    magicValueQueue.Dequeue();
                }
                else if (currentMaterial * currentMagic == bear)
                {
                    bearCounter++;
                    if (craftedToys.ContainsKey("Teddy bear"))
                    {
                        craftedToys["Teddy bear"] += 1;
                        materilasStack.Pop();
                        magicValueQueue.Dequeue();
                    }
                    craftedToys.Add("Teddy bear", 1);
                    materilasStack.Pop();
                    magicValueQueue.Dequeue();
                }
                else if (currentMaterial * currentMagic == bicycle)
                {
                    bicycleCounter++;
                    if (craftedToys.ContainsKey("Bicycle"))
                    {
                        craftedToys["Bicycle"] += 1;
                        materilasStack.Pop();
                        magicValueQueue.Dequeue();
                    }
                    craftedToys.Add("Bicycle", 1);
                    materilasStack.Pop();
                    magicValueQueue.Dequeue();
                }
                
            }

            if (dollCounter + trainCounter >= 2
                || bearCounter + bicycleCounter >= 2)
            {
                Console.WriteLine($"The presents are crafted! Merry Christmas!");
            }
            else
            {
                Console.WriteLine($"No presents this Christmas!");
            }

            if (materilasStack.Count > 0)
            {
                Console.WriteLine($"Materials left: {string.Join(", ",materilasStack)}");
            }

            if (magicValueQueue.Count > 0)
            {
                Console.WriteLine($"Magic left: {string.Join(", ", magicValueQueue)}");
            }

            foreach (var toy in craftedToys.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{toy.Key}: {toy.Value}");
            }
        }
    }
}