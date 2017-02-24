using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace rodando_task_sincrono
{
    class Program
    {
        static void Main(string[] args)
        {
            var resposta = ObterString();
            Console.WriteLine(resposta);
            Escreve();
            Console.ReadKey();
        }

        private static Task<string> ObeterStringAsync()
        {
            Console.WriteLine("Passou por aqui.");

            var task = Task.Factory.StartNew(() =>
            {
                Thread.Sleep(3000);
                return "retorno";
            });

            return task;
        }
        private static string ObterString()
        {
            var task = ObeterStringAsync().Result;
            return task;
        }

        private static Task EscreveAsync()
        {
            return Task.Factory.StartNew(() =>
            {
                Thread.Sleep(3000);
                Console.WriteLine("Escreveu");
            });
        }

        private static void Escreve()
        {
            var task = EscreveAsync();
            task.Wait();
        }
    }
}
