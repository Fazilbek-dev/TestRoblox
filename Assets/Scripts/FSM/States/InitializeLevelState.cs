using System.Collections;
using UnityEngine;

namespace Assets.Scripts.FSM.States
{
    public class InitializeLevelState : ILevelState
    {
        private readonly LevelStateMachine _levelStateMachine;

        public InitializeLevelState(LevelStateMachine levelStateMachine)
        {
            _levelStateMachine = levelStateMachine;
        }

        public void Enter()
        {
            Debug.Log("Enter initialize");
        }

        public void Exit()
        {
            Debug.Log("Exit initialize");
        }
    }
}