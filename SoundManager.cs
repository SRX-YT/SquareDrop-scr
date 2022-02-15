using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource changeSound;
    [SerializeField] AudioSource playSound;
    [SerializeField] AudioSource pickSound;

    public void PlayChanged()
    {
        changeSound.Play();
    }

    public void PlayDestroy()
    {
        playSound.Play();
    }

    public void PlayPick()
    {
        pickSound.Play();
    }
}
