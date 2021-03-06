﻿using SlipeServer.Server.Enums;
using System;

namespace SlipeServer.Server.Elements.Events
{
    public class WeaponRemovedEventArgs : EventArgs
    {
        public Ped Ped { get; set; }
        public WeaponId WeaponId { get; }
        public ushort? AmmoCount { get; }

        public WeaponRemovedEventArgs(Ped ped, WeaponId weaponId, ushort? ammoCount)
        {
            Ped = ped;
            WeaponId = weaponId;
            AmmoCount = ammoCount;
        }
    }
}
