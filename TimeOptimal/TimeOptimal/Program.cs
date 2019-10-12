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
            List<Prop> ChooseList = new List<Prop>();
            List<Prop> allPropList = new List<Prop>();
            int targetTime = 119;
            targetTime = int.Parse(Console.ReadLine());
            Prop prop = new Prop(120, 2, Type.Special);
            allPropList.Add(prop);
            prop = new Prop(60, 5,Type.Special);
            allPropList.Add(prop);
            prop = new Prop(5, 5,Type.Special);
            allPropList.Add(prop);
            prop = new Prop(120, 5, Type.Common);
            allPropList.Add(prop);
            prop = new Prop(60, 3, Type.Common);
            allPropList.Add(prop);
            prop = new Prop(5, 8, Type.Common);
            allPropList.Add(prop);

            Console.WriteLine("拥有道具列表：");

            for(int i = 0; i <= allPropList.Count - 1; i++)
            {
                Console.WriteLine("道具时间：" + allPropList[i].time + "      道具数量：" + allPropList[i].count+"      道具类型："+allPropList[i].type);
            }

            Console.WriteLine("目标测试时间：" + targetTime);

            //构建完毕
            //默认已是使用情况的优先级
            //进入匹配时间道具的递归循环

            List<Prop> max1TempList = new List<Prop>(); //60-120大值备选方案
            int max1Time = targetTime;
            List<Prop> max2TempList = new List<Prop>(); //0-60大值备选方案
            int max2Time = targetTime;
            List<Prop> minTempList = new List<Prop>();
 
            for(int i = 0; i<=allPropList.Count - 1; i++)
            {
                if(targetTime > 0)
                {
                    for (int j = 1; j <= allPropList[i].count; j++)
                    {
                        Prop prep = allPropList[i];
                        if (targetTime >= 120)
                        {
                            if (targetTime >= prep.time)
                            {
                                if (prep.count > 0)
                                {
                                    //可以直接使用
                                    ChooseList.Add(prep);                                  
                                    targetTime = targetTime - prep.time;
                                    max1Time = targetTime;
                                    max2Time = targetTime;
                                }
                            }
                        }
                        else
                        {
                           
                            if (targetTime < allPropList[i].time)
                            {
                                //有浪费，记录大于情况，继续循环向小的找方案
                                if (prep.count > 0)
                                {
                                    if (max1Time > 0 && max1Time > 60)
                                    {
                                        if (prep.time > 60)
                                        {
                                            max1TempList.Add(prep); //这一条结束了
                                            max1Time -= prep.time;                                        
                                        }else if(prep.time > 5)
                                        {
                                            max2TempList.Add(prep);
                                            max2Time -= prep.time;
                                        }
                                        else
                                        {
                                            if (max2Time > 0)
                                            {
                                                minTempList.Add(prep);
                                                max2Time -= prep.time;
                                            }
                                        }
                                        
                                    }
                                    else if (max2Time > 0 && max2Time > 5)
                                    {
                                        max2TempList.Add(prep);
                                        max2Time -= prep.time;
                                    }
                                    else
                                    {
                                        if(max2Time > 0)
                                        {
                                            minTempList.Add(prep);
                                            max2Time -= prep.time;
                                        }                                       
                                    }                                                       
                                }
                            }
                            else
                            {
                                if (prep.count > 0)
                                {
                                    if (prep.time > 5 && max2Time > 0)
                                    {
                                        max2TempList.Add(prep);
                                        max2Time -= prep.time;
                                    }
                                }
                            }
                        }

                    }
                }
                
            }

            Console.WriteLine("确定要用的道具：");
            for(int i = 0; i <= ChooseList.Count - 1; i++)
            {
                Console.WriteLine("时间：" + ChooseList[i].time + "      类型：" + ChooseList[i].type);
            }

            Console.WriteLine("剩余时间：" + targetTime);

            Console.WriteLine("备选道具：");
            for(int i=0;i <= max1TempList.Count - 1; i++)
            {
                Console.WriteLine("最大档：" + max1TempList[i].time + "        类型：" + max1TempList[i].type);
            }

            for(int i = 0; i <= max2TempList.Count - 1; i++)
            {
                Console.WriteLine("中间档：" + max2TempList[i].time + "        类型：" + max2TempList[i].type);
            }
            
            for(int i = 0; i <= minTempList.Count - 1; i++)
            {
                Console.WriteLine("最小档：" + minTempList[i].time + "        类型：" + minTempList[i].type);
            }
        }
    }

    enum Type
    {
        Common = 1,
        Special = 2,
    }

    class Prop
    {
        public int time = 5;//单位：分钟
        public int count = 1;//单位：个
        public Type type = Type.Special;

        public Prop(int time,int count, Type type)
        {
            this.time = time;
            this.count = count;
            this.type = type;
        }
    }

   
}
