using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Homework3
{
    public class Program
    {
        private const string Barcelona1FileName = "Data/Barcelona1.csv";
        private const string Barcelona2FileName = "Data/Barcelona2.csv";

        private List<Barcelona1> barcelona1Data;
        private List<Barcelona2> barcelona2Data;

        public Program()
        {
            var basePath = Directory.GetCurrentDirectory();

            barcelona1Data = Parser.GetData<Barcelona1>(Path.Combine(basePath, Barcelona1FileName));

            barcelona2Data = Parser.GetData<Barcelona2>(Path.Combine(basePath, Barcelona2FileName));
        }

        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Program>();

            Console.ReadLine();
        }

        [Benchmark]
        public void UnionAllBarselonas()
        {
            barcelona1Data.Select(x => new { x.Name, x.Latitude, x.Longitude })
              .Concat(barcelona2Data.Select(x => new { x.Name, x.Latitude, x.Longitude }))
              .Count();
        }

        [Benchmark]
        public void UnionBarselonas()
        {
            UnionIterator()
                .Count();
        }

        private IEnumerable<object> UnionIterator()
        {
            var dictionary = new Dictionary<int, object>();

            foreach (var b1 in barcelona1Data)
            {
                dictionary.Add(b1.Id, new { b1.Id, b1.Name, b1.Latitude, b1.Longitude });

                yield return new { b1.Name, b1.Latitude, b1.Longitude };
            }

            foreach (var b2 in barcelona2Data)
            {
                if (!dictionary.ContainsKey(b2.Id))
                {
                    dictionary.Add(b2.Id, new { b2.Id, b2.Name, b2.Latitude, b2.Longitude });

                    yield return new { b2.Name, b2.Latitude, b2.Longitude };
                }
            }
        }
    }
}
