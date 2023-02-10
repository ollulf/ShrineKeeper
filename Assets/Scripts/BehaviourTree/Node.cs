using UnityEngine;

namespace GraphViewBehaviorTree
{
    public abstract class Node : ScriptableObject
    {
        public enum State
        {
            Running,
            Success,
            Failure
        }

        [SerializeField] private State state = State.Running;
        [SerializeField] private bool started;

        ///<summary>
        ///Runs when the Node first starts running.
        ///Initialize the Node.
        ///</summary>
        protected abstract void OnStart();

        ///<summary>
        ///Runs when the Node stops.
        ///Any Cleanup that the Node may need to do.
        ///</summary>
        protected abstract void OnStop();

        ///<summary>
        ///Runs every Update of the Node.
        ///</summary>
        ///<returns> 
        ///The State the Node is in once it finishes Updating.
        ///</returns>
        protected abstract State OnUpdate();

        public State Update()
        {
            if (!started)
            {
                OnStart();
                started = true;
            }

            state = OnUpdate();

            //if the state is not running the state is failure or success (in case I decide to add other states latter).
            if (state != State.Failure && state != State.Success)
                return state;

            OnStop();
            started = false;
            return state;

        }
    }
}
