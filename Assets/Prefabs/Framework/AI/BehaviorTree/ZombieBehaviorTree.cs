using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ZombieBehaviorTree : BehaviorTree
{
   public override void Init(AIController aiController)
   {
      base.Init(aiController);
      aiController.AddBlackboardKey("patrolPoint");
      aiController.AddBlackboardKey("Target");
      aiController.AddBlackboardKey("LastSeenLocation");
      Selector RootSelector = new Selector(aiController);
      RootSelector.AddChild(RootSelector);
      
      BTTask_MoveTo MoveToTarget = new BTTask_MoveTo(aiController, "Target", 1.5f);
         BlackboardDecorator MoveToTargetDeco = new BlackboardDecorator(aiController, MoveToTarget, "Target", EKeyQuery.Set, EObserverAborts.Both);
         RootSelector.AddChild(MoveToTargetDeco);

      Sequence MoveThenCheck = new Sequence(aiController);
         BTTask_MoveTo MoveToLastKnownLoc = new BTTask_MoveTo(aiController, "LastSeenLocation", 1.5f);
         BTTask_ClearBlackboardVal ClearLastSeenLoc = new BTTask_ClearBlackboardVal(aiController, "LastSeenLocation");
         
      RootSelector.AddChild(MoveThenCheck);
         Sequence patrolSequence = new Sequence(aiController);
            patrolSequence.AddChild(new BTTask_GetNextPatrolPoint(aiController));
            patrolSequence.AddChild(new BTTask_MoveTo(aiController, "patrolPoint", 1f));
            patrolSequence.AddChild(new BTTask_Wait(aiController,3));
      RootSelector.AddChild(patrolSequence);
         
      SetRoot(RootSelector);
   }
}
