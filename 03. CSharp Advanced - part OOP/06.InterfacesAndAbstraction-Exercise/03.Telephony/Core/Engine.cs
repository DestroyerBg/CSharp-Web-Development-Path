using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _03.Telephony.IO;
using _03.Telephony.IO.Interfaces;
using _03.Telephony.Models;

namespace _03.Telephony.Core
{
    public class Engine : IEngine
    {
        public void Run()
        {
            IReader reader = new Reader();
            string[] numbersList = reader.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            string[] urlList = reader.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            ICaller phone = new Stationary();
            IBrowser smartphone = new Smartphone();
            for (int i = 0; i < numbersList.Length; i++)
            {
                phone.Call(numbersList[i]);
            }
            for (int i = 0; i < urlList.Length; i++)
            {
                smartphone.Browse(urlList[i]);
            }

        }
    }
}
