using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.Events;

public class HeroFeelExample : MonoBehaviour
{



    public MMF_Player OnAttackFeedback;
    public MMF_Player OnHitFeedback;
    public MMF_Player OnDeadFeedback;

    public UnityEvent OnAttackUnityEvent;
    void Start()
    {
        
    }


    void Update()
    {
        
    }
    public void OnAttack()
    {
        OnAttackFeedback?.PlayFeedbacks();
        OnAttackFeedback?.StopFeedbacks();
        OnAttackUnityEvent?.Invoke(); 
    }
}
