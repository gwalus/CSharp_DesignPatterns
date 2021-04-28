using System;

namespace Interface_Segregation_Principle
{
    class Program
    {
        public class Document
        {

        }

        // BAD IDEA
        //public interface IMachine
        //{
        //    void Print(Document d);
        //    void Scan(Document d);
        //    void Fax(Document d);
        //}

        //public class MultiFunctionPrinter : IMachine
        //{
        //    public void Fax(Document d)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public void Print(Document d)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public void Scan(Document d)
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        public interface IPrinter
        {
            public void Print(Document d);
        }

        public interface IScanner
        {
            public void Scan(Document d);
        }

        public interface IMultiFunctionDevice : IPrinter, IScanner
        {

        }

        // BETTER IDEA
        public class PhotoCopier : IPrinter, IScanner
        {
            public void Print(Document d)
            {
                throw new NotImplementedException();
            }

            public void Scan(Document d)
            {
                throw new NotImplementedException();
            }
        }

        public class MultiFunctionMachine : IMultiFunctionDevice
        {
            public void Print(Document d)
            {
                throw new NotImplementedException();
            }

            public void Scan(Document d)
            {
                throw new NotImplementedException();
            }
        }

        static void Main(string[] args)
        {
            
        }
    }
}
