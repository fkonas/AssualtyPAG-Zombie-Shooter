using UnityEngine;
using static Weapon;

public class AnimationManager : MonoBehaviour
{
    public static AnimationManager Instance { get; set; }

    public Animator animator;


    public AudioSource shootingChannel;

    public AudioClip PistolShot;
    public AudioClip AK47Shot;

    public AudioSource reloadingSoundPistol;
    public AudioSource reloadingSoundAK47;

    public AudioSource emptyMagazineSoundPistol;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void PlayShootingSound(WeaponModel weapon)
    {
        switch (weapon)
        {
            case WeaponModel.Pistol:
                shootingChannel.PlayOneShot(PistolShot);
                break;
            case WeaponModel.AK47:
                shootingChannel.PlayOneShot(AK47Shot);
                break;
        }
    }

    public void PlayReloadingSound(WeaponModel weapon)
    {
        switch (weapon)
        {
            case WeaponModel.Pistol:
                reloadingSoundPistol.Play();
                break;
            case WeaponModel.AK47:
                reloadingSoundAK47.Play();
                break;
        }
    }
}
