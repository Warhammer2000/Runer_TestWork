using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Runer
{
    [RequireComponent(typeof(PlayerMovement))]
    public class Player : MonoBehaviour, IMainComponent
    {
        public GameObject InstanceGameObject => gameObject;

        private PlayerMovement playerMovement;
        private IDefeatSender defeatSender;

        [Inject]
        private void Construct(IDefeatSender defeatSender, int i)
        {
            this.defeatSender = defeatSender;

            Debug.Log(i);
        }

        private void Awake()
        {
            playerMovement = GetComponent<PlayerMovement>();
        }

        private void Start()
        {
            defeatSender.Defeated += DefeatHandler;
        }

        private void DefeatHandler(DefeatData data)
        {
            playerMovement.enabled = false;
        }
    }
}
