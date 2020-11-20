using System;
using System.Collections.Generic;
using System.Linq;

namespace SantasPresentFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstInput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] secondInput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> boxesWithMaterials = new Stack<int>(firstInput);
            Queue<int> magicValues = new Queue<int>(secondInput);
            Dictionary<string, int> myDictionary = new Dictionary<string, int>();

            
            int doll = 150;
            int dollsCounter = 0;
            int woodenTrain = 250;
            int woodenTrainCounter = 0;
            int teddyBear = 300;
            int teddyBearCounter = 0;
            int bicycle = 400;
            int bicycleCounter = 0;


            while (boxesWithMaterials.Count > 0 && magicValues.Count > 0 )
                
            {
                int currentMaterial = boxesWithMaterials.Peek();
                int currentMagic = magicValues.Peek();

                int totalMagicLevel = currentMaterial * currentMagic;
                int totalSum = currentMaterial + currentMagic;

                if (totalMagicLevel == doll)
                {
                    dollsCounter++;
                    myDictionary.Add("Doll", dollsCounter);
                    boxesWithMaterials.Pop();
                    magicValues.Dequeue();
                }
                else if (totalMagicLevel == woodenTrain)
                {
                    woodenTrainCounter++;
                    myDictionary.Add("Wooden train", woodenTrainCounter);
                    boxesWithMaterials.Pop();
                    magicValues.Dequeue();
                }
                else if (totalMagicLevel == teddyBear)
                {
                    teddyBearCounter++;
                    myDictionary.Add("Teddy bear", teddyBearCounter);
                    boxesWithMaterials.Pop();
                    magicValues.Dequeue();
                }
                else if (totalMagicLevel == bicycle)
                {
                    bicycleCounter++;
                    myDictionary.Add("Bicycle", bicycleCounter);
                    boxesWithMaterials.Pop();
                    magicValues.Dequeue();
                }

                if (totalMagicLevel < 0 )
                {
                    boxesWithMaterials.Pop();
                    magicValues.Dequeue();
                    boxesWithMaterials.Push(totalSum);
                }

                if (totalMagicLevel != doll &&
                    totalMagicLevel != woodenTrain &&
                    totalMagicLevel != teddyBear &&
                    totalMagicLevel != bicycle &&
                    totalMagicLevel > 0)
                {
                    boxesWithMaterials.Pop();
                    magicValues.Dequeue();
                    boxesWithMaterials.Push(currentMaterial + 15);
                }

                if (currentMaterial == 0 || currentMagic == 0)
                {
                    if (currentMaterial == 0)
                    {
                        boxesWithMaterials.Pop();
                        continue;
                    }

                    if (currentMagic == 0)
                    {
                        magicValues.Dequeue();
                        continue;
                    }
                }
                

                //if (dollsCounter + woodenTrainCounter == 2 ||
                //    teddyBearCounter + bicycleCounter == 2)
                //{
                //    break;
                //}
            }
            if (dollsCounter + woodenTrainCounter >= 2 ||
                    teddyBearCounter + bicycleCounter >= 2)
            {
                Console.WriteLine("The presents are crafted! Merry Christmas!");

            }
            else
            {
                Console.WriteLine("No presents this Christmas!");
            }

            if (boxesWithMaterials.Count > 0)
            {
                Console.WriteLine($"Materials left: {string.Join(", ", boxesWithMaterials)}");
            }
            if (magicValues.Count > 0)
            {
                Console.WriteLine($"Magic left: {string.Join(", ", magicValues)}");
            }

            myDictionary = myDictionary
                .OrderBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var item in myDictionary)
            {
                Console.WriteLine($"{item.Key}: {item.Value}".ToString());
            }
        }
    }
}
