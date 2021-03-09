using System;

namespace Blockchain
{
    class Program
    {
        static void Main(string[] args)
        {
            Chain chain = new Chain(genesisBlockData: "Hello from Ukraine");
            while (true)
            {
                Console.WriteLine(
                    "1.Создать новый блок \n" +
                    "2.Посмотреть количество имеющихся блоков \n" +
                    "3.Посмотреть данные со всех блоков");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Введите данные");
                        string inputData = Console.ReadLine();
                        chain.CreateBlock(inputData);
                        Console.WriteLine($"Блок под ID {chain.Blocks[^1].Id} с данными {inputData} создан");
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine($"Количество блоков в блокчейне: {chain.Blocks.Count}");
                        break;
                    case 3:
                        Console.Clear();
                        foreach (var blocks in chain.Blocks)
                        {
                            Console.WriteLine($"Блок под ID {blocks.Id} с данными {blocks.Data}");
                        }
                        break;
                    default:
                        Console.WriteLine("Неизвесная команда");
                        break;
                }
            }
        }
    }
}
