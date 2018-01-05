﻿// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System;
using OpenTK.Graphics;

namespace osu.Framework.Testing.Drawables.Steps
{
    public class RepeatStepButton : StepButton
    {
        private readonly int count;
        private int invocations;

        public override int RequiredRepetitions => count;

        private string text;

        public new string Text
        {
            get { return text; }
            set { base.Text = text = value; }
        }

        public RepeatStepButton(Action action, int count = 1)
        {
            this.count = count;
            Action = action;

            updateText();

            BackgroundColour = Color4.Sienna;
        }

        public override bool PerformStep(bool userTriggered = false)
        {
            if (invocations == count && !userTriggered) return false;

            invocations++;

            if (invocations >= count) // Allows for manual execution
                Success();

            updateText();

            return base.PerformStep(userTriggered);
        }

        public void ResetInvocations()
        {
            invocations = 0;
            updateText();
        }

        private void updateText() => base.Text = $@"{Text} {invocations}/{count}";

        public override string ToString() => "Repeat: " + base.ToString();
    }
}
