﻿// Copyright (c) 2007-2018 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using NUnit.Framework;
using osu.Framework.Allocation;
using osu.Framework.Configuration;
using osu.Game.Rulesets.Mania.Configuration;
using osu.Game.Rulesets.Mania.UI;
using osu.Game.Tests.Visual;

namespace osu.Game.Rulesets.Mania.Tests
{
    [TestFixture]
    public class TestCaseEditor : EditorTestCase
    {
        private readonly Bindable<ManiaScrollingDirection> direction = new Bindable<ManiaScrollingDirection>();

        public TestCaseEditor()
            : base(new ManiaRuleset())
        {
            AddStep("upwards scroll", () => direction.Value = ManiaScrollingDirection.Up);
            AddStep("downwards scroll", () => direction.Value = ManiaScrollingDirection.Down);
        }

        [BackgroundDependencyLoader]
        private void load(RulesetConfigCache configCache)
        {
            var config = (ManiaConfigManager)configCache.GetConfigFor(Ruleset.Value.CreateInstance());
            config.BindWith(ManiaSetting.ScrollDirection, direction);
        }
    }
}
