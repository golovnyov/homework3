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
                .Concat(barcelona2Data.Select(x => new { x.Name, x.Latitude, x.Longitude }));
        }

        [Benchmark]
        public void UnionBarselonas()
        {
            barcelona1Data.Select(x => new { x.Id, x.Name, x.Latitude, x.Longitude })
                .Union(barcelona2Data.Select(x => new { x.Id, x.Name, x.Latitude, x.Longitude }))
                .Select(x => new { x.Name, x.Latitude, x.Longitude });
        }
    }
}
