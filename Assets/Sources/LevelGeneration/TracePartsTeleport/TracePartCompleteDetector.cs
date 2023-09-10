using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runer
{
    public class TracePartCompleteDetector : MonoBehaviour
    {
        [SerializeField] GameObject trigger;

        private List<TracePart> traceParts;

        public event Action<TracePart> TeleportRequired;

        private void Awake()
        {
            traceParts = new List<TracePart>();
            GetComponentsInChildren(traceParts);
        }

        public void Update()
        {
            foreach (var part in traceParts)
            {
                if (trigger.transform.position.z >= part.TeleportTrigger.position.z)
                {
                    TeleportRequired?.Invoke(part);
                }
            }
        }
    }
}
