# Unity 2D Top-Down Player Stats & Movement System

Este repositório apresenta um conjunto de scripts em C# para Unity, ideal para projetos 2D top-down mobile, que incluem:

- Gerenciamento de atributos do jogador (stats) com suporte a buffs e debuffs.
- Movimentação em 2D usando o novo Input System (Input Actions) com joystick e WSAD.
- Editor customizado para organizar visualmente os atributos no Inspetor.

---

## 📂 Estrutura de Scripts

1. **Attribute.cs**

   - Classe genérica para representar um atributo (ex: `moveSpeed`, `health`).
   - Permite definir um valor base e aplicar modificadores (buffs/debuffs) com duração.

2. **PlayerAttributes.cs**

   - Componente `MonoBehaviour` que agrega diversos grupos de atributos:
     - **Combat** (ataque, defesa, habilidades)
     - **Survival** (vida, stamina)
     - **Movement** (velocidade, agilidade, capacidade de carga)
     - **Resource** (capacidade de transporte, eficiência)
     - **Progression** (nível, XP, pontos de habilidade)
     - **Support** (cura, buffs gerais)
   - Inicializa e atualiza todos os atributos a cada frame.

3. **PlayerAttributesEditor.cs**

   - Editor customizado para Unity que exibe cada grupo de atributos em **foldouts** no Inspetor.
   - Facilita a visualização e edição sem poluir o painel padrão.

4. **Player2DController.cs**

   - Controlador de movimentação 2D top-down usando `Rigidbody2D` + `Collider2D`.
   - Integração com o **Input System**: lê `Vector2 moveInput` de um Input Action chamado `Move` (teclado e joystick).
   - Lê `stats.Movement.moveSpeed.Value` para aplicar buffs, debuffs e upgrades permanentes.

---

## 🚀 Como Usar

### 1. Estrutura no Projeto

Coloque os arquivos nas seguintes pastas:

```
Assets/
├─ Scripts/
│  ├─ Stats/
│  │  ├─ Attribute.cs
│  │  └─ PlayerAttributes.cs
│  ├─ Player2DController.cs
│  └─ Editor/
│     └─ PlayerAttributesEditor.cs
└─ Input/
   └─ PlayerControls.inputactions  (Input Action Asset)
```

### 2. Configuração do Input System

1. Instale o **Input System** via Package Manager.
2. Crie um **Input Actions Asset** (ex: `PlayerControls.inputactions`).
3. No Action Map `Gameplay`, defina a Action `Move` (tipo **Value/Vector2**) com bindings:
   - `<Gamepad>/leftStick`
   - `WASD` e `Arrow Keys` (teclado)
4. Marque **Generate C# Class** no asset e gere a classe `PlayerControls`.

### 3. Configuração do GameObject Player

1. Crie ou selecione seu GameObject `Player`.
2. Adicione os componentes (Add Component):
   - **Rigidbody2D**
     - Body Type: Dynamic
     - Gravity Scale: 0
   - **Collider2D** (ex: Circle, Capsule)
   - **PlayerAttributes**
   - **Player2DController**
3. No Inspetor, abra os foldouts de **Combate**, **Sobrevivência**, **Movimentação** etc., e ajuste os valores base (baseValue) de cada atributo.

### 4. Aplicando Buffs e Debuffs

Em qualquer script, para adicionar um buff temporário:

```csharp
var stats = GetComponent<PlayerAttributes>();
// +3 de velocidade por 5 segundos:
stats.Movement.moveSpeed.AddModifier(new AttributeModifier("SprintBuff", +3f, 5f));
```

### 5. Upgrades Permanentes

- **Via setter de baseValue** (se exposto).
- **Via modificador infinito**:

```csharp
stats.Movement.moveSpeed.AddModifier(
    new AttributeModifier("BootsUpgrade", +2f, Mathf.Infinity)
);
```

---

## 🔧 Extensibilidade

- **Novos grupos**: crie uma classe `[System.Serializable]` e adicione como campo em `PlayerAttributes`.
- **Novos atributos**: adicione um `Attribute` ou campo primitivo na classe de grupo correspondente.
- **Custom Inspector**: ajuste `PlayerAttributesEditor.cs` para incluir novos foldouts.

---

## 🤝 Contribuições

Pull requests são bem-vindos! Sinta-se livre para sugerir melhorias ou reportar issues.

---

## 📄 Licença

MIT License. Feel free to use and adapt!



---

*Created by JyanDev*

