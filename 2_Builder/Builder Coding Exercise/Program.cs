using System;
using System.Collections.Generic;
using System.Text;

namespace Builder_Coding_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            var cb = new CodeBuilder("Person")
                .AddField("Name", "string")
                .AddField("Age", "int");
            Console.WriteLine(cb);
        }        
    }

    public class CodeBuilder
    {
        private readonly string _rootName;
        ClassDetail root = new ClassDetail();

        public CodeBuilder(string className)
        {
            _rootName = className;
            root.ClassName = className;
        }

        public CodeBuilder AddField(string name, string type)
        {
            root.PropertyNames.Add(name, type);
            return this;
        }

        public override string ToString()
        {
            return root.ToString();
        }
    }

    public class ClassDetail
    {
        private const int indentSize = 3;

        public string ClassName { get; set; }
        public Dictionary<string, string> PropertyNames = new Dictionary<string, string>();

        public ClassDetail()
        {

        }

        public ClassDetail(string className)
        {
            ClassName = className;
        }

        public string ToStringImpl(int indent)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"public class {ClassName}");
            sb.AppendLine("{");

            foreach (var item in PropertyNames)
            {
                sb.Append(new string(' ', indentSize * (indent + 1)));
                sb.AppendLine($"public {item.Value} {item.Key};");
            }

            sb.AppendLine("}");

            return sb.ToString();
        }

        public override string ToString()
        {
            return ToStringImpl(0);
        }
    }
}
