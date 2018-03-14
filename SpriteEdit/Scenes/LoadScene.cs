using ConsoleGameUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpriteEdit.Scenes
{
    class LoadScene
    {
        int _SelectedValue = 0;
        int cursor = 0;
        string Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        int _Selected
        {
            get { return _SelectedValue; }
            set
            {
                _SelectedValue = value;
                while (_SelectedValue < 0) _SelectedValue += 6;
                _SelectedValue %= 6;
            }
        }
        public void Init()
        {
            cursor = Text.Length;
        }

        public void Update()
        {
            string TxtP1;
            string TxtP2;
            if (ConsoleKeyboard.KeyAvailable)
            {
                bool wrt = false;
                switch (ConsoleKeyboard.PressedKey)
                {
                    case ConsoleKey.RightArrow:
                        if (cursor < Text.Length) cursor++;
                        break;
                    case ConsoleKey.LeftArrow:
                        if (cursor > 0) cursor--;
                        break;
                    case ConsoleKey.Backspace:
                        if (Text.Length > 0)
                        {
                            TxtP1 = Text.Substring(0, cursor);
                            TxtP2 = Text.Substring(cursor);
                            if (TxtP1.Length > 0)
                            {
                                TxtP1 = TxtP1.Substring(0, TxtP1.Length - 1);
                                cursor--;
                                Text = TxtP1 + TxtP2;
                            }
                        }
                        break;
                    case ConsoleKey.Delete:
                        if (Text.Length > 0)
                        {
                            TxtP1 = Text.Substring(0, cursor);
                            TxtP2 = Text.Substring(cursor);
                            if (TxtP2.Length > 0)
                            {
                                TxtP2 = TxtP2.Substring(1);
                                Text = TxtP1 + TxtP2;
                            }
                        }
                        break;
                    case ConsoleKey.Spacebar:
                        TxtP1 = Text.Substring(0, cursor);
                        TxtP2 = Text.Substring(cursor);
                        Text = TxtP1 + " " + TxtP2;
                        cursor++;
                        break;
                    case ConsoleKey.Home: cursor = 0; break;
                    case ConsoleKey.End: cursor = Text.Length; break;
                    case ConsoleKey.Enter:
                        bool ok = Sprite.TryLoad(Text);
                        if (ok)
                        { 
                            Program.App.sprite = Sprite.Load(Text);
                            Program.App.useSprite = true;
                            Program.App.SwitchScene(2); break; }
                        else
                            Program.App.LastScene = 4;
                            Program.App.SwitchScene(6); break;
                    case ConsoleKey.Escape: Program.App.SwitchScene(1); break;
                    default: wrt = true; break;
                }
                if (wrt)
                {
                    string key = ConsoleKeyboard.PressedKey.ToString();
                    if (key.StartsWith("NumPad")) key = key.Replace("NumPad","");
                    switch (key)
                    {
                        case "OemPeriod": key = "."; break;
                        case "OemComma": key = ","; break;
                        case "Divide": key = "/"; break;
                        case "Oem5": key = "\\"; break;
                    }
                    TxtP1 = Text.Substring(0, cursor);
                    TxtP2 = Text.Substring(cursor);
                    if (key.Length == 1)
                    {
                        Text = TxtP1 + key + TxtP2;
                        cursor++;
                    }
                }
            }
        }

        public void Draw()
        {
            Renderer.DrawWindow(new Rectangle(20, 7, 41, 11), "LOAD FILE", ConsoleColor.Blue, ConsoleColor.Gray, ConsoleColor.White);
            Renderer.DrawString("Select File", new Vector2(35,9), ConsoleColor.Black);
            Renderer.DrawRectangle(new Rectangle(22, 11, 37, 1), ConsoleColor.Black);
            string TxtP1 = Text.Substring(0, cursor);
            string TxtP2 = Text.Substring(cursor);
            Renderer.DrawString(TxtP1, new Vector2(22, 11), ConsoleColor.White);
            Renderer.DrawString("_", new Vector2(22+cursor, 11), ConsoleColor.White);
            Renderer.DrawString(TxtP2, new Vector2(23+cursor, 11), ConsoleColor.White);
            Renderer.DrawButton(new Rectangle(36, 13, 10, 3), "LOAD", ConsoleColor.Cyan, ConsoleColor.Black);
        }
    }
}
