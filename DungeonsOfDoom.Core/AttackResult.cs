﻿using System;
using DungeonsOfDoom.Core.Characters;

namespace DungeonsOfDoom.Core
{
    public class AttackResult
    {
        public AttackResult(Character attacker, Character opponent, int damage)
        {
            Attacker = attacker;
            Opponent = opponent;
            Damage = damage;
        }
        public Character Attacker {get; set;}
        public Character Opponent { get; set; }
        public int Damage { get; set; }
    }
}
