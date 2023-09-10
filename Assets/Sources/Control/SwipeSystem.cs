//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.EventSystems;
//using UnityEngine.InputSystem;

//namespace Runner
//{
//    public enum Direction
//    {
//        Left = 0,
//        Right = 1,
//        Up = 2,
//        Down = 3
//    }

//    public class SwipeSystem : MonoBehaviour
//    {
//        private Vector2 startTouchPosition;
//        private Vector2 swipeDelta;
//        private bool touchMoved;
//        //private const float SWIPE_THRESHOLD = 50f;

//        public Action<Direction> SwipeEvent;
//        public Action<Vector2> ClickEvent;

//        private Vector2 TouchPosition => (Vector2)Input.mousePosition;

//        private bool TouchBegan => Input.GetMouseButtonDown(0);
//        private bool TouchEnded => Input.GetMouseButtonUp(0);
//        private bool GetTouch => Input.GetMouseButton(0);

//        private void Update()
//        {
//            if (Input.touchCount == 0)
//            {
//                return;
//            }

//            var touch = Touchscreen.current.primaryTouch;
            
//            switch (touch.phase)
//            {
//                case TouchPhase.Began:
//                    startTouchPosition = touch.position;
//                    break;

//                case TouchPhase.Moved:
//                    swipeDelta = touch.position - startTouchPosition;
//                    break;

//                case TouchPhase.Ended:
//                    var direction = Direction.Down;

//                    if (swipeDelta.x > 0 && Mathf.Abs(swipeDelta.x) > Mathf.Abs(swipeDelta.y))
//                    {
//                        direction = Direction.Right;
//                    }

//                    if (swipeDelta.x < 0 && Mathf.Abs(swipeDelta.x) > Mathf.Abs(swipeDelta.y))
//                    {
//                        direction = Direction.Left;
//                    }

//                    if (swipeDelta.y > 0 && Mathf.Abs(swipeDelta.x) < Mathf.Abs(swipeDelta.y))
//                    {
//                        direction = Direction.Up;
//                    }

//                    if (swipeDelta.y < 0 && Mathf.Abs(swipeDelta.x) < Mathf.Abs(swipeDelta.y))
//                    {
//                        direction = Direction.Down;
//                    }

//                    SwipeEvent?.Invoke(direction);

//                    Debug.Log(direction);
//                    break;
//            }
//        }
//    }
//}
