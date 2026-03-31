using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{
    [SerializeField] private GameObject targetObject;

    public void ActivateObject()
    {
        targetObject.SetActive(true);
    }
}