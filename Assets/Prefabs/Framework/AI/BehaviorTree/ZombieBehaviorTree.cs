using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehaviorTree : BehaviorTree
{
   public override void Init(AIController aiController)
   {
      base.Init(aiController);
      Sequence patrolSequence = new Sequence(aiController);
         patrolSequence.AddChild(new BTTask_GetNextPatrolPoint(aiController));
         patrolSequence.AddChild(new BTTask_MoveTo(aiController,"patrolPoint", 1f));
         patrolSequence.AddChild(new BTTask_Wait(aiController,3));
      SetRoot(patrolSequence);
   }
}
