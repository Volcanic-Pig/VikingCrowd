using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class PunchBagActivity : Activity
    {
        public override void PerformActivity()
        {
            if (!_started) return; 
            base.PerformActivity();
            Player.DoPunch(ActivityPerformed);
        }
    }
}
