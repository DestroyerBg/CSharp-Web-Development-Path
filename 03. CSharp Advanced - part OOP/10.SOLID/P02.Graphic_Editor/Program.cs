using System.Collections.Generic;

namespace P02.Graphic_Editor
{
    class Program
    {
        static void Main()
        {
            GraphicEditor graphicEditor = new GraphicEditor();
            IShape circle = new Circle();
            IShape rectange = new Rectangle();
            IShape square = new Square();
            var shapes = new List<IShape>()
            {
                circle, rectange, square
            };
            shapes.ForEach(t=>t.DrawMe());
        }
    }
}
