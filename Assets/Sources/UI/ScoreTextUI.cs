using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

namespace Runer
{
    public class ScoreTextUI : MonoBehaviour
    {
        private TextMeshProUGUI scoreTMP;

        private MatchModel matchModel;

        private void Awake()
        {
            scoreTMP = GetComponent<TextMeshProUGUI>();
        }

        [Inject]
        private void Construct(MatchModel model)
        {
            matchModel = model;
        }

        private void Start()
        {
            matchModel.PropertyChanged += ScoreChangeHandler;
        }

        private void ScoreChangeHandler(string propertyName, object _)
        {
            if (propertyName != nameof(matchModel.Score))
            {
                return;
            }

            scoreTMP.text = $"Score: {matchModel.Score}";
        }
    }
}