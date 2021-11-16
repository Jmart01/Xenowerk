 using UnityEditor.Experimental.GraphView;
 using UnityEngine;

 public enum EKeyQuery
 {
     Set,
     NotSet
 }

 public enum EObserverAborts
 {
     None,
     Self,
     LowerPriority,
     Both
 }
 public class BlackboardDecorator : Decorator
 {
     private string _keyName;
     private EKeyQuery _keyQuery;
     private EObserverAborts _observerAborts;
     public BlackboardDecorator(AIController aiController, BTNode child,string keyName, EKeyQuery keyQuery, EObserverAborts observerAborts) : base(aiController, child)
     {
         _keyName = keyName;
         _keyQuery = keyQuery;
         _observerAborts = observerAborts;
         aiController.onBlackboardKeyUpdated += KeyUpdated;
     }

     public override EBTTaskResult Execute()
     {
         object value = aiController.GetBlackboardValue(_keyName);
         
         if (ShouldDoTask(value))
         {
             return EBTTaskResult.Running;
         }

         return EBTTaskResult.Fail;
     }

     private void KeyUpdated(string key, object value)
     {
         if (key != _keyName)
         {
             return;
         }
         if (aiController.GetBehaviorTree().IsRunning(this))
         {
             if (!ShouldDoTask(value))
             {
                 if (_observerAborts == EObserverAborts.Self || _observerAborts == EObserverAborts.Both)
                 {
                     AbortTask();
                 }
             }
         }
         else if (aiController.GetBehaviorTree().IsCurrentLowerThan(this))
         {
             if (ShouldDoTask(value))
             {
                 if (_observerAborts == EObserverAborts.Both || _observerAborts == EObserverAborts.LowerPriority)
                 {
                     aiController.GetBehaviorTree().Restart();
                 }
             }
         }
     }

     public override EBTTaskResult UpdateTask()
     {
         if (!GetChild().HasStarted())
         {
             return GetChild().Start();
         }

         return GetChild().Update();
     }

     public override void FinishTask()
     {
     }

     bool ShouldDoTask(object value)
     {
         switch (_keyQuery)
         {
             case EKeyQuery.Set:
                 return value != null;
             case EKeyQuery.NotSet:
                 return value == null;
             default:
                 return false;
         }
     }
 }
