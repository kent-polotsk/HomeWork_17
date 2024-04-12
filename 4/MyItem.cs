using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using JsonIgnoreAttribute = Newtonsoft.Json.JsonIgnoreAttribute;

namespace _4
{
    internal class MyItem
    {
        [JsonProperty("MyAge")]
        public int Age { get; set; }

        [JsonIgnore]
        public string? Name { get; set; }

        public MyItem(int age, string name) 
        {
            Age = age;
            Name = name;
        }
    }
}
