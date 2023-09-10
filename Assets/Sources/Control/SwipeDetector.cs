using System;
using UnityEngine;

namespace Runer
{
    public class SwipeDetector : MonoBehaviour
    {
        private Vector2 fingerDownPosition;
        private Vector2 fingerUpPosition;

        //TODO: вынести в конфиг
        [SerializeField] private bool detectSwipeOnlyAfterRelease = false;
        [SerializeField] private float minDistanceForSwipe = 20f;
        [SerializeField] private bool useKeyboard;

        public event Action<SwipeData> OnSwipe;

        private void Update()
        {
            if (useKeyboard && Application.isEditor)
            {
                if (Input.GetKey(KeyCode.A))
                {
                    SendSwipe(Direction2D.Left);
                }

                if (Input.GetKey(KeyCode.D))
                {
                    SendSwipe(Direction2D.Right);
                }

                return;
            }

            foreach (Touch touch in Input.touches)
            {
                fingerDownPosition = touch.position;

                if (touch.phase == TouchPhase.Began)
                {
                    fingerUpPosition = touch.position;
                }

                if (!detectSwipeOnlyAfterRelease && touch.phase == TouchPhase.Moved)
                {
                    AnalyseSwipe();
                }

                if (touch.phase == TouchPhase.Ended)
                {
                    AnalyseSwipe();
                }
            }
        }

        private void AnalyseSwipe()
        {
            bool isDistanceEnought = Vector2.Distance(fingerDownPosition, fingerUpPosition) > minDistanceForSwipe;
            if (isDistanceEnought)
            {
                bool isVertical = Mathf.Abs(fingerDownPosition.y - fingerUpPosition.y) >
                                  Mathf.Abs(fingerDownPosition.x - fingerUpPosition.x);

                Direction2D direction;
                if (isVertical)
                {
                    direction = fingerDownPosition.y - fingerUpPosition.y > 0 ? Direction2D.Up : Direction2D.Down;
                }
                else
                {
                    direction = fingerDownPosition.x - fingerUpPosition.x > 0 ? Direction2D.Right : Direction2D.Left;
                }

                SendSwipe(direction);

                fingerUpPosition = fingerDownPosition;
            }
        }

        private void SendSwipe(Direction2D Direction2D)
        {
            SwipeData swipeData = new SwipeData()
            {
                Direction = Direction2D,
                //StartPosition = fingerDownPosition,
                //EndPosition = fingerUpPosition
            };

            OnSwipe?.Invoke(swipeData);
        }
    }

    public struct SwipeData
    {
        //public Vector2 StartPosition;
        //public Vector2 EndPosition;
        public Direction2D Direction;
    }
}
