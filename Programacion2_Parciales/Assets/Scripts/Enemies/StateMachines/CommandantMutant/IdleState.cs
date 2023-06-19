using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Game.Enemies.Mutant
{
	public class IdleState : State
	{
		public bool inRangeOfView;
		[SerializeField] private ChaseState _chaseState;

		public override State RunCurrentState()
		{
			if (inRangeOfView)
			{
				return _chaseState;
			}
			else
			{
				return this;
			}
		}
	}
}