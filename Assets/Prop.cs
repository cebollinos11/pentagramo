using UnityEngine;
using System.Collections;

public class Prop : Actor {


    public override void Start()
    {
        base.Start();

        animator.Play("book_armature|walk");
    }


}
