namespace GuardiansOfTheCode.Enemies;

public interface IEnemy
{
   int Health { get; }
   int Level { get; }
   void Attack(PrimaryPlayer player);
   void Defend(PrimaryPlayer player);
}
