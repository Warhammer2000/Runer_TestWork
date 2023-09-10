//using UnityEngine;

//namespace Runer
//{
//    public class SwipeHandler : MonoBehaviour
//    {
//        private void OnEnable()
//        {
//            GetComponent<SwipeDetector>().OnSwipe += HandleSwipe;
//        }

//        private void OnDisable()
//        {
//            GetComponent<SwipeDetector>().OnSwipe -= HandleSwipe;
//        }

//        private void HandleSwipe(SwipeData swipeData)
//        {
//            Debug.Log("Свайп в направлении: " + swipeData.Direction2D);
//        }
//    }
//}
