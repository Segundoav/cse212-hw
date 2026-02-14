using System;

public class TakingTurnsQueue
{
    private readonly PersonQueue _people = new();

    public int Length => _people.Length;

    /// <summary>
    /// Adds a person to the queue.
    /// </summary>
    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        _people.Enqueue(person);
    }

    /// <summary>
    /// Logic to get the next person and handle their turns.
    /// </summary>
    public Person GetNextPerson()
    {
        if (_people.Length == 0)
            throw new InvalidOperationException("No one in the queue.");

        Person person = _people.Dequeue();    

        if (person.Turns <= 0)
        {
            _people.Enqueue(person);
        }
        else if (person.Turns > 1)
        {
            person.Turns -=1;
            _people.Enqueue(person);
                
        }
        return person;
    }

    public override string ToString()
    {
        return _people.ToString();
    }
}