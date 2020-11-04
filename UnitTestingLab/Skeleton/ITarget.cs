namespace Skeleton
{
    public interface ITarget
    {

        public int GiveExperience();
        public bool IsDead();
        public void TakeAttack(int attackPoints);
    }
}