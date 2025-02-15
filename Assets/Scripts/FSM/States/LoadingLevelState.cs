using System.Collections;
using UnityEngine;

namespace Assets.Scripts.FSM.States
{
    public class LoadingLevelState : ILevelState
    {
        private readonly LevelStateMachine _levelStateMachine;

        public LoadingLevelState(LevelStateMachine levelStateMachine)
        {
            _levelStateMachine = levelStateMachine;
        }

        public void Enter()
        {
            Debug.Log("Enter loading");

            Object playerObject = Resources.Load(GameConstans.PLAYER_PATH);
            Object.Instantiate(playerObject, new Vector3(0f, 0.68f, 0f), Quaternion.identity);

            _levelStateMachine.EnterIn<InitializeLevelState>();
        }

        public void Exit()
        {
            Debug.Log("Exit loading");
        }
    }
}