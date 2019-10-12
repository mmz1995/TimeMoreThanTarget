using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeOptimal
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Prop> allPropList = new List<Prop>();
            int targetTime = 119;
            targetTime = int.Parse(Console.ReadLine());
            Prop prop = new Prop(5, 20);
            allPropList.Add(prop);
            prop = new Prop(60, 5);
            allPropList.Add(prop);
            prop = new Prop(120, 5);
            allPropList.Add(prop);

            Console.WriteLine("拥有道具列表：");

        }
    }

    class Prop
    {
        public int time = 5;//单位：分钟
        public int count = 1;//单位：个

        public Prop(int time,int count)
        {
            this.time = time;
            this.count = count;
        }
    }

   
}
