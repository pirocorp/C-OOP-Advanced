﻿using System.Collections.Generic;

public class SpecialForce : Soldier
{
    private const double OVERALL_SKILL_MULTIPLIER = 3.5;
    private const int SPECIAL_FORCE_REGENERATE_VALUE = 30;

    private readonly List<string> weaponsAllowed = new List<string>
    {
        nameof(Gun),
        nameof(AutomaticMachine),
        nameof(MachineGun),
        nameof(RPG),
        nameof(Helmet),
        nameof(Knife),
        nameof(NightVision),
    };

    public SpecialForce(string name, int age, double experience, double endurance)
        : base(name, age, experience, endurance)
    {
    }

    protected override IReadOnlyList<string> WeaponsAllowed => this.weaponsAllowed;

    public override double OverallSkill => base.OverallSkill * OVERALL_SKILL_MULTIPLIER;

    public override void Regenerate() => this.Endurance += this.Age + SPECIAL_FORCE_REGENERATE_VALUE;
}