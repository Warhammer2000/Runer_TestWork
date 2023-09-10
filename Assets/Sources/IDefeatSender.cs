using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runer
{
    public interface IDefeatSender
    {
        event Action<DefeatData> Defeated;
    }

    public abstract class DefeatData
    {
        public string Reason { get; set; }
    }
}
