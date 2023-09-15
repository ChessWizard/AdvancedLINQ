using AdvancedLINQ.Core.Entities;
using AdvancedLINQ.Data.Context;
using AdvancedLINQ.Shared.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedLINQ.Core.Enums;

namespace AdvancedLINQ.Data.Seeds
{
    public static class CategorySeeds
    {
        public static async Task AddSeedCategories(AdvancedLINQDbContext context)
        {
            var categories = await context.Categories
                .AsNoTracking()
                .ToListAsync();

            if (categories.IsNullOrNotAny())
            {
                List<Category> addingCategories = new()
                {
                    new(){CategoryType = CategoryType.Other, Description = "Belirli bir kategoriye ait değil.", Title = "Diğer"},
                    new(){CategoryType = CategoryType.Horror, Description = "Korku kategorisi.", Title = "Korku"},
                    new(){CategoryType = CategoryType.Thriller, Description = "Gerilim kategorisi.", Title = "Gerilim"},
                    new(){CategoryType = CategoryType.Drama, Description = "Dram kategorisi.", Title = "Dram"},
                    new(){CategoryType = CategoryType.Action, Description = "Aksiyon kategorisi.", Title = "Aksiyon"},
                    new(){CategoryType = CategoryType.Comedy, Description = "Komedi kategorisi.", Title = "Komedi"},
                    new(){CategoryType = CategoryType.Romance, Description = "Romantik kategorisi.", Title = "Romantik"},
                    new(){CategoryType = CategoryType.ScienceFiction, Description = "Bilim-kurgu kategorisi.", Title = "Bilim-kurgu"},
                    new(){CategoryType = CategoryType.Fantastic, Description = "Fantastik kategorisi.", Title = "Fantastik"},
                    new(){CategoryType = CategoryType.Mystery, Description = "Gizem kategorisi.", Title = "Gizem"},
                    new(){CategoryType = CategoryType.Adventure, Description = "Macera kategorisi.", Title = "Macera"},
                    new(){CategoryType = CategoryType.Crime, Description = "Suç kategorisi.", Title = "Suç"},
                    new(){CategoryType = CategoryType.Animation, Description = "Animasyon kategorisi.", Title = "Animasyon"},
                    new(){CategoryType = CategoryType.Documentary, Description = "Belgesel kategorisi.", Title = "Belgesel"},
                };
                await context.Categories.AddRangeAsync(addingCategories);
                await context.SaveChangesAsync();
            }
        }
    }
}
