using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class VisitEntity
    {
        public Guid Id { get; private set; }
        public Guid PersonId { get; private set; }

        public DateTime EntryTime { get; private set; }

        public DateTime? ExitTime { get; private set; }

        public PersonEntity? Person { get; private set; }

        public bool isActive => ExitTime == null;
        public TimeSpan?
        public VisitEntity(Guid personId, DateTime? entryTime = null)
        {
            if (personId == Guid.Empty)
            {
                throw new ArgumentException("El id de la persona no puede estar vacio", nameof(personId));
            }

            Id = Guid.NewGuid();
            PersonId = personId;
            EntryTime = entryTime ?? DateTime.UtcNow;
            ExitTime = null;
        }

        public void RegisterExit(DateTime? exitTime = null)
        {
            var exit = exitTime ?? DateTime.UtcNow;
            if (exitTime.HasValue)
            {
                throw new InvalidOperationException("Esta visita ya tiene una salida registrada");
            }

            if (exit <= EntryTime)
            {
                throw new ArgumentException("La hora de salida debe ser posterior a la hora de entrada", nameof(exitTime))
            }
        }
    }
}
