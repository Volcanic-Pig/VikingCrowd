using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class PunchBagGate : Gate
    {
        public override void PerformActivity()
        {
            base.PerformActivity();
            Player.DoPunch();
        }
    }
}
