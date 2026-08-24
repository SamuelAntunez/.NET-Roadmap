using Domain;
using Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Persons
{
    public class GetPersonByCodeuseCase
    {
        private readonly ICodeRepository<PersonEntity> _codeRepository;

        public GetPersonByCodeuseCase(ICodeRepository<PersonEntity> codeRepository)
        {
            _codeRepository = codeRepository;
        }

        public async Task<PersonEntity> ExecuteAsync(string code)
        {
            var person = await _codeRepository.GetCodeAsync(code);
            if (person == null)
            {
                throw new InvalidOperationException($"Person with code '{code}' not found.");
            }
            return person;
        }

    }
}
