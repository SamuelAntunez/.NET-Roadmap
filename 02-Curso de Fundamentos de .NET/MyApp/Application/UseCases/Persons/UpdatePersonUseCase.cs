using Application.DTO.Persons;
using Domain;
using Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Persons
{
    public class UpdatePersonUseCase
    {
        private readonly IRepository<PersonEntity, Guid> _repository;

        public UpdatePersonUseCase(IRepository<PersonEntity, Guid> repository)
        {
            _repository = repository;
        }

        public async Task<PersonEntity> ExecuteAsync(UpdatePersonDto dto)
        {
            var person = await _repository.GetByIdAsync(dto.id);
            if (person == null)
            {
                throw new InvalidOperationException($"Person with id {dto.id} not found.");
            }
            person.UpdatePersonalInfo(dto.FirstName, dto.LastName, dto.Email, dto.Phone);
            await _repository.UpdateAsync(person);
            return person;
        }
    }
}
