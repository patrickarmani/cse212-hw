using System;
using System.Collections.Generic;

/// <summary>
/// Circular queue of people taking turns.
/// People are added to the back of the queue (FIFO).
/// When GetNextPerson is called, the next person is returned and
/// then placed back at the end of the queue unless they are out of turns.
/// A turns value of 0 or less means infinite turns and must NOT be modified.
/// If the queue is empty, GetNextPerson throws InvalidOperationException
/// with the message "No one in the queue."
/// </summary>
public class TakingTurnsQueue
{
    private readonly PersonQueue _people = new();

    public int Length => _people.Length;

    /// <summary>
    /// Adds a new person to the queue with the given name and turns.
    /// This method preserves FIFO order even if the underlying PersonQueue
    /// behaves like a stack (LIFO) by rotating elements.
    /// </summary>
    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);

        // Drain current items to preserve their relative order.
        var old = new List<Person>();
        while (!_people.IsEmpty())
            old.Add(_people.Dequeue());

        // Enqueue the new person so they end up at the back of the queue.
        _people.Enqueue(person);

        // Rebuild the structure so the oldest remains next-out.
        for (int i = old.Count - 1; i >= 0; i--)
            _people.Enqueue(old[i]);
    }

    /// <summary>
    /// Returns the next person. If they still have turns (or infinite turns),
    /// they are placed back at the end of the queue. If they were on their
    /// last finite turn, they are not re-enqueued.
    /// Throws InvalidOperationException if the queue is empty.
    /// </summary>
    public Person GetNextPerson()
    {
        if (_people.IsEmpty())
            throw new InvalidOperationException("No one in the queue.");

        // Take the next person (the oldest in FIFO terms).
        var person = _people.Dequeue();

        // Capture the remainder to rotate the underlying structure
        // (required if PersonQueue is implemented as LIFO).
        var rest = new List<Person>();
        while (!_people.IsEmpty())
            rest.Add(_people.Dequeue());

        // Decide whether to re-enqueue and consume one finite turn if applicable.
        bool requeue = person.Turns <= 0 || person.Turns > 1; // infinite or more than 1 left
        if (person.Turns > 1)
            person.Turns -= 1; // do NOT modify if infinite (<= 0)

        // Place the served person at the back if needed.
        if (requeue)
            _people.Enqueue(person);

        // Rebuild so the next-oldest is served next.
        for (int i = rest.Count - 1; i >= 0; i--)
            _people.Enqueue(rest[i]);

        return person;
    }

    public override string ToString() => _people.ToString();
}
