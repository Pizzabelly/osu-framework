﻿// Copyright (c) 2007-2018 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.Collections.Generic;
using osu.Framework.Input;
using osu.Framework.Input.Handlers;
using osu.Framework.iOS.Input;
using osu.Framework.Platform.Windows;
using osu.Framework.Platform;
using osuTK;

namespace osu.Framework.iOS
{
    public class iOSGameHost : GameHost
    {
        private readonly iOSGameView gameView;

        public iOSGameHost(iOSGameView gameView)
        {
            this.gameView = gameView;
            iOSGameWindow.GameView = gameView;
            Window = new iOSGameWindow();
        }

        public override ITextInputSource GetTextInput() => new iOSTextInput(gameView);

        protected override IEnumerable<InputHandler> CreateAvailableInputHandlers()
        {
            return new InputHandler[] { new iOSTouchHandler(gameView), new iOSKeyboardHandler(gameView) };
        }

        protected override Storage GetStorage(string baseName) => new WindowsStorage(baseName, this);

        public override void OpenFileExternally(string filename) => new System.NotImplementedException();

        public override void OpenUrlExternally(string url) => throw new System.NotImplementedException();
    }
}
