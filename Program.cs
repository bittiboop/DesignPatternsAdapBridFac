namespace DesignPatternsAdapBridFac;

class Program
{
    static void Main(string[] args)
    {
        IRendererInterface vectorRenderer = new IRendererInterface.VectorRenderer();
        IRendererInterface rasterRenderer = new IRendererInterface.RasterRenderer();

        var circle = new IRendererInterface.Circle(vectorRenderer);
        var square = new IRendererInterface.Square(rasterRenderer);
        
        circle.Draw();
        square.Draw();
        
        Console.WriteLine();
        
        ILegacyPrinter legacyPrinter = new ILegacyPrinter.LegacyPrinter();
        legacyPrinter.Print("Hello World!");
        INewPrinter newPrinter = new INewPrinter.NewPrinter();
        ILegacyPrinter printerAdapter = new ILegacyPrinter.PrinterAdapter(newPrinter);
        printerAdapter.Print("Hello World! I`m a new printer!");
        
        Console.WriteLine();
        
        IRendererInterface.ShapeFactory circleFactory = new IRendererInterface.CircleFactory();
        IRendererInterface.ShapeFactory squareFactory = new IRendererInterface.SquareFactory();
        
        IRendererInterface.Shape factorySquare = squareFactory.Create(vectorRenderer);
        IRendererInterface.Shape factoryCircle = circleFactory.Create(rasterRenderer);
        
        factorySquare.Draw();
        factoryCircle.Draw();
    }
}