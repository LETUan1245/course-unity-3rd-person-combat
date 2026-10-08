using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackingState : EnemyBaseState
{
    private readonly int AttackHash = Animator.StringToHash("Attack");

    private const float TransitionDuration = 0.1f;
    public EnemyAttackingState(EnemyStateMachine stateMachines) : base(stateMachines) {}

    public override void Enter()
    {
        FacePlayer();
        stateMachines.Weapon.SetAttack(stateMachines.AttackDamage,stateMachines.AttackKnockback);
        stateMachines.Animator.CrossFadeInFixedTime(AttackHash,TransitionDuration);
    }
    public override void Tick(float deltaTime)
    {
        if (GetNormalizedTime(stateMachines.Animator,"Attack") >= 1)
        {
            stateMachines.SwitchState(new EnemyChasingState(stateMachines));
        }
        FacePlayer();
    }

    public override void Exit()
    {
        
    }

}
