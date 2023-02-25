using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private LifeIcon _lifeIcon;
    [SerializeField] private Player _player;
    
    private List<LifeIcon> _icons = new List<LifeIcon>();

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(int health)
    {
        int difference = Mathf.Abs(health - _icons.Count);

        if (health > _icons.Count)
            CorrectIconsNumber(difference, CreateLifeIcon);
        
        if (health < _icons.Count)
            CorrectIconsNumber(difference, DeleteLastIcon);
    }

    private void CorrectIconsNumber(int correctionCount, CorrectionAct correctionAct)
    {
        for (int i = 0; i < correctionCount; i++)
        {
            correctionAct();
        }
    }

    private void CreateLifeIcon()
    {
        LifeIcon newLife = Instantiate(_lifeIcon, transform);
        newLife.Fill();
        _icons.Add(newLife);
    }

    private void DeleteLastIcon()
    {
        LifeIcon iconToDelete = _icons[_icons.Count - 1];
        iconToDelete.Empty();
        _icons.Remove(iconToDelete);
    }

    private delegate void CorrectionAct();
}
