using ConsoleGameUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpriteEdit.Scenes
{
    class ReturnScene
    {
        int _SelectedValue = 0;
        int _Selected
        {
            get { return _SelectedValue; }
            set
            {
                _SelectedValue = value;
                while (_SelectedValue < 0) _SelectedValue +=2;
                _SelectedValue %= 2;
            }
        }
        public void Init()
        {

        }

        public void Update()
        {
            if (ConsoleKeyboard.KeyAvailable)
            {
                switch (ConsoleKeyboard.PressedKey)
                {
                    case ConsoleKey.RightArrow: _Selected++;break;
                    case ConsoleKey.LeftArrow: _Selected--;break;
                    case ConsoleKey.Enter:
                        switch (_Selected)
                        {
                            case 0: Program.App.retresult = 1; break;
                            case 1: Program.App.retresult = 0; break;

                        }
                        Program.App.SwitchScene(2, false);
                        break;
                }
            }
        }

        public void Draw()
        {
            Renderer.DrawWindow(new Rectangle(26, 9, 28, 7), "EXIT NOW?", ConsoleColor.Blue, ConsoleColor.Gray, ConsoleColor.White);
            Renderer.DrawButton(new Rectangle(28, 11, 11, 3), "YES", (_Selected == 0) ? ConsoleColor.Cyan : ConsoleColor.DarkGray, (_Selected == 0) ? ConsoleColor.Black : ConsoleColor.White);
            Renderer.DrawButton(new Rectangle(41, 11, 11, 3), "NO", (_Selected == 1) ? ConsoleColor.Cyan : ConsoleColor.DarkGray, (_Selected == 1) ? ConsoleColor.Black : ConsoleColor.White);
        }
    }
}
