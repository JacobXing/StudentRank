using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvcAngular;

namespace RankAPI.Dtos
{
    [AngularType]
    public class InputEntry
    {
        public List<string> ColumnNames { get; set; }
        public List<List<string>> Values { get; set; }
    }

    [AngularType]
    public class Inputs
    {
        public InputEntry input1 { get; set; }
    }

    [AngularType]
    public class GlobalParameters
    {
    }

    [AngularType]
    public class AzureMLRankRequest
    {
        public Inputs Inputs { get; set; }
        public GlobalParameters GlobalParameters { get; set; }
    }

    [AngularType]
    public class Value
    {
        public List<string> ColumnNames { get; set; }
        public List<string> ColumnTypes { get; set; }
        public List<List<string>> Values { get; set; }
    }

    [AngularType]
    public class OutputEntry
    {
        public string type { get; set; }
        public Value value { get; set; }
    }

    [AngularType]
    public class Results
    {
        public OutputEntry output1 { get; set; }
    }

    [AngularType]
    public class AzureMLRankResponse
    {
        public Results Results { get; set; }
    }
}
