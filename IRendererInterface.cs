namespace DesignPatternsAdapBridFac;

public interface IRendererInterface
{
    void Render(string shape);
    
    class VectorRenderer : IRendererInterface
    {
        public void Render(string shape)
        {
            Console.WriteLine($"Drawing a vector of {shape} units");
        }
    }

    class RasterRenderer : IRendererInterface
    {
        public void Render(string shape)
        {
            Console.WriteLine($"Drawing a raster of {shape} units");
        }
    }

    abstract class Shape
    {
        protected IRendererInterface renderer;
        protected Shape(IRendererInterface renderer)
        {
            this.renderer = renderer;
        }

        public abstract void Draw();
    }

    class Circle : Shape
    {
        public Circle (IRendererInterface renderer) : base(renderer) { }
        public override void Draw()
        {
            renderer.Render("circle");
        }
    }
    class Square : Shape
    {
        public Square(IRendererInterface renderer) : base(renderer) { }
        public override void Draw()
        {
            renderer.Render("square");
        }
    }
    abstract class ShapeFactory
    {
        public abstract Shape Create();
    }
    
    class CircleFactory : ShapeFactory
    {
        public override Shape Create()
        {
            return new Circle(new VectorRenderer());
        }
    }
    class SquareFactory : ShapeFactory
    {
        public override Shape Create()
        {
            return new Square(new RasterRenderer());
        }
    }
}