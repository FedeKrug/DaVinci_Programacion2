using Game.Cameras;
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

		public CameraChangeEvent cameraChangeEvent = new CameraChangeEvent();
	}

	public class IcreaseHealthEvent : UnityEvent<float>{} //primer float: vida actual, segundo float: modificador de vida (damage, boost, etc) -> aplicado a la curacion
	public class TakeDamageEvent : UnityEvent<float>{} //primer float: vida actual, segundo float: modificador de vida (damage, boost, etc) -> aplicado al daño

	public class CameraChangeEvent : UnityEvent <TypesOfCamera>{} //primer TypesOfCamera: tipo de camara deseado
}
