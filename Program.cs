using System;

namespace Паттерн_1
{
    public abstract class Images
    {
        public abstract void CreateColorImages();
        public abstract void CreateSizeImages();
    }
    public class ImagesGrownup : Images
    {
        public ImagesGrownup()
        {
            Console.WriteLine("Создаём изображение перед названием главы");
        }
        public override void CreateColorImages()
        {
            Console.WriteLine("Чёрно-белое");
        }
        public override void CreateSizeImages()
        {
            Console.WriteLine("Размер изображения 5*5 см.");
        }
    }
    public class ImagesChildren : Images
    {
        public ImagesChildren()
        {
            Console.WriteLine("Большая картинка");
        }
        public override void CreateColorImages()
        {
            Console.WriteLine("Разноцветная");
        }
        public override void CreateSizeImages()
        {
            Console.WriteLine("Размер 15*15 см.");
        }
    }
    public abstract class Font
    {
        public abstract void CreateColorFont();
        public abstract void CreateSizefont();
    }
    public class FontGrownup : Font
    {
        public FontGrownup()
        {
            Console.WriteLine("Создаём шрифт для книги с ограничением 18+");
        }
        public override void CreateColorFont()
        {
            Console.WriteLine("Чёрно-белый");
        }
        public override void CreateSizefont()
        {
            Console.WriteLine("Небольшой шрифт");
        }
    }
    public class FontChildren : Font
    {
        public FontChildren()
        {
            Console.WriteLine("Создаём шрифт для книги с ограничением 6+");
        }
        public override void CreateColorFont()
        {
            Console.WriteLine("Цветные");
        }
        public override void CreateSizefont()
        {
            Console.WriteLine("Большие и среднего размера");
        }
    }

    public abstract class Books
    {
        public abstract Images CreateImage();
        public abstract Font CreateFont();
    }
    public class BooksGrownup : Books
    {
        public BooksGrownup()
        {
            Console.WriteLine("Книга с возрастным ограничением 18+");
        }
        public override Images CreateImage()
        {
            return new ImagesGrownup();
        }
        public override Font CreateFont()
        {
            return new FontGrownup();
        }
    }
    public class BooksChildren : Books
    {
        public BooksChildren()
        {
            Console.WriteLine("Книга с возрастным ограничением 6+");
        }
        public override Images CreateImage()
        {
            return new ImagesChildren();
        }
        public override Font CreateFont()
        {
            return new FontChildren();
        }
    }

    public class Controller
    {
        Books Object; 
        public Controller(Books Object)
        {
            this.Object = Object;
        }
        public void Create(string f)
        {
            if (f == "6")
            {
                Images im = Object.CreateImage();
                im.CreateColorImages();
                im.CreateSizeImages();
                Font fn = Object.CreateFont();
                fn.CreateColorFont();
                fn.CreateSizefont();
            }
            if (f == "18")
            {
                Images im = Object.CreateImage();
                im.CreateColorImages();
                im.CreateSizeImages();
                Font fn = Object.CreateFont();
                fn.CreateColorFont();
                fn.CreateSizefont();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Controller BG = new Controller(new BooksGrownup());
            BG.Create("18");
            Console.WriteLine("\n");
            Controller BC = new Controller(new BooksChildren());
            BC.Create("6");
        }
    }
}

