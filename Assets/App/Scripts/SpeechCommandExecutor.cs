using UnityEngine;

namespace SimpleSpeechDemo
{
public class SpeechCommandExecutor : MonoBehaviour
{
    public void DoMoveDown()
    {
        Debug.Log("DoMoveDown");
        transform.position -= Vector3.up * 0.1f;
    }

    public void DoMoveUp()
    {
        Debug.Log("DoMoveDown");
        transform.position += Vector3.up * 0.1f;
    }
}
}