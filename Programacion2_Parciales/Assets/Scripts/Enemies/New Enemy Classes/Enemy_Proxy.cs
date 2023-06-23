using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Enemies
{
    public class Enemy_Proxy : MonoBehaviour
    {
        Enemy _enemy;

        void Start()
        {
            _enemy = GetComponentInParent<Enemy>();
        }

        private void onAttackEnd()
        {
            _enemy.startMovement();
        }

        private void onAttackBegin()
        {
            _enemy.stopMovement();
        }

        private void attackDmg()
        {
            _enemy.animationAttack();
        }

        private void Destroy()
        {
            _enemy.destroyOnAnimation();
        }

        private void playAudio(AudioClip clip)
        {
            _enemy.PlayAudioOnAnimation(clip);
        }
    }
}
