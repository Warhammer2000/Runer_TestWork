using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Runer
{
    [SelectionBase]
    public class PlayerMovement : MonoBehaviour
    {
        //Dependencies
        private MovementSettings settings;
        private PlayerMovementState state;
        private SwipeDetector input;

        public class args
        {

        }

        [Inject]
        private void Construct(MovementSettings settings, PlayerMovementState state, SwipeDetector input)
        {
            this.input = input;
            this.settings = settings;
            this.state = state;
        }

        private void Start()
        {
            input.OnSwipe += SwipeHandler;
        }

        private void Update()
        {
            MoveForward();
        }

        private void SwipeHandler(SwipeData data)
        {
            if (!state.CanMoveLeftOrRight)
            {
                return;
            }

            int direction = 0;

            if (data.Direction == Direction2D.Left)
            {
                direction = -1;
            }

            if (data.Direction == Direction2D.Right)
            {
                direction = 1;
            }

            if (direction != 0)
            {
                bool success = state.TryStartHorizontalMove(direction);
                if (success)
                {
                    StartCoroutine(RightOrLeftMoveProcess(direction));
                }
            }
        }

        private IEnumerator RightOrLeftMoveProcess(int direction)
        {
            float xOriginCoord = transform.position.x;

            float moveProgress = 0;

            while (moveProgress < 1)
            {
                float delta = Time.deltaTime * (1 / settings.HorizontalStepTime);
                moveProgress += delta;
                if (moveProgress > 1)
                {
                    Vector3 currentPlayerPositionWithOldXCoord = new Vector3(xOriginCoord, transform.position.y, transform.position.z);
                    transform.position = currentPlayerPositionWithOldXCoord + Vector3.right * Mathf.Sign(direction);
                    state.DeclareEndMove(direction);
                    break;
                }
                else
                {
                    transform.position += Vector3.right * delta * Mathf.Sign(direction);
                }
                yield return new WaitForEndOfFrame();
            }
        }

        private void MoveForward()
        {
            float delta = Time.deltaTime * settings.ForwardSpeed;
            transform.position += Vector3.forward * delta;
        }
    }
}
