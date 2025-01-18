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
            renderer.Render("Circle");
        }
    }
    class Square : Shape
    {
        public Square(IRendererInterface renderer) : base(renderer) { }
        public override void Draw()
        {
            renderer.Render("Square");
        }
    }
    abstract class ShapeFactory
    {
        public abstract Shape Create(IRendererInterface renderer);
    }
    
    class CircleFactory : ShapeFactory
    {
        public override Shape Create(IRendererInterface renderer)
        {
            return new Circle(renderer);
        }
    }
    class SquareFactory : ShapeFactory
    {
        public override Shape Create(IRendererInterface renderer)
        {
            return new Square(renderer);
        }
    }
}