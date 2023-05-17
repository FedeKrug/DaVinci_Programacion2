
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

		//En este script se hace el evento del cambio de armas

	}
}
