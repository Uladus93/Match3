using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource _soundGear;
    [SerializeField] private AudioSource _soundMarket;
    [SerializeField] private AudioSource _soundButtonClick;
    [SerializeField] private AudioSource _soundWater;
    [SerializeField] private AudioSource _soundBait;
    [SerializeField] private AudioSource _soundRocket;
    [SerializeField] private AudioSource _soundSand;
    [SerializeField] private AudioSource _soundSpice;
    [SerializeField] private AudioSource _soundWorm;
    [SerializeField] private AudioSource _soundSolders;
    [SerializeField] private AudioSource _openTileSound;
    private Toggle _soundToggle;

    public void PlayDestroyElementSound(FieldElement element)
    {
        if (element.ElementType == TypesOfFieldElements.Token)
        {
            Token token = element as Token;
            switch (token.TokenType)
            {
                case TokenType.sand:
                    PlaySound(_soundSand);
                    break;
                case TokenType.spice:
                    PlaySound(_soundSpice);
                    break;
                default:
                    break;
            }
        }
        else if (element.ElementType == TypesOfFieldElements.Bonus)
        {
            Bonus bonus = element as Bonus;
            switch (bonus.BonusType)
            {
                case BonusType.bait:
                    PlaySound(_soundBait);
                    break;
                case BonusType.water:
                    PlaySound(_soundWater);
                    break;
                case BonusType.rocket:
                    PlaySound(_soundRocket);
                    break;
                default:
                    break;
            }
        }
        else if (element.ElementType == TypesOfFieldElements.Enemy)
        {
            Enemy enemy = element as Enemy;
            switch (enemy.EnemyType)
            {
                case EnemyType.solders:
                    PlaySound(_soundSolders);
                    break;
                case EnemyType.worm:
                    PlaySound(_soundWorm);
                    break;
                default:
                    break;
            }
        }
    }

    public void PlayOpenTileSound()
    {
        if (_soundToggle.isOn)
        {
            _openTileSound.Play();
        }
    }

    public void PlayGearSound()
    {
        if (_soundToggle.isOn)
        {
            _soundGear.Play();
        }
    }

    public void PlayMarketSound()
    {
        if (_soundToggle.isOn)
        {
            _soundMarket.Play();
        }
    }

    public void PlayButtonClickSound()
    {
        if (_soundToggle.isOn)
        {
            _soundButtonClick.Play();
        }
    }

    private void PlaySound(AudioSource sound)
    {
        if (_soundToggle.isOn)
        {
            sound.Play();
        }
    }

    public void SetSoundToggle(GameObject toggle)
    {
        _soundToggle = toggle.GetComponent<Toggle>();
    }
}