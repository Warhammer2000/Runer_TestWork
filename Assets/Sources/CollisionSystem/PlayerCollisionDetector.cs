using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runer
{
    public class PlayerCollisionDetector : MonoBehaviour, IDefeatSender
    {
        public event Action<DefeatData> Defeated;

        private void OnTriggerEnter(Collider other)
        {
            var mainInstance = other.GetComponentInParent<IMainComponent>();
            CollisionDefeatData data = new CollisionDefeatData()
            {
                CollisionObject = mainInstance.InstanceGameObject,
                Reason = "Вы столкнулись с препятствием"
            };

            Defeated?.Invoke(data);
        }
    }

    public class CollisionDefeatData : DefeatData
    {
        public GameObject CollisionObject { get; set; }
    }
}
