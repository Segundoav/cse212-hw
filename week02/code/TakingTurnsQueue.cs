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

    // Caso 1: turnos > 1 → reduce y reencola
    if (person.Turns > 1)
    {
        person.Turns--;
        _people.Enqueue(person);
    }
    // Caso 2: turnos == 1 → juega y NO se reencola
    else if (person.Turns == 1)
    {
        person.Turns = 0; // No necesario reencolar
    }
    // Caso 3: turnos == 0 → juega para siempre
    else if (person.Turns == 0)
    {
        _people.Enqueue(person);
    }
    // Caso 4: turnos < 0 → infinito
    else if (person.Turns < 0)
    {
        _people.Enqueue(person);
    }

    return person;
}



    public override string ToString()
    {
        return _people.ToString();
    }
}