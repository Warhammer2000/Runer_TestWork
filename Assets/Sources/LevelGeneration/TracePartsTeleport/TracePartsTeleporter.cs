using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace Runer
{
    [RequireComponent(typeof(TracePartCompleteDetector))]
    public class TracePartsTeleporter : MonoBehaviour
    {
        private List<TracePart> traceParts;
        private TracePartCompleteDetector detector;

        [SerializeField] float teleportDistance = 30;

        private void Awake()
        {
            detector = GetComponent<TracePartCompleteDetector>();
            traceParts = new List<TracePart>();
            GetComponentsInChildren(traceParts);
        }

        private void Start()
        {
            detector.TeleportRequired += TraceTeleportRequiredHandler;
        }

        private void TraceTeleportRequiredHandler(TracePart part)
        {
            part.transform.position += Vector3.forward * teleportDistance * traceParts.Count;
        }

        private void OnDestroy()
        {
            detector.TeleportRequired -= TraceTeleportRequiredHandler;
        }
    }
}
