
using UnityEngine;
using System.Collections;
using UIFrame.Base;

namespace demo.script
{


    public class NormalInfoData : IData
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public int Count { get; set; }

        public NormalInfoData(string name, int age, int count)
        {
            Name = name;
            Age = age;
            Count = count;
        }
    }
}

