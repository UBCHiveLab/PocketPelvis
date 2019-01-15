using System;

public class Player
{
    public Player()
    {
    }

    public delegate void deathDelegate();
    public event deathDelegate deathEvent;

    void Die()
    {
        if (deathEvent != null)
        {
            deathEvent();
        }
    }
}
