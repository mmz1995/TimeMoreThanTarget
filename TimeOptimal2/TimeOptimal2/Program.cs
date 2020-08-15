using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeOptimal2
{
    class Program
    {
        static void Main(string[] args)
        {
            Array propArray = CreateNodeGragh();
        }

        static Array CreateNodeGragh()
        {
            Array propArray = new Array[9];

            propArray.SetValue(new PropNode(1, 120, 3, "Super120"), 0);
            propArray.SetValue(new PropNode(2, 60, 2, "Super60"), 1);
            propArray.SetValue(new PropNode(3, 5, 6, "Super5"), 2);
            propArray.SetValue(new PropNode(4, 120, 1, "Special120"), 3);
            propArray.SetValue(new PropNode(5, 60, 3, "Special60"), 4);
            propArray.SetValue(new PropNode(6, 5, 10, "Special5"), 5);
            propArray.SetValue(new PropNode(7, 120, 3, "Common120"), 6);
            propArray.SetValue(new PropNode(8, 60, 8, "Common60"), 7);
            propArray.SetValue(new PropNode(9, 5, 15, "Common5"), 8);

            return propArray;
        }
    }

    class SelectBeniftProps
    {

    }

    //构建道具节点
    //每一个道具都抽象成一个节点，节点的值代表道具的价值（道具的作用时长）
    //节点的权重代表被使用的优先级，权重越低，越先被使用
    //节点对象里构建出来的其他必备属性
    class PropNode
    {
        public int wight = 0;
        public int value = 0;
        public int count = 0;
        public string id = "";
        public PropNode(int _wight,int _value,int _count,string _id)
        {
            wight = _wight;
            value = _value;
            count = _count;
            id = _id;
        }
    }
}
