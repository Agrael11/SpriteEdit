using ConsoleGameUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpriteEdit
{
    public class App
    {
        public static Random random;
        public int Scene = -1;
        public int LastScene = 0;
        public int result = -1; public int retresult = -1;

        Scenes.IntroLogo logoScene = new Scenes.IntroLogo();
        Scenes.MenuScene mainMenu = new Scenes.MenuScene();
        Scenes.PaintScene paintScene = new Scenes.PaintScene();
        Scenes.SaveScene saveScene = new Scenes.SaveScene();
        Scenes.LoadScene loadScene = new Scenes.LoadScene();
        Scenes.NewScene newScene = new Scenes.NewScene();
        Scenes.Invalid invalidScene = new Scenes.Invalid();
        Scenes.OverScene overwriteScene = new Scenes.OverScene();
        Scenes.ReturnScene returnScene = new Scenes.ReturnScene();

        public bool useSprite = false;
        public Vector2 size;
        public Sprite sprite;

        public void SwitchScene(int scn, bool reinit = true)
        {
            Scene = scn;
            if (reinit)
            {
                switch (scn)
                {
                    case 0: logoScene.Init(); PlayMusic(); break;
                    case 1: mainMenu.Init(); break;
                    case 2:
                        if (useSprite) paintScene.Init(sprite);
                        else paintScene.Init(size);
                        break;
                    case 3: saveScene.Init(); break;
                    case 4: loadScene.Init(); break;
                    case 5: newScene.Init(); break;
                    case 6: invalidScene.Init();break;
                    case 7: overwriteScene.Init(); break;
                    case 8: returnScene.Init(); break;
                }
            }
        }

        public void Init()
        {
            SwitchScene(0);
        }

        public void Update()
        {
            switch (Scene)
            {
                case 0: logoScene.Update(); break;
                case 1: mainMenu.Update(); break;
                case 2: paintScene.Update(); break;
                case 3: saveScene.Update(); break;
                case 4: loadScene.Update(); break;
                case 5: newScene.Update(); break;
                case 6: invalidScene.Update(); break;
                case 7: overwriteScene.Update(); break;
                case 8: returnScene.Update(); break;
            }
        }

        public void Draw()
        {
            Renderer.DrawBegin();
            switch (Scene)
            {
                case 0: logoScene.Draw(); break;
                case 1: mainMenu.Draw(); break;
                case 2: paintScene.Draw(); break;
                case 3: paintScene.Draw(); saveScene.Draw(); break;
                case 4: mainMenu.Draw(); loadScene.Draw(); break;
                case 5: mainMenu.Draw(); newScene.Draw(); break;
                case 6:
                    switch (LastScene)
                    {
                        case 3: paintScene.Draw(); saveScene.Draw(); break;
                        case 4: mainMenu.Draw(); loadScene.Draw(); break;
                    }
                    invalidScene.Draw(); break;
                case 7: paintScene.Draw(); saveScene.Draw(); overwriteScene.Draw(); break;
                case 8: paintScene.Draw(); returnScene.Draw(); break;

            }
            Renderer.DrawEnd();
        }

        public void PlayMusic()
        {
            if (Scene == 0)
            {
                logoScene.PlayMusic();
            }
        }
    }
}
