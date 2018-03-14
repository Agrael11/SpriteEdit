using ConsoleGameUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpriteEdit.Scenes
{
    class MenuScene
    {
        Sprite spr1;
        Sprite spr2;

        int _SelectedValue = 0;
        int _Selected
        {
            get { return _SelectedValue; }
            set
            {
                _SelectedValue = value;
                while (_SelectedValue < 0) _SelectedValue +=3;
                _SelectedValue %= 3;
            }
        }
        public void Init()
        {
            spr1 = Sprite.Load("Sprites\\TP1.SPR");
            spr2 = Sprite.Load("Sprites\\TP2.SPR");
        }

        public void Update()
        {
            if (ConsoleKeyboard.KeyAvailable)
            {
                switch (ConsoleKeyboard.PressedKey)
                {
                    case ConsoleKey.DownArrow: _Selected++;break;
                    case ConsoleKey.UpArrow: _Selected--;break;
                    case ConsoleKey.Enter: switch (_Selected)
                        {
                            case 0: Program.App.SwitchScene(5); break;
                            case 1: Program.App.SwitchScene(4);break;
                            case 2: Program.Running = false;break;
                        }break;
                }
            }
        }

        public void Draw()
        {
            Renderer.Clean();
            Renderer.DrawSprite(new Vector2(25, 0), spr1);
            Renderer.DrawSprite(new Vector2(41, 0), spr2);
            Renderer.DrawWindow(new Rectangle(25, 9, 30, 15), "MAIN MENU", ConsoleColor.Blue, ConsoleColor.Gray, ConsoleColor.White);
            Renderer.DrawButton(new Rectangle(34, 11, 12, 3), "NEW FILE",  (_Selected == 0) ? ConsoleColor.Cyan : ConsoleColor.DarkGray, (_Selected == 0) ? ConsoleColor.Black : ConsoleColor.White);
            Renderer.DrawButton(new Rectangle(34, 15, 12, 3), "LOAD FILE", (_Selected == 1) ? ConsoleColor.Cyan : ConsoleColor.DarkGray, (_Selected == 1) ? ConsoleColor.Black : ConsoleColor.White);
            Renderer.DrawButton(new Rectangle(34, 19, 12, 3), "EXIT", (_Selected == 2) ? ConsoleColor.Cyan : ConsoleColor.DarkGray, (_Selected == 2) ? ConsoleColor.Black : ConsoleColor.White);
            Renderer.DrawString("TachiPaint 1.0", new Vector2(0, 23), ConsoleColor.Gray);
            Renderer.DrawString("by Tachi23 (C)2016", new Vector2(0, 24), ConsoleColor.Gray);
            string[] TT = Renderer.GetVerInfo().Split('\n');
            for (int i = 0; i < TT.Length; i++)
            {
                Renderer.DrawString(TT[i], new Vector2(80-TT[i].Length, 25-TT.Length+i), ConsoleColor.Gray);
            }
        }
    }
}
