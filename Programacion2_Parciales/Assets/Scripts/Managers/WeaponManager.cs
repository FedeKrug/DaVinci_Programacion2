
using UnityEngine;
namespace Game.Managers
{
	public class WeaponManager : MonoBehaviour
	{
		public static WeaponManager instance;
		#region Singleton 
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
		[SerializeField] private ChangeWeapon _actualWeapon;


		private void OnEnable()
		{
			EventManager.instance.changeWeaponEvent.AddListener(ChangeWeaponHandler);
		}

		private void OnDisable()
		{
			EventManager.instance.changeWeaponEvent.RemoveListener(ChangeWeaponHandler);
			
		}

		public void ChangeWeaponHandler(Weapons newWeapon)
		{
			_actualWeapon.weaponType = newWeapon;
		}
		//En este script se hace el evento del cambio de armas

	}
}
