using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Enemies
{
    public class Enemy_Proxy : MonoBehaviour
    {
        Enemy _enemy;
        [SerializeField] AudioClip _clipChase;
        [SerializeField] AudioClip _clipAttack;

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

        private void playAudio()
        {
            _enemy.PlayAudioOnAnimation(_clipChase);
        }
    }
}
