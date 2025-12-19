using Diagnosis.Application.DTOs;
using Diagnosis.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diagnosis.Domain.Models.Entites;


namespace Diagnosis.Application.UseCases
{
    public class DrugSuggestionUseCase
    {
        private readonly  IDrugCheckerProvider _drugCheckerProvider;

        public DrugSuggestionUseCase(IDrugCheckerProvider drugSuggestionProvider)
        {
            _drugCheckerProvider = drugSuggestionProvider;
        }

        public async Task<List<DrugSuggestionDTO>> GetSuggestionsAsync(string keyword)
        {
            return await _drugCheckerProvider.GetSuggestionsAsync(keyword);
        }
    }
    }