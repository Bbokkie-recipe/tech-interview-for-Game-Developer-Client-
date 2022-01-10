using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleRandomStateMachineBehaviour : StateMachineBehaviour
{

    #region Varibles
    [SerializeField] public int numberOfStates = 2;
    [SerializeField] public float minNormTime = 0f;
    [SerializeField] public float maxNormTime = 5f;

    [SerializeField] public float randowmNormalTime;

    readonly int hashRandomIdle = Animator.StringToHash("RandomIdle");

    #endregion

    //Ʈ�����ǿ� �ʿ��� �ð� ���
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        randowmNormalTime = Random.Range(minNormTime, maxNormTime);
    }

    //���¿� �����ϰ� ������Ʈȣ��
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //�ش� ������Ʈ�� ���� ���� �ʴ�
        if (animator.IsInTransition(0) && animator.GetCurrentAnimatorStateInfo(0).fullPathHash == stateInfo.fullPathHash)
        {
            //�ƹ� �͵� ���� �ʱ�
            animator.SetInteger(hashRandomIdle, -1);
        }
        //randowmNormalTime�� �������� Random numberOfStates ����
        if (stateInfo.normalizedTime > randowmNormalTime && !animator.IsInTransition(0))
        {
            animator.SetInteger(hashRandomIdle, Random.Range(0, numberOfStates));
        }
    }

    /*
    OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    OnStateMove is called right after Animator.OnAnimatorMove()
    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Implement code that processes and affects root motion
    }

    OnStateIK is called right after Animator.OnAnimatorIK()
    override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Implement code that sets up animation IK (inverse kinematics)
    }
    */
}
