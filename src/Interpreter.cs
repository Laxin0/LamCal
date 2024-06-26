namespace LamCal
{
    public class Interpreter
    {
        // TODO: passing terms by ref
        public Term Evaluate(Term term)
        {
            if (term is Variable) return term;
            if (term is Abstraction abs)
            {
                return new Abstraction(abs.ArgName, Evaluate(abs.Body)) ;
            }
            var appl = (Application) term;
            return Apply(Evaluate(appl.Func), Evaluate(appl.Arg));
        }

        public Term Apply(Term func, Term arg)
        {
            if (func is Variable && arg is Variable) return new Application(func, arg);
            if (func is Abstraction abs){
                var t = Substitute(abs.Body, abs.ArgName, arg);
                return Evaluate(t);
            }
            return new Application(func, arg);
        }
        public Term Substitute(Term term, string varName, Term newVal)
        {
            if (term is Variable v)
            {
                if (v.Name == varName) return newVal;
                else return term;
            } 
            if (term is Abstraction abs) return new Abstraction(abs.ArgName, Substitute(abs.Body, varName, newVal));
            var appl = (Application) term;
            return new Application(Substitute(appl.Func, varName, newVal), Substitute(appl.Arg, varName, newVal));
        }
    }
}