using ConsoleGameUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpriteEdit.Scenes
{
    class Invalid
    {
        public void Init()
        {

        }

        public void Update()
        {
            if (ConsoleKeyboard.KeyAvailable)
            {
                switch (ConsoleKeyboard.PressedKey)
                {
                    case ConsoleKey.Enter:
                        Program.App.SwitchScene(Program.App.LastScene, false);
                        break;
                }
            }
        }

        public void Draw()
        {
            Renderer.DrawWindow(new Rectangle(30, 9, 20, 7), "FILE NOT VALID", ConsoleColor.Blue, ConsoleColor.Gray, ConsoleColor.White);
            Renderer.DrawButton(new Rectangle(37, 11, 6, 3), "OK", ConsoleColor.Cyan, ConsoleColor.Black);
        }
    }
}
