namespace DesignPatternsAdapBridFac;

class Program
{
    static void Main(string[] args)
    {
        IRendererInterface vectorRenderer = new IRendererInterface.VectorRenderer();
        IRendererInterface rasterRenderer = new IRendererInterface.RasterRenderer();
        
        IRendererInterface.Shape circle = new IRendererInterface.Circle(vectorRenderer);
        IRendererInterface.Shape square = new IRendererInterface.Square(rasterRenderer);
        
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
        
        IRendererInterface.Shape factorySquare = squareFactory.Create();
        IRendererInterface.Shape factoryCircle = circleFactory.Create();
        
        factorySquare.Draw();
        factoryCircle.Draw();
    }
}