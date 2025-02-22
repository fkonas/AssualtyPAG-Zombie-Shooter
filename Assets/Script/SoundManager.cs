using UnityEngine;
using static Weapon;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; set; }

    [Header("Weapons")]
    public AudioSource shootingChannel;

    public AudioClip PistolShot;
    public AudioClip AK47Shot;
    public AudioSource reloadingSoundPistol;
    public AudioSource reloadingSoundAK47;
    public AudioSource emptyMagazineSoundPistol;
    public AudioSource semiAK47RedySound;
    public AudioSource semiPistolRedySound;

    [Header("Throwables")]
    public AudioSource throwablesChannel;
    public AudioClip grenadeSound;

    [Header("Zombies")]
    public AudioSource zombieChannel;
    public AudioSource zombieChannel2;
    public AudioClip zombieWalking;
    public AudioClip zombieChase;
    public AudioClip zombieAttack;
    public AudioClip zombieHurt;
    public AudioClip zombieDeath;

    [Header("Player")]
    public AudioSource playerChannel;
    public AudioClip playerHurt;
    public AudioClip playerDeath;

    public AudioClip gameOverMusic;

    [Header("GameMusic")]
    public AudioSource game_music;



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
        switch(weapon)
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
