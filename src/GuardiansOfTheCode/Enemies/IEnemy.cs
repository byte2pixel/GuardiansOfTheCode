using GuardiansOfTheCode.Player;
using GuardiansOfTheCode.Strategies;

namespace GuardiansOfTheCode.Enemies;

public interface IEnemy
{
   string Name { get; }
   int Level { get; }
   int Health { get; set; }
   int Armor { get; set; }
   int OvertimeDamage { get; set; }
   bool Paralyzed { get; set; }
   int ParalyzedFor { get; set; }
   int Attack(PrimaryPlayer player);
   void Defend(PrimaryPlayer player);
   IDamageIndicator DamageIndicator { get; }
   void Reset();
}
