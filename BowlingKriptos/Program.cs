using BowlingGame.Game.Application;
using BowlingKriptos.Dto;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BowlingKriptos
{
    public class Program
    {
        static void Main(string[] args)
        {
            //inject dependency
            var services = new ServiceCollection()
                .AddTransient<IApplicationGameService, ApplicationGameService>()
                .BuildServiceProvider();
            var _serviceGame = services.GetService<IApplicationGameService>();

            try
            {
                //Read file
                string fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"bowling-game.txt");
                IEnumerable<string> lines = File.ReadLines(fileName);
                //Map Rolls
                List<Player> keyValue = new List<Player>();
                keyValue = lines.Select(x => x.Split(" ")).Select(y => new Player { Name = y[0], Score = y[1] }).ToList();
                //Get amount and name player
                IEnumerable<string> namePlayers = keyValue.Select(y => y.Name).Distinct();
                //Play for each player
                int countIterator = 0;
                foreach (string name in namePlayers)
                {
                    int currentRoll = 0;
                    foreach (Player player in keyValue)
                    {
                        //Send to count
                        if (player.Name == name)
                        {
                            _serviceGame.Roll(player.Score == "F" ? 0 : Convert.ToInt32(player.Score), currentRoll);
                            currentRoll += 1;
                        }
                    }
                    //Get result
                    var consol = _serviceGame.Score();
                    //Print to console
                    if(countIterator == 0)
                        Console.WriteLine("Frame\t\t" + consol.Frame);
                    Console.WriteLine(name);
                    Console.WriteLine("Pinfalls\t" + consol.Pinfalls);
                    Console.WriteLine("Score\t\t" + consol.Score);
                    //sum countIterator
                    countIterator++;
                }
                Console.ReadLine();
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("No se encontró el archivo bowling-game.txt");
            }
            catch (IOException ex)
            {
                Console.WriteLine("Error en el archivo");
            } 
        }
    }
}
