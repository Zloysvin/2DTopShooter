using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEventArgs : EventArgs
{
    public bool KilledByPlayer { get; set; }
    public int points { get; set; }

    public DeathEventArgs(bool killedByPlayer, int points)
    {
        KilledByPlayer = killedByPlayer;
        this.points = points;
    }
}
