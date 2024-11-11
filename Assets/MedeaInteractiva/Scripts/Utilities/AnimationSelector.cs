using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class AnimationSelector : MonoBehaviour
{
   public bool isStand;

   private Animator _animator;
   [SerializeField]  private int _index;

   private void Awake()
   {
      _animator = GetComponent<Animator>();
   }

   private void Start()
   {
      _animator.SetBool("IsStand", isStand);
   }

   public void SetAnimation()
   {
      _index = Random.Range(0, isStand ? 9 : 3);
      SetAnimationIndex(_index);
   }

   private void SetAnimationIndex(int index)
   {
      _animator.SetFloat("IndexAnim", (float)index);
   }
}
