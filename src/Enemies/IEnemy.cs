using GuardiansOfTheCode.Player;

namespace GuardiansOfTheCode.Enemies;

public interface IEnemy
{
   int Level { get; }
   int Health { get; set; }
   int Armor { get; set; }
   int OvertimeDamage { get; set; }
   bool Paralyzed { get; set; }
   int ParalyzedFor { get; set; }
   void Attack(PrimaryPlayer player);
   void Defend(PrimaryPlayer player);
}
