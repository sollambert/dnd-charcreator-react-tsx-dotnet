using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace dnd_buddy.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Alignments { LG, NG, CG, LN, TN, CN, LE, NE, CE }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SkillProficiency { NONE, PROFICIENT, EXPERT }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Skill
    {
        ACROBATICS,
        ANIMAL_HANDLING,
        ARCANA,
        ATHLETICS,
        DECEPTION,
        HISTORY,
        INSIGHT,
        INTIMIDATION,
        INVESTIGATION,
        MEDICINE,
        NATURE,
        PERCEPTION,
        PERFORMANCE,
        PERSUASION,
        RELIGION,
        SLEIGHT_OF_HAND,
        STEALTH,
        SURVIVAL
    }
    public class Character
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = "";
        public byte Strength { get; set; }
        public byte Dexterity { get; set; }
        public byte Constitution { get; set; }
        public byte Intelligence { get; set; }
        public byte Wisdom { get; set; }
        public byte Charisma { get; set; }
        public string Background { get; set; } = "";
        public string Race { get; set; } = "";
        public string Profession { get; set; } = "";
        public string Player { get; set; } = "";
        public int Experience { get; set; } = 0;
        public byte Inspiration { get; set; } = 0;
        public Alignments Alignment { get; set; } = Alignments.TN;
        public bool StrProf { get; set; } = false;
        public bool DexProf { get; set; } = false;
        public bool ConProf { get; set; } = false;
        public bool IntProf { get; set; } = false;
        public bool WisProf { get; set; } = false;
        public bool ChaProf { get; set; } = false;
        public List<CharacterSkill> Skills { get; set; }
        public Character()
        {
            this.Strength = RollStat();
            this.Dexterity = RollStat();
            this.Constitution = RollStat();
            this.Intelligence = RollStat();
            this.Wisdom = RollStat();
            this.Charisma = RollStat();
            // this.Skills = new List<CharacterSkill> {
            // new(Skill.ACROBATICS, SkillProficiency.NONE),
            // new(Skill.ANIMAL_HANDLING, SkillProficiency.NONE),
            // new(Skill.ARCANA, SkillProficiency.NONE),
            // new(Skill.ATHLETICS, SkillProficiency.NONE),
            // new(Skill.DECEPTION, SkillProficiency.NONE),
            // new(Skill.HISTORY, SkillProficiency.NONE),
            // new(Skill.INSIGHT, SkillProficiency.NONE),
            // new(Skill.INTIMIDATION, SkillProficiency.NONE),
            // new(Skill.INVESTIGATION, SkillProficiency.NONE),
            // new(Skill.MEDICINE, SkillProficiency.NONE),
            // new(Skill.NATURE, SkillProficiency.NONE),
            // new(Skill.PERCEPTION, SkillProficiency.NONE),
            // new(Skill.PERFORMANCE, SkillProficiency.NONE),
            // new(Skill.PERSUASION, SkillProficiency.NONE),
            // new(Skill.RELIGION, SkillProficiency.NONE),
            // new(Skill.SLEIGHT_OF_HAND, SkillProficiency.NONE),
            // new(Skill.STEALTH, SkillProficiency.NONE),
            // new(Skill.SURVIVAL, SkillProficiency.NONE)
        //};
        }
        public byte RollStat()
        {
            Random random = new Random();
            List<byte> rolls = new List<byte>();
            for (int i = 0; i < 5; i++)
            {
                byte roll = (byte)random.NextInt64(1, 7);
                rolls.Add(roll);
            }
            rolls.Sort();
            byte stat = (byte)(rolls[2] + rolls[3] + rolls[4]);
            return stat;
        }

        public class CharacterSkill
        {
            public int Id { get; set; }
            [ForeignKey("Character")]
            public int CharacterId { get; set; }
            public Skill Skill { get; set; }
            public SkillProficiency Proficiency { get; set; }
            public CharacterSkill(Skill Skill, SkillProficiency Proficiency)
            {
                this.Skill = Skill;
                this.Proficiency = Proficiency;
            }
            [JsonConstructorAttribute]
            public CharacterSkill(int Id, int CharacterId, Skill Skill, SkillProficiency Proficiency)
            {
                this.Id = Id;
                this.CharacterId = CharacterId;
                this.Skill = Skill;
                this.Proficiency = Proficiency;
            }
        }
    }
}