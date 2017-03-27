using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using LitJson;
namespace console
{
    class Program
    {
        public enum TestEnum
        {
            Enum1 = 1,
            Enum2 = 2,
            Enum16 = 16,
        }
        [JsonIgnoreMember("ignoreMember")]
        protected class ToJsonClass
        {
            public int intValue = 0;
            public bool boolValue = false;
            public TestEnum enumValue = TestEnum.Enum1;
            public string stringValue = "string";
            public object[] emptyArray = new object[3] {null, null, new object()};
            public string[] arrayValue = new[] {"1", "2"};
            public TestEnum[] enumArrayValue = new[] {TestEnum.Enum1, TestEnum.Enum16};
            public object nullValue = null;
            public static readonly string readonlyValue = "readonlyValue";
            public Action<string> actionValue = Console.Write;
            [JsonIgnore]
            public string ignoreValue = "ignoreValue";
            public string ignoreMember = "ignoreMember";
            public override bool Equals(object obj)
            {
                return base.Equals(obj);
            }
        }

        protected class EnumClass
        {
            public static readonly string EnumText = @"{""enumValue"":""Enum2""}";
            public TestEnum enumValue = TestEnum.Enum1;
        }
        protected static bool TestToObject(string jsonText)
        {
            var jsonData = JsonMapper.ToObject<JsonData>(jsonText);
            var objData = JsonMapper.ToObject(jsonText);
            return jsonData.ToJson() == jsonText && jsonData.ToJson() == objData.ToJson();
        }

        protected static bool TestToJson(object o)
        {
            string text = JsonMapper.ToJson(o);
            Console.WriteLine(text);
            ToJsonClass toJsonClass = JsonMapper.ToObject<ToJsonClass>(text);
            return o.Equals(toJsonClass);
        }
        static void Main(string[] args)
        {
            string emptyArray = @"{""array"":[]}";
            string arrayWithEmptyObj = @"{""arrayWithEmptyObj"":[{},{},{}]}";
            string emptyObj = @"{}";
            string emptyJsonText = @"{""emptyArray"":[],""arrayWithEmptyObj"":[{},{},{}],""emptyObj"":{}}";
            bool succeed = true;
            try
            {
                //if (!TestToObject(emptyArray))
                //    succeed = false;
                //if (!TestToObject(arrayWithEmptyObj))
                //    succeed = false;
                //if (!TestToObject(emptyObj))
                //    succeed = false;
                //if (!TestToObject(emptyJsonText))
                //    succeed = false;
                var intJsonData = JsonMapper.ToObject<JsonData>(@"5555");
                if (null == intJsonData)
                    succeed = false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                succeed = false;
            }
            if(succeed)
                Console.WriteLine("Console Test Succeed!");
            else
                Console.WriteLine("Console Test Failed!");
            Console.ReadKey();
        }
    }
}
