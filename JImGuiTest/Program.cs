using System;

namespace JImGui
{
    class Program
    {
        static void Main(string[] args)
        {
            App app = new App();
            app.Init();
            app.Run();
            //TODO: shutdown app
        }
    }
}