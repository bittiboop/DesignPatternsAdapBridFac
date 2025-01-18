namespace DesignPatternsAdapBridFac;

public interface INewPrinter
{
    void PrintFormatted(string text);

    class NewPrinter : INewPrinter
    {
        public void PrintFormatted(string text)
        {
            Console.WriteLine($"Printing by NewPrinter: {text}");
        }
    }
}