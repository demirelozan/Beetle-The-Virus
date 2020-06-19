
public interface ITakeDamage<T>
{
    void TakeDamage(T damageTaken);
}

public interface IDoDamage
{
    float AttackDamage();
}