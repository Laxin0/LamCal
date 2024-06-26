namespace LamCal
{
    public class Tokenizer
    {
        public List<Token> GetTokens(string src)
        {
            var tokens = new List<Token>();

            for (int i = 0; i < src.Length; i++)
            {
                switch(src[i])
                {
                    case '(': tokens.Add(new Token(TokenType.OPEN_PARENT));
                    break;
                    case ')':tokens.Add(new Token(TokenType.CLOSE_PARENT));
                    break;
                    case '\\':tokens.Add(new Token(TokenType.LAMBDA));
                    break;
                    case '.':tokens.Add(new Token(TokenType.DOT));
                    break;
                    case char x when char.IsAsciiLetter(x):
                    {
                        string buf = ""+x;
                        while (i+1 < src.Length && char.IsAsciiLetter(src[i+1]))
                        {
                            buf += src[++i];
                        }
                        tokens.Add(new Token(TokenType.WORD, buf));
                    }
                    break;
                    case char x when char.IsWhiteSpace(x):
                    break;
                    default:
                        Console.WriteLine($"Invalid symbol in program: `{src[i]}`");
                    break;
                }
            }
            return tokens;            
        }
    }
    public struct Token
    {
        public Token(TokenType type, string val)
        {
            Type = type;
            Value = val;
        }
        public Token(TokenType type)
        {
            Type = type;
            Value = null;
        }
        public TokenType Type { get; init; }
        public string? Value { get; init; }
        public override string ToString() => $"Token: Type={Type}, Val={Value}";
    }
    public enum TokenType
    {
        WORD,
        LAMBDA,
        DOT,
        OPEN_PARENT,
        CLOSE_PARENT
    }
}