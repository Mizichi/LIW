using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FerretEat : MonoBehaviour //allows for Ferret Animation to play when eating
{
    public Animator FerretAnimate;

    public void AnimateEat()
    {
        FerretAnimate.SetTrigger("Eat");
    }

}
