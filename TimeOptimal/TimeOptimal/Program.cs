using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeOptimal
{
    class Program
    {
        int xRemain5 = 0;
        int xRemain6 = 0;
        static void Main(string[] args)
        {
            List<Prop> ChooseList = new List<Prop>();
            List<Prop> allPropList = new List<Prop>();
            int targetTime = 119;
            targetTime = int.Parse(Console.ReadLine());
            Prop prop = new Prop(120, 2, Type.Special);
            allPropList.Add(prop);
            prop = new Prop(120, 5, Type.Common);
            allPropList.Add(prop);
            prop = new Prop(60, 5,Type.Special);
            allPropList.Add(prop);
            prop = new Prop(60, 3, Type.Common);
            allPropList.Add(prop);
            prop = new Prop(5, 5,Type.Special);
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

            List<Prop> List1 = new List<Prop>();
            List<Prop> List2 = new List<Prop>();
            List<Prop> List4 = new List<Prop>();
            List<Prop> List5 = new List<Prop>();
            List<Prop> List6 = new List<Prop>();

            int Xtime1 = targetTime;
            int Xtime2 = targetTime;
            int Xtime4 = targetTime;
            int Xtime5 = targetTime;
            int Xtime6 = targetTime;

            for (int i = 0; i<=allPropList.Count - 1; i++)
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
                                    //max1Time = targetTime;
                                    //max2Time = targetTime;
                                    Xtime1 = targetTime;
                                    Xtime2 = targetTime;
                                    Xtime4 = targetTime;
                                    Xtime5 = targetTime;
                                    Xtime6 = targetTime;
                                }
                            }
                        }
                        else
                        {

                            /*if (targetTime < allPropList[i].time)
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
                            }*/
                            if (targetTime > 60)
                            {
                                int[] timeArr = TargetIn60To120(prep, Xtime1, Xtime2, Xtime4, Xtime5, Xtime6, List1, List2, List4, List5, List6);
                                Xtime1 = timeArr[0];
                                Xtime2 = timeArr[1];
                                Xtime4 = timeArr[2];
                                Xtime5 = timeArr[3];
                                Xtime6 = timeArr[4];
                            }
                            else
                            {
                                int[] timeArr2 = TargetIn0To60(prep, Xtime5, Xtime6, List5, List6);
                                Xtime5 = timeArr2[0];
                                Xtime6 = timeArr2[1];
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

            Console.WriteLine("备选道具方案：");
            for(int i=0;i <= List1.Count - 1; i++)
            {
                Console.WriteLine("List1：" + List1[i].time + "        类型：" + List1[i].type);
            }

            for (int i = 0; i <=List2.Count - 1; i++)
            {
                Console.WriteLine("List2：" + List2[i].time + "        类型：" + List2[i].type);
            }

            for (int i = 0; i <= List4.Count - 1; i++)
            {
                Console.WriteLine("List4：" + List4[i].time + "        类型：" + List4[i].type);
            }

            for (int i = 0; i <= List5.Count - 1; i++)
            {
                Console.WriteLine("List5：" + List5[i].time + "        类型：" + List5[i].type);
            }

            for (int i = 0; i <= List6.Count - 1; i++)
            {
                Console.WriteLine("List6：" + List6[i].time + "        类型：" + List6[i].type);
            }
        }

        public static int[] TargetIn60To120(Prop curProp,int x1, int x2, int x4, int x5, int x6, List<Prop> list1,List<Prop> list2,List<Prop> list4,List<Prop> list5,List<Prop> list6)
        {
            int[] timeArr5;
            if(curProp.time == 120)
            {
                if(x1 > 0)
                {
                    list1.Add(curProp);//在60-120之间，且120存在时道具模拟完成
                    x1 -= curProp.time;
                }
            }
            else if(curProp.time == 60)
            {
                if (x2 > 0)
                {

                    if (x2 >= 60)
                    {
                        list2.Add(curProp);
                        x2 -= curProp.time;
                        x5 = x2;
                        x6 = x2; 
                    }
                    else
                    {
                        int[] timeArr = TargetIn0To60(curProp, x5, x6, list5, list6);
                        x5 = timeArr[0];
                        x6 = timeArr[1];
                    }
                   
                }
            }
            else if (curProp.time == 5)
            {
                if(x4 > 0)
                {
                    list4.Add(curProp);
                    x4 -= curProp.time;
                }
                if (x6 > 0)
                {
                    int[] timeArr = TargetIn0To60(curProp, x5, x6, list5, list6);
                    x5 = timeArr[0];
                    x6 = timeArr[1];
                }
            }
            timeArr5 = new int[5] { x1, x2, x4, x5, x6 };
            return timeArr5;
        }    
        
        public static int[] TargetIn0To60(Prop curProp, int x5,int x6, List<Prop> list5,List<Prop> list6)
        {
            int[] timeArr;
            if(curProp.time == 60)
            {
                if(x5 > 0)
                {
                    list5.Add(curProp); //模拟完此集合
                    x5 -= curProp.time;
                }
            }
            else if(curProp.time == 5)
            {
                if(x6 > 0)
                {
                    list6.Add(curProp);
                    x6 -= curProp.time;
                }
            }
            timeArr = new int[2] { x5, x6 };
            return timeArr;
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
