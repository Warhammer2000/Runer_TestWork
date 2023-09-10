using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

namespace Runer
{
    public class GameOverPopup : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI popupText;

        private Canvas popupCanvas;
        private IDefeatSender defeatSender;

        [Inject]
        private void Construct(IDefeatSender sender)
        {
            defeatSender = sender;
        }

        private void Awake()
        {
            popupCanvas = GetComponent<Canvas>();
        }

        private void Start()
        {
            defeatSender.Defeated += DefeatHandler;
        }

        private void DefeatHandler(DefeatData data)
        {
            popupCanvas.enabled = true;
            popupText.text = $"Вы проиграли, причина: {data.Reason}";
        }
    }
}
