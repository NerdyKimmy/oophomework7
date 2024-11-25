using System;
namespace Decorator.Examples
{
    class MainApp
    {
        static void Main()
        {
            // Create ConcreteComponent and two Decorators
            ChristmasTree christmasTree = new ChristmasTree();
            OrnamentDecorator ornaments = new OrnamentDecorator();
            GarlandDecorator garland = new GarlandDecorator();

            // Link decorators
            ornaments.SetTree(christmasTree);
            garland.SetTree(ornaments);

            garland.Display();

            // Wait for user
            Console.Read();
        }
    }
    // "Component"
    abstract class Tree
    {
        public abstract void Display();
    }

    // "ConcreteComponent"
    class ChristmasTree : Tree
    {
        public override void Display()
        {   
            Console.WriteLine("Christmas Tree");
        }
    }
    // "Decorator"
    abstract class TreeDecorator : Tree
    {
        protected Tree tree;  

        public void SetTree(Tree tree)
        {
            this.tree = tree;
        }
        public override void Display()
        {
            if (tree != null)
            {
                tree.Display();
            }
        }
    }

    // "ConcreteDecoratorA"
    class OrnamentDecorator : TreeDecorator
    {
        private string ornaments;

        public override void Display()
        {
            base.Display();
            ornaments = "Ornaments";
            Console.WriteLine("Decorated with " + ornaments);
        }
    }

    // "ConcreteDecoratorB" 
    class GarlandDecorator : TreeDecorator
    {
        public override void Display()
        {
            base.Display();
            AddGarland();
        }
        void AddGarland()
        {
            Console.WriteLine("Garland lights are shining");
        }
    }
}