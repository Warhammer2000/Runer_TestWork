using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runer
{
    [CreateAssetMenu(fileName = "MovementSettings", menuName = "Runer/Movement settings")]
    public class MovementSettings : ScriptableObject
    {
        [field: SerializeField] public float ForwardSpeed { get; private set; }
        [field: SerializeField] public float HorizontalStepTime { get; private set; }
        
        private void OnValidate()
        {
            if (HorizontalStepTime < 0)
            {
                HorizontalStepTime = 0;
            }

            if (ForwardSpeed < 0)
            {
                ForwardSpeed = 0;
            }
        }
    }
}
