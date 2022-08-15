﻿using Microsoft.EntityFrameworkCore;
using smartwallet1.web.Data.Entities;
using smartwallet1.web.Data.Repository.Interface;

namespace smartwallet1.web.Data.Repository
{
    public class LanguageRepository : ILanguageRepository

    {
        private readonly ApplicationDbContext _dbContext;

        public LanguageRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> Add(Language language)
        {
            _dbContext.Languages.Add(language);
            await _dbContext.SaveChangesAsync();
            return language.Id;
        }

        public async Task Delete(int id)
        {
            var language = await _dbContext.Languages.FirstOrDefaultAsync(c => c.Id == id);
            _dbContext.Languages.Remove(language!);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Language>> Get(string filter)
        {

            var languages = await _dbContext.Languages.ToListAsync();

            return (languages);
        }

        public async Task<Language> Get(int id)
        {
            var language = await _dbContext.Languages.FirstOrDefaultAsync(c => c.Id == id);

            return language;
        }

        public async Task Update(Language language)
        {
            _dbContext.Languages.Update(language);
            await _dbContext.SaveChangesAsync();
        }


    }
}
