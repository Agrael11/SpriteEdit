using ConsoleGameUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpriteEdit.Scenes
{
    class NewScene
    {
        int _SelectedValue = 0;
        int _Selected
        {
            get { return _SelectedValue; }
            set
            {
                _SelectedValue = value;
                while (_SelectedValue < 0) _SelectedValue +=6;
                _SelectedValue %= 6;
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
                    case ConsoleKey.UpArrow: _Selected -= 3; break;
                    case ConsoleKey.DownArrow: _Selected += 3; break;
                    case ConsoleKey.Enter:
                        Program.App.useSprite = false;
                        Vector2 size;
                        switch (_Selected)
                        {
                            case 0: size = new Vector2(4, 4); break;
                            case 1: size = new Vector2(8, 4); break;
                            case 2: size = new Vector2(8, 8); break;
                            case 3: size = new Vector2(16, 8); break;
                            case 4: size = new Vector2(16, 16); break;
                            case 5: size = new Vector2(32, 16); break;
                            default: size = new Vector2(16, 16); break;

                        }
                        Program.App.size = size;
                        Program.App.SwitchScene(2);
                        break;
                    case ConsoleKey.Escape: Program.App.SwitchScene(1);break; ;
                }
            }
        }

        public void Draw()
        {
            Renderer.DrawWindow(new Rectangle(20, 7, 41, 11), "NEW FILE", ConsoleColor.Blue, ConsoleColor.Gray, ConsoleColor.White);
            Renderer.DrawButton(new Rectangle(22, 9, 11, 3), "4x4", (_Selected == 0) ? ConsoleColor.Cyan : ConsoleColor.DarkGray, (_Selected == 0) ? ConsoleColor.Black : ConsoleColor.White);
            Renderer.DrawButton(new Rectangle(35, 9, 11, 3), "8x4", (_Selected == 1) ? ConsoleColor.Cyan : ConsoleColor.DarkGray, (_Selected == 1) ? ConsoleColor.Black : ConsoleColor.White);
            Renderer.DrawButton(new Rectangle(48, 9, 11, 3), "8x8", (_Selected == 2) ? ConsoleColor.Cyan : ConsoleColor.DarkGray, (_Selected == 2) ? ConsoleColor.Black : ConsoleColor.White);
            Renderer.DrawButton(new Rectangle(22, 13, 11, 3), "16x8", (_Selected == 3) ? ConsoleColor.Cyan : ConsoleColor.DarkGray, (_Selected == 3) ? ConsoleColor.Black : ConsoleColor.White);
            Renderer.DrawButton(new Rectangle(35, 13, 11, 3), "16x16", (_Selected == 4) ? ConsoleColor.Cyan : ConsoleColor.DarkGray, (_Selected == 4) ? ConsoleColor.Black : ConsoleColor.White);
            Renderer.DrawButton(new Rectangle(48, 13, 11, 3), "32x16", (_Selected == 5) ? ConsoleColor.Cyan : ConsoleColor.DarkGray, (_Selected == 5) ? ConsoleColor.Black : ConsoleColor.White);
        }
    }
}
