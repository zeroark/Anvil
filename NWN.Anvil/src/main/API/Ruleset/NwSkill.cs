using System.Linq;
using Anvil.Services;
using NWN.Native.API;

namespace Anvil.API
{
  /// <summary>
  /// A creature/character skill definition.
  /// </summary>
  public sealed class NwSkill
  {
    [Inject]
    private static TlkTable TlkTable { get; set; }

    private readonly CNWSkill skillInfo;

    public NwSkill(Skill skillType, CNWSkill skillInfo)
    {
      this.skillInfo = skillInfo;
      SkillType = skillType;
    }

    /// <summary>
    /// Gets if this skill can be used by all classes.
    /// </summary>
    public bool AllClassesCanUse
    {
      get => skillInfo.m_bAllClassesCanUse.ToBool();
    }

    /// <summary>
    /// Gets if this skill is subject to the armor check penalty.
    /// </summary>
    public bool ArmorCheckPenalty
    {
      get => skillInfo.m_bArmorCheckPenalty.ToBool();
    }

    /// <summary>
    /// Gets the description of this skill.
    /// </summary>
    public string Description
    {
      get => TlkTable.GetSimpleString((uint)skillInfo.m_nDescriptionStrref);
    }

    /// <summary>
    /// Gets the ResRef of the GUI icon representing this skill.
    /// </summary>
    public string IconResRef
    {
      get => skillInfo.m_sIconName.ToString();
    }

    /// <summary>
    /// Gets if this skill is considered a hostile action.
    /// </summary>
    public bool IsHostileSkill
    {
      get => skillInfo.m_bHostileSkill.ToBool();
    }

    /// <summary>
    /// Gets if this skill is untrained. Trained skills require at least a single rank before they can be used.
    /// </summary>
    public bool IsUntrained
    {
      get => skillInfo.m_bUntrained.ToBool();
    }

    /// <summary>
    /// Gets the ability that the skill uses as
    /// </summary>
    public Ability KeyAbility
    {
      get => (Ability)skillInfo.m_nKeyAbility;
    }

    /// <summary>
    /// Gets the name of this skill.
    /// </summary>
    public string Name
    {
      get => TlkTable.GetSimpleString((uint)skillInfo.m_nNameStrref);
    }

    /// <summary>
    /// Gets the associated <see cref="Skill"/> type for this skill.
    /// </summary>
    public Skill SkillType { get; }

    /// <summary>
    /// Resolves a <see cref="NwSkill"/> from a skill id.
    /// </summary>
    /// <param name="skillId">The id of the skill to resolve.</param>
    /// <returns>The associated <see cref="NwSkill"/> instance. Null if the skill id is invalid.</returns>
    public static NwSkill FromSkillId(int skillId)
    {
      return NwRuleset.Skills.ElementAtOrDefault(skillId);
    }

    /// <summary>
    /// Resolves a <see cref="NwSkill"/> from a <see cref="Anvil.API.Skill"/>.
    /// </summary>
    /// <param name="skillType">The skill type to resolve.</param>
    /// <returns>The associated <see cref="NwSkill"/> instance. Null if the skill type is invalid.</returns>
    public static NwSkill FromSkillType(Skill skillType)
    {
      return NwRuleset.Skills.ElementAtOrDefault((int)skillType);
    }
  }
}