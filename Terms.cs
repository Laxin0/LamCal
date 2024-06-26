using System.Runtime.CompilerServices;

namespace LamCal
{

    public interface Term{}
    public struct Variable : Term
    {
        public string Name {set; get;}
        public Variable(string name){
            Name = name;
        }
        public override string ToString() => Name;
    }
    public struct Application : Term
    {
        public Term Func {init; get;}
        public Term Arg {init; get;}
        public Application(Term func, Term arg){
            Func = func;
            Arg = arg;
        }
        public override string ToString() => $"({Func} {Arg})";
    }
    public struct Abstraction : Term
    {
        public string ArgName {init; get;}
        public Term Body {set; get;}
        public Abstraction(string argName, Term body)
        {
            ArgName = argName;
            Body = body;
        }
        public override string ToString() => $"(\\{ArgName}.{Body})";
    }
}