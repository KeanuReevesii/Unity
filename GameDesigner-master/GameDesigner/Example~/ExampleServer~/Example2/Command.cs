﻿namespace Example2
{
    public class Command : Net.Component.Command
    {
        public const byte Fire = 150;
        public const byte AIMonster = 151;
        public const byte AIAttack = 152;
        public const byte Resurrection = 153;//复活
        public const byte PlayerState = 154;
        public const byte AttackPlayer = 155;

        public const byte EnterArea = 156;
        public const byte ExitArea = 157;

        public const byte SetDestination = 157;
    }
}