using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAnimatorEffectDestroy : MonoBehaviour
{
    private Animator animator;

    private Animator MyAnimator
    {
        get
        {
            if(animator == null)
            {
                animator = GetComponent<Animator>();
            }

            return animator;
        }
    }

    

    private void Update()
    {
        if (MyAnimator == null)
            return;

        var stateInfo = MyAnimator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.normalizedTime < 1f)
            return;

        Destroy(this.gameObject);
    }


}
