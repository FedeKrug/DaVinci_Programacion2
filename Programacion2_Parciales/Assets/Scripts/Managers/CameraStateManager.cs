using UnityEngine;

namespace Game.Managers
{
	public class CameraStateManager : MonoBehaviour
	{
		#region Singleton
		public static CameraStateManager instance;
		private void Awake()
		{
			if (instance == null)
			{
				instance = this;
			}
			else
			{
				Destroy(gameObject);
			}
		}
		#endregion

		[SerializeField] private State currentState;

		private void LateUpdate()
		{
			RunStateMachine();
		}

		private void RunStateMachine()
		{
			State nextState = currentState?.RunCurrentState();

			if (nextState != null)
			{
				SwitchToTheNextState(nextState);
			}

		}
		private void SwitchToTheNextState(State nextState)
		{
			currentState = nextState;
		}
	}
}