using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpJsonParseSample
{
    class Program
    {
        static readonly string json = @"{
            ""hoges"": [
                {
                    ""aaa"": 10,
                    ""b_b"": ""hello""
                },
                {
                    ""aaa"": 55,
                    ""b_b"": ""world""
                }
            ]
        }";

        static void Main(string[] args)
        {
            ScriptLike();
            StrictLike();
        }

        // スクリプト風 (プロトタイプ向け)
        static void ScriptLike()
        {
            Console.WriteLine("---- script like ----");
            var obj = JsonConvert.DeserializeObject<dynamic>(json);
            Console.WriteLine(obj.hoges[0].aaa);
            Console.WriteLine(obj.hoges[0].b_b);
            Console.WriteLine(obj.hoges[1].aaa);
            Console.WriteLine(obj.hoges[1].b_b);
        }

        // ちゃんと堅く作る場合
        class Element
        {
            // ※デフォルトだとフィールド名が lowerCamelCase <- -> UpperCamelCase 変換になる
            public int Aaa { get; set; }

            // ※デフォルト変換ルールから外れるフィールド名がある場合はアノテーションで対処
            [JsonProperty("b_b")]
            public string B_b { get; set; }
        }
        class ResponseType
        {
            public List<Element> Hoges { get; set; }
        }
        static void StrictLike()
        {
            Console.WriteLine("---- strict like ----");
            var obj = JsonConvert.DeserializeObject<ResponseType>(json);
            Console.WriteLine(obj.Hoges[0].Aaa);
            Console.WriteLine(obj.Hoges[0].B_b);
            Console.WriteLine(obj.Hoges[1].Aaa);
            Console.WriteLine(obj.Hoges[1].B_b);
        }
    }
}
