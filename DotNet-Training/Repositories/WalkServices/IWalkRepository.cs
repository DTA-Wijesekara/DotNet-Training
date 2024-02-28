﻿using DotNet_Training.Models.Domains;
using DotNet_Training.Models.DTO.walksDtos;

namespace DotNet_Training.Repositories.WalkServices
{
    public interface IWalkRepository
    {
        Task<Walk> CreateAsync(Walk walk);
        Task<List<Walk>> GetAllAsync(
            string? filterOn = null, string? filterQuery = null, 
            string? sortBy = null, bool isAscending = true ,
            int pageNumber = 1 , int pageSize =100);
        Task<Walk?> GetByIdAsync(Guid id);
        Task<Walk?> UpdateAsync(Guid id , Walk walk);
        Task<Region?> DeleteAsync(Guid id);
    }
}
