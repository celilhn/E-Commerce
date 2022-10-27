using System.Collections.Generic;
using System.Linq;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly ECommerceDbContext context;
        public TagRepository(ECommerceDbContext context)
        {
            this.context = context;
        }

        public Tag AddTag(Tag tag)
        {
            context.Tagss.Add(tag);
            context.SaveChanges();
            return tag;
        }

        public Tag GetTag(int id)
        {
            return context.Tagss.SingleOrDefault(x => x.Id == id);
        }

        public Tag UpdateTag(Tag tag)
        {
            context.Entry(tag).State = EntityState.Modified;
            context.SaveChanges();
            return tag;
        }

        public List<Tag> GetTags()
        {
            return context.Tagss.ToList();
        }
    }
}
