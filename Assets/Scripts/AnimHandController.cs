using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(Animator))]

public class AnimHandController : MonoBehaviour
{
    [SerializeField]
    private InputActionReference gripInputActionReference;
       [SerializeField]
    private InputActionReference triggerInputActionReference;
    private Animator _handAnimator;

    private float _gripValue;
    private float _triggerValue;
     void Start(){
      _handAnimator = GetComponent<Animator>();



    }

    // Update is called once per frame
    void Update()
    {
        AnimateGrip();
        AnimateTrigger();
    }



    private void AnimateGrip(){
      _gripValue=gripInputActionReference.action.ReadValue<float>();
      _handAnimator.SetFloat("Grip",_gripValue);
    }
      private void AnimateTrigger(){
      _triggerValue=triggerInputActionReference.action.ReadValue<float>();
      _handAnimator.SetFloat("Trigger",_triggerValue);
    }
}
