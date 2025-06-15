using UnityEngine;
using System.Collections.Generic;

public class PlayerAttributes : MonoBehaviour
{
    // === Grupos ===
    public CombatStats       Combat    = new CombatStats();
    public SurvivalStats     Survival  = new SurvivalStats();
    public MovementStats     Movement  = new MovementStats();
    public ResourceStats     Resource  = new ResourceStats();
    public ProgressionStats  Progress  = new ProgressionStats();
    public SupportStats      Support   = new SupportStats();

    private void Awake()
    {
        // Inicializa todos os atributos
        Combat.Initialize();
        Survival.Initialize();
        Movement.Initialize();
        Resource.Initialize();
        Progress.Initialize();
        Support.Initialize();
    }

    private void Update()
    {
        float dt = Time.deltaTime;
        Combat.Update(dt);
        Survival.Update(dt);
        Movement.Update(dt);
        Resource.Update(dt);
        Progress.Update(dt);
        Support.Update(dt);
    }
}

// === Definição de cada grupo ===

[System.Serializable]
public class CombatStats
{
    [Header("Ataque")]
    public Attribute damage           = new Attribute();
    public float criticalChance      = 0.1f;
    public float criticalMultiplier  = 1.5f;
    public float range               = 1.0f;
    public float cooldown            = 1.0f;

    [Header("Defesa")]
    public Attribute damageReduction = new Attribute();
    public Attribute resistance      = new Attribute();
    public Attribute evasion         = new Attribute();
    public Attribute blockChance     = new Attribute();

    [Header("Habilidades")]
    public List<string> activeSkills  = new List<string>();
    public List<string> passiveSkills = new List<string>();

    public void Initialize()
    {
        damage.Initialize();
        damageReduction.Initialize();
        resistance.Initialize();
        evasion.Initialize();
        blockChance.Initialize();
    }

    public void Update(float dt)
    {
        damage.Update(dt);
        damageReduction.Update(dt);
        resistance.Update(dt);
        evasion.Update(dt);
        blockChance.Update(dt);
    }
}

[System.Serializable]
public class SurvivalStats
{
    [Header("Vida")]
    public Attribute health       = new Attribute();
    public float healthRegen      = 1f;   // HP por segundo
    public Attribute healthShield = new Attribute();

    [Header("Estamina")]
    public Attribute stamina      = new Attribute();
    public float staminaConsume   = 1f;
    public float staminaRegen     = 1f;

    public void Initialize()
    {
        health.Initialize();
        healthShield.Initialize();
        stamina.Initialize();
    }

    public void Update(float dt)
    {
        health.Update(dt);
        healthShield.Update(dt);
        stamina.Update(dt);
    }
}

[System.Serializable]
public class MovementStats
{
    [Header("Movimentação")]
    public float moveSpeed      = 5f;
    public float agility        = 1f;
    public float carryCapacity  = 10f;

    public void Initialize() { }
    public void Update(float dt) { }
}

[System.Serializable]
public class ResourceStats
{
    [Header("Recursos")]
    public int   transportCapacity = 20;
    public float gatherSpeed       = 1f;
    public float efficiency        = 1f;
    public List<string> resourceTypes = new List<string>();

    public void Initialize() { }
    public void Update(float dt) { }
}

[System.Serializable]
public class ProgressionStats
{
    [Header("Progressão e Personalização")]
    public int   level       = 1;
    public int   levelMax    = 100;
    public float currentXP   = 0f;
    public int   skillPoints = 0;
    // Uma árvore de habilidades poderia ser um ScriptableObject à parte

    public void Initialize() { }
    public void Update(float dt) { }
}

[System.Serializable]
public class SupportStats
{
    [Header("Suporte e Utilitários")]
    public float healAmount     = 0f;
    public float areaHealAmount = 0f;
    // Os buffs/debuffs “genéricos” já estão dentro de cada Attribute
    public void Initialize() { }
    public void Update(float dt) { }
}
