using System.Collections;
using UnityEngine;

public class UITuck : MonoBehaviour
{
    [Tooltip("How fast the animation will occur")]
    public float AnimationSpeed = 0.5f;
    public enum Direction
    {
        Horizontal,
        Vertical
    }
    public Direction direction;

    [SerializeField]
    [Header("Default Data For UI Tuck Movement")]
    [Tooltip("The axis distance that the UI element will traverse")]
    private int distance = 30;

    private void OnEnable()
    {
        StartCoroutine(UITuckMove(AnimationSpeed));
    }

    private IEnumerator UITuckMove(float time)
    {

        while (true)
        {
            yield return new WaitForSecondsRealtime(time);
            if(direction==Direction.Vertical)
                gameObject.transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y - distance, transform.localPosition.z);
            else
                gameObject.transform.localPosition = new Vector3(transform.localPosition.x - distance, transform.localPosition.y, transform.localPosition.z);
            yield return new WaitForSecondsRealtime(time);
            if (direction == Direction.Vertical)
                gameObject.transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + distance, transform.localPosition.z);
            else
                gameObject.transform.localPosition = new Vector3(transform.localPosition.x + distance, transform.localPosition.y, transform.localPosition.z);
        }
    }
}
