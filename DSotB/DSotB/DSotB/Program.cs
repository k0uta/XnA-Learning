using System;

namespace DSotB
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (DSotB game = new DSotB())
            {
                game.Run();
            }
        }
    }
#endif
}

