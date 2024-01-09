using System.Collections.Generic;
using Assets.Scripts.GamePlayer;
using UnityEngine;

namespace Assets.Scripts.GameEnemy.StateMachine
{
    public abstract class State : MonoBehaviour
    {
        [SerializeField] private List<Transition> _transitions;

        protected Player Target { get; private set; }

        public void Enter(Player target)
        {
            if (enabled == false)
            {
                Target = target;
                enabled = true;

                foreach (Transition transition in _transitions)
                {
                    transition.enabled = true;
                    transition.Init(Target);
                }
            }
        }

        public State GetNextState()
        {
            foreach (Transition transition in _transitions)
            {
                if (transition.NeedTransit)
                    return transition.TargetState;
            }

            return null;
        }

        public void Exit()
        {
            if (enabled == true)
            {
                foreach (Transition transition in _transitions)
                    transition.enabled = false;

                enabled = false;
            }
        }
    }
}