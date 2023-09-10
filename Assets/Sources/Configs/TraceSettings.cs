using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runer
{
    [CreateAssetMenu(fileName = "TraceSettings", menuName = "Runer/Trace settings")]
    public class TraceSettings : ScriptableObject
    {
        [field: SerializeField] public int TraceWidth { get; private set; }
        [field: SerializeField] public int TracePartLenght { get; private set; }

        //TODO: вынести в отдельный конфиг
        //Obstacles generator settings
        [field: SerializeField] public GameObject[] ObstaclePrefabs { get; private set; }
        [field: SerializeField] public int ObstaclesAlternation { get; private set; }
        [field: SerializeField] public int StartGenerationOffset { get; private set; }
        [field: SerializeField] public int MinObstaclesCountPerRow { get; private set; }
        [field: SerializeField] public int MaxObstaclesCountPerRow { get; private set; }


        private void OnValidate()
        {
            if (TraceWidth < 2)
            {
                TraceWidth = 2;
            }

            if (TracePartLenght < 1)
            {
                TracePartLenght = 1;
            }

            if (ObstaclesAlternation < 2)
            {
                ObstaclesAlternation = 2;
            }

            if (StartGenerationOffset < 0)
            {
                StartGenerationOffset = 0;
            }

            if (MinObstaclesCountPerRow < 1)
            {
                MinObstaclesCountPerRow = 1;
            }

            if (MinObstaclesCountPerRow > TraceWidth - 1)
            {
                MinObstaclesCountPerRow = TraceWidth - 1;
            }

            if (MaxObstaclesCountPerRow > TraceWidth - 1)
            {
                MaxObstaclesCountPerRow = TraceWidth - 1;
            }

            if (MaxObstaclesCountPerRow < MinObstaclesCountPerRow)
            {
                MaxObstaclesCountPerRow = MinObstaclesCountPerRow;
            }
        }
    }
}
