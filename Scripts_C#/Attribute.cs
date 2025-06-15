using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Attribute
{
    [SerializeField] private float baseValue;
    [HideInInspector] public float currentValue;

    private List<AttributeModifier> modifiers = new List<AttributeModifier>();

    // Inicializa o atributo (chamar em Awake/Start)
    public void Initialize()
    {
        currentValue = baseValue;
    }

    // Valor público já com modificadores
    public float Value => currentValue;

    // Adiciona um buff/debuff
    public void AddModifier(AttributeModifier mod)
    {
        modifiers.Add(mod);
        Recalculate();
    }

    // Remove um modificador específico
    public void RemoveModifier(AttributeModifier mod)
    {
        if (modifiers.Remove(mod))
            Recalculate();
    }

    // Chamar todo frame para expirar modifiers
    public void Update(float deltaTime)
    {
        bool dirty = false;
        for (int i = modifiers.Count - 1; i >= 0; i--)
        {
            modifiers[i].duration -= deltaTime;
            if (modifiers[i].duration <= 0f)
            {
                modifiers.RemoveAt(i);
                dirty = true;
            }
        }
        if (dirty) Recalculate();
    }

    private void Recalculate()
    {
        float total = baseValue;
        foreach (var m in modifiers) total += m.value;
        currentValue = total;
    }
}

[System.Serializable]
public class AttributeModifier
{
    public string name;       // ridículo útil para debug/logs
    public float value;       // ex: +5 de dano, -10% de velocidade
    public float duration;    // em segundos

    public AttributeModifier(string name, float value, float duration)
    {
        this.name = name;
        this.value = value;
        this.duration = duration;
    }
}
