// Create a `GameCharacter` class with a method `Attack()`. Derive `Warrior` and `Mage` classes that override the `Attack()` method.
using System;
namespace PolymorphismPrac7
{
    public class GameCharacter
    {
        public virtual void Attack()
        {
            Console.WriteLine("GameChanger is Attacking");
        }
    }
    public class Warrior : GameCharacter
    {
        public override void Attack()
        {
            Console.WriteLine("Warrior is Attaking");
        }
    }
    public class Mage : GameCharacter
    {
        public override void Attack()
        {
            Console.WriteLine("Mage is Attacking");
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            GameCharacter a1= new GameCharacter();
            GameCharacter a2 = new Warrior();
            GameCharacter a3 = new Mage();
            a1.Attack();
            a2.Attack();
            a3.Attack();
        }
    }
}