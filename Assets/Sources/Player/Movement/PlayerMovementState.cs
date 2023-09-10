using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Zenject;

namespace Runer
{
    public class PlayerMovementState
    {
        //Public fields
        public int CurrentTraceNumber { get; private set; }
        public bool CanMoveLeftOrRight { get; private set; } = true;

        //Depencies
        private MovementSettings movementSettings;
        private TraceSettings traceSettings;

        [Inject]
        private void Construct(MovementSettings movementSettings, TraceSettings traceSettings)
        {
            this.movementSettings = movementSettings;
            this.traceSettings = traceSettings; 
        }

        public void DeclareEndMove(int direction)
        {
            CanMoveLeftOrRight = true;
            CurrentTraceNumber += Math.Sign(direction);
        }

        public bool TryStartHorizontalMove(int direction)
        {
            if (IsCanMoveLeftOrRight(direction))
            {
                CanMoveLeftOrRight = false;
                return true;
            }

            return false;
        }

        public bool IsCanMoveLeftOrRight(int direction)
        {
            int newTraceNumber = CurrentTraceNumber + Math.Sign(direction);

            if (newTraceNumber < traceSettings.TraceWidth && newTraceNumber >= 0)
            {
                return true;
            }

            return false;
        }
    }
}
