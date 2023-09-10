using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Runer
{
    public class ScoreCalculator : MonoBehaviour
    {
        private MatchModel matchModel;

        private float score;

        [Inject]
        private void Construct(MatchModel matchModel)
        {
            this.matchModel = matchModel;
        }

        private void Update()
        {
            score += Time.deltaTime;
            matchModel.Score += (int)score;
        }
    }
}