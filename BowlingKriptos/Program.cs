using BowlingGame.Game.Application;
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
                int frame = 1;
                string lineFrame="";
                List<string> jugadores = new List<string>();
                //Read file line by line.  
                foreach (string line in File.ReadLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"bowling-game.txt")))
                {
                    Console.WriteLine(line);
                    if (line.Contains("Jeff"))
                    {

                    }
                    frame++;
                    lineFrame += frame + "\t";
                }
                Console.WriteLine(lineFrame);
                //Console.WriteLine(score1);
                //Console.WriteLine(score2);

                /////////////////////////////////////
                // Suspend the screen.  
                Console.ReadLine();
                //Console.WriteLine("Hello World!");

                /*string fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"bowling-game.txt");

                IEnumerable<string> lines = File.ReadLines(fileName);
                IEnumerable<string> query = lines.Where(name => name.Contains("Jeff"));
                Console.WriteLine(String.Join(Environment.NewLine, lines));*/
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("No se encontró el archivo bowling-game.txt");
            }
            catch (IOException ex)
            {
                Console.WriteLine("Error en el archivo");
            } 

            //Ejecutar la prueba
            /*_serviceGame.Roll(10);
            _serviceGame.Roll(3);
            _serviceGame.Roll(4);
            for (int i = 0; i < 16; i++)
            {
                _serviceGame.Roll(0);
            }*/
            //_serviceGame.Score();
        }
    }
}
