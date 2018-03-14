using ConsoleGameUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpriteEdit
{
    class Program
    {
        public static App App;
        public static bool Running = true;

        private static Thread _keyThread;
        private static Thread _render;

        private static void Main(string[] args)
        {
            Renderer.Init();
            Renderer.WindowSize = new Vector2(80, 25);
            NotePlayer.Init();
            App = new App();
            App.Init();
            _keyThread = new Thread(ConsoleKeyboard.CheckKey);
            _render = new Thread(RenderDraw);
            _keyThread.Start();
            _render.Start();
            while (Running)
            {
                Thread.Sleep(33);
                App.Update();
                App.Draw();
            }
            NotePlayer.Stop = true;
            _keyThread.Abort();
            _render.Abort();
        }

        private static void RenderDraw()
        {
            while (Running)
            {
                Renderer.Draw();
            }
        }
    }
}   
