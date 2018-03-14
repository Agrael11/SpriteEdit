using ConsoleGameUtilities;
using System;
using System.Collections.Generic;

namespace SpriteEdit.Scenes
{
    class PaintScene
    {
        List<ConsoleColor> colors = new List<ConsoleColor>()
        {   ConsoleColor.Black, ConsoleColor.Blue, ConsoleColor.Cyan, ConsoleColor.DarkBlue, ConsoleColor.DarkCyan, ConsoleColor.DarkGray,
            ConsoleColor.DarkGreen, ConsoleColor.DarkMagenta, ConsoleColor.DarkRed, ConsoleColor.DarkYellow, ConsoleColor.Gray, ConsoleColor.Green,
            ConsoleColor.Magenta, ConsoleColor.Red, ConsoleColor.White, ConsoleColor.Yellow };

        Sprite sprite;

        private int _ShadeLevelVal;
        private int _ShadeLevel
        {
            get { return _ShadeLevelVal; }
            set
            {
                _ShadeLevelVal = value % 4;
            }
        }

        private int _SelectedColorVal;
        private int _SelectedColor
        {
            get { return _SelectedColorVal; }
            set
            {
                _SelectedColorVal = value;
                while (_SelectedColorVal > 15) _SelectedColorVal -= 17;
                while (_SelectedColorVal < -1) _SelectedColorVal += 17;
            }
        }

        Vector2 cursor = new Vector2(0, 0);

        public void Init(Vector2 size)
        {
            sprite = new Sprite(size);
        }
        public void Init(Sprite sprite)
        {
            this.sprite = sprite;
        }
        public void Update()
        {
            if (Program.App.retresult == 1)
            {
                Program.App.retresult = -1;
                Program.App.SwitchScene(1);
            }
            if (ConsoleKeyboard.KeyAvailable)
            {
                switch (ConsoleKeyboard.PressedKey)
                {
                    case ConsoleKey.C:
                        for (int x = 0; x < sprite.Size.X; x++)
                        {
                            for (int y = 0; y < sprite.Size.Y; y++)
                            {
                                sprite.SetPixel(new Vector2(x, y), new Pixel() { Empty = true });
                            }
                        }
                        break;
                    case ConsoleKey.F:
                        char SShade = ' ';
                        switch (_ShadeLevel)
                        {
                            case 1: SShade = '░'; break;
                            case 2: SShade = '▒'; break;
                            case 3: SShade = '▓'; break;
                        }
                        for (int x = 0; x < sprite.Size.X; x++)
                        {
                            for (int y = 0; y < sprite.Size.Y; y++)
                            {
                                if (_SelectedColor == -1) sprite.SetPixel(new Vector2(x, y), new Pixel() { Empty = true });
                                else sprite.SetPixel(new Vector2(x, y), new Pixel() { Color = colors[_SelectedColor], Character = SShade, CharColor = ConsoleColor.Black });
                            }
                        }
                        break;
                    case ConsoleKey.Add: _SelectedColor++; break;
                    case ConsoleKey.Subtract: _SelectedColor--; break;
                    case ConsoleKey.Multiply: _ShadeLevel++; break;
                    case ConsoleKey.DownArrow:
                        if ((cursor.Y < sprite.Size.Y - 1) && (cursor.Y >= 0))
                            cursor.Y++;
                        break;
                    case ConsoleKey.UpArrow:
                        if ((cursor.Y <= sprite.Size.Y - 1) && (cursor.Y > 0))
                            cursor.Y--;
                        break;
                    case ConsoleKey.LeftArrow:
                        if ((cursor.X <= sprite.Size.X - 1) && (cursor.X > 0))
                            cursor.X--;
                        break;
                    case ConsoleKey.RightArrow:
                        if ((cursor.X < sprite.Size.X - 1) && (cursor.X >= 0))
                            cursor.X++;
                        break;
                    case ConsoleKey.Spacebar:
                        char Shade = ' ';
                        switch (_ShadeLevel)
                        {
                            case 1: Shade = '░'; break;
                            case 2: Shade = '▒'; break;
                            case 3: Shade = '▓'; break;
                        }
                        if (_SelectedColor == -1) sprite.SetPixel(cursor, new Pixel() { Empty = true });
                        else sprite.SetPixel(cursor, new Pixel() { Color = colors[_SelectedColor], Character = Shade, CharColor = ConsoleColor.Black });
                        break;
                    case ConsoleKey.Escape:
                        Program.App.SwitchScene(8);
                        break;
                    case ConsoleKey.S:

                        Program.App.sprite = sprite;
                        Program.App.SwitchScene(3);break;
                }
            }
        }

