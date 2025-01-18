namespace DesignPatternsAdapBridFac;

public interface ILegacyPrinter
{
    void Print(string text);
    class LegacyPrinter : ILegacyPrinter
    {
        public void Print(string text)
        {
            Console.WriteLine($"Printing by LegacyPrinter: {text}");
        }
    } 
    class PrinterAdapter : ILegacyPrinter
    {
        private readonly INewPrinter newPrinter;
        public PrinterAdapter(INewPrinter newPrinter)
        {
            this.newPrinter = newPrinter;
        }
        public void Print(string text)
        {
            newPrinter.PrintFormatted(text);
        }
    }
    
}