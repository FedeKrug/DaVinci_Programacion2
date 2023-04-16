
using UnityEngine;
using UnityEngine.Events;
namespace Game.Managers
{
	[DefaultExecutionOrder(-10)]
	public class EventManager : MonoBehaviour
	{
		public static EventManager instance;
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
		public IcreaseHealthEvent playerHealthIncreased = new IcreaseHealthEvent();
		public TakeDamageEvent playerDamaged = new TakeDamageEvent();
	}

	public class IcreaseHealthEvent : UnityEvent<float>{} //primer float: vida actual, segundo float: modificador de vida (damage, boost, etc)
	public class TakeDamageEvent : UnityEvent<float>{} //primer float: vida actual, segundo float: modificador de vida (damage, boost, etc)
}
