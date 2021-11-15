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
         BTTask_MoveTo MoveToTarget = new BTTask_MoveTo(aiController, "Target", 1.5f,"LastSeenLocation");
         BlackboardDecorator MoveToTargetDeco = new BlackboardDecorator(aiController, MoveToTarget, "Target", EKeyQuery.Set, EObserverAborts.Both);
         BTTask_MoveTo MoveToLastKnowLoc = new BTTask_MoveTo(aiController, "LastSeenLocation", 1.5f);
         BTTask_WaitThenContinue WaitThenPatrol = new BTTask_WaitThenContinue(aiController,2.0f);
      RootSelector.AddChild(MoveToTargetDeco);
      RootSelector.AddChild(MoveToLastKnowLoc);
      RootSelector.AddChild(WaitThenPatrol);
         Sequence patrolSequence = new Sequence(aiController);
            patrolSequence.AddChild(new BTTask_GetNextPatrolPoint(aiController));
            patrolSequence.AddChild(new BTTask_MoveTo(aiController, "patrolPoint", 1f));
            patrolSequence.AddChild(new BTTask_Wait(aiController,3));
      RootSelector.AddChild(patrolSequence);
         
      SetRoot(RootSelector);
   }
}