        public void Draw()
        {
            Renderer.Clean();
            int sizeX = sprite.Size.X;
            if (sizeX > 78) sizeX = 78;
            int sizeY = sprite.Size.Y;
            if (sizeY > 19) sizeY = 19;

            Renderer.DrawRectangle(new Rectangle(0, 0, 80, 25), ConsoleColor.Gray);
            Renderer.DrawRectangle(new Rectangle(1, 1, 78, 19), ConsoleColor.DarkGray);
            Renderer.DrawRectangle(new Rectangle(1, 21, 34, 3), ConsoleColor.DarkGray);
            Renderer.DrawRectangle(new Rectangle(1, 1, sizeX, sizeY), ConsoleColor.DarkMagenta);
            for (int i = 0; i < sizeY; i++)
            {
                Renderer.DrawString("".PadLeft(sizeX, '/'), new Vector2(1, 1 + i), ConsoleColor.Gray);
            }
            Renderer.DrawRectangle(new Rectangle(2, 21, 3, 3), ConsoleColor.Black);
            Renderer.DrawSprite(new Vector2(1, 1), sprite);
            Renderer.DrawString("_", cursor + new Vector2(1, 1), ConsoleColor.White);
            Renderer.DrawString("///", new Vector2(2, 21), ConsoleColor.Gray);
            Renderer.DrawString("///", new Vector2(2, 22), ConsoleColor.Gray);
            Renderer.DrawString("///", new Vector2(2, 23), ConsoleColor.Gray);
            if (_SelectedColor == -1)
            {
                Renderer.DrawString("┌─┐", new Vector2(2, 21), ConsoleColor.Green);
                Renderer.DrawString("│ │", new Vector2(2, 22), ConsoleColor.Green);
                Renderer.DrawString("/", new Vector2(3, 22), ConsoleColor.Gray);
                Renderer.DrawString("└─┘", new Vector2(2, 23), ConsoleColor.Green);
            }
            for (int i = 0; i < 8; i++)
            {
                Renderer.DrawRectangle(new Rectangle(7 + (i * 3), 21, 2, 1), colors[i]);
                if (i == _SelectedColor)
                {
                    Renderer.DrawString("[]", new Vector2(7 + (i * 3), 21), ConsoleColor.Green);
                }
                Renderer.DrawRectangle(new Rectangle(7 + (i * 3), 23, 2, 1), colors[i + 8]);
                if (i == (_SelectedColor - 8))
                {
                    Renderer.DrawString("[]", new Vector2(7 + (i * 3), 23), ConsoleColor.Green);
                }
            }
            if (_SelectedColor >= 0)
            {
                Renderer.DrawRectangle(new Rectangle(31, 21, 3, 3), colors[_SelectedColor]);
                string Shade = "   ";
                switch (_ShadeLevel)
                {
                    case 1: Shade = "░░░"; break;
                    case 2: Shade = "▒▒▒"; break;
                    case 3: Shade = "▓▓▓"; break;
                }
                Renderer.DrawString(Shade, new Vector2(31, 21), ConsoleColor.Black);
                Renderer.DrawString(Shade, new Vector2(31, 22), ConsoleColor.Black);
                Renderer.DrawString(Shade, new Vector2(31, 23), ConsoleColor.Black);
            }
        }
    }
}
