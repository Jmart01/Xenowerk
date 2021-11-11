using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehaviorTree : BehaviorTree
{
   public override void Init(AIController aiController)
   {
      base.Init(aiController);
      aiController.AddBlackboardKey("patrolPoint");
      Selector patrolSequence = new Selector(aiController);
         patrolSequence.AddChild(new BTTask_AlwaysFail(aiController));
         patrolSequence.AddChild(new BTTask_Wait(aiController,3));
         patrolSequence.AddChild(new BTTask_Wait(aiController,4));
         //the wait for 4 should never be called
      SetRoot(patrolSequence);
   }
}
