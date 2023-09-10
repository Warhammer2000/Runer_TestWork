using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Runer
{
    public class ObstaclesGenerator : MonoBehaviour
    {
        [SerializeField] private Transform generationCenter;
        [SerializeField] private Transform obstaclesParent;

        private TraceSettings traceSettings;

        private int currentGenerationStep;
        private int alternationCounter;

        [Inject]
        private void Construct(TraceSettings traceSettings)
        {
            this.traceSettings = traceSettings;
        }

        private void Start()
        {
            currentGenerationStep = traceSettings.StartGenerationOffset;

            for (int i = 0; i < traceSettings.TracePartLenght; i++)
            {
                TryGenerateObstacle();
            }
        }

        private void Update()
        {
            if (CheckForGeneration())
            {
                TryGenerateObstacle();
            }
        }

        //TODO: Отделить в другой класс
        private bool CheckForGeneration()
        {
            float generationCenterPositionZ = Mathf.Floor(generationCenter.position.z);
            if (generationCenterPositionZ + traceSettings.TracePartLenght > currentGenerationStep)
            {
                return true;
            }

            return false;
        }

        private void TryGenerateObstacle()
        {
            alternationCounter++;

            if (alternationCounter <= traceSettings.ObstaclesAlternation)
            {
                currentGenerationStep++;
                return;
            }

            InstantiateObstacle();

            currentGenerationStep++;

            alternationCounter = 0;
        }

        private void InstantiateObstacle()
        {
            int traceWidth = traceSettings.TraceWidth;
            int obstaclesCount = Random.Range(traceSettings.MinObstaclesCountPerRow, traceSettings.MaxObstaclesCountPerRow);

            bool[] isBusy = new bool[traceWidth];

            for (int i = 0; i < obstaclesCount; i++)
            {
                int randomColumn = Random.Range(0, traceWidth);
                while (isBusy[randomColumn])
                {
                    randomColumn = Random.Range(0, traceWidth);
                }

                int typeNumber = Random.Range(0, traceSettings.ObstaclePrefabs.Length);
                var obstacle = Instantiate(traceSettings.ObstaclePrefabs[typeNumber], obstaclesParent);
                obstacle.name = string.Format("Obtacle_{0}", currentGenerationStep);
                obstacle.transform.position += Vector3.forward * currentGenerationStep;
                obstacle.transform.position += Vector3.right * randomColumn;

                isBusy[randomColumn] = true;
            }
        }
    }
}
