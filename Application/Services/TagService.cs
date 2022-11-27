using System;
using System.Collections.Generic;
using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository tagRepository;
        public TagService(ITagRepository tagRepository)
        {
            this.tagRepository = tagRepository;
        }

        public Tag AddTag(Tag tag)
        {
            return tagRepository.AddTag(tag);
        }

        public Tag GetTag(int id)
        {
            return tagRepository.GetTag(id);
        }

        public Tag UpdateTag(Tag tag)
        {
            tag.UpdateDate = DateTime.Now;
            return tagRepository.UpdateTag(tag);
        }

        public List<Tag> GetTags()
        {
            return tagRepository.GetTags();
        }

        public bool IsTagExist(string name)
        {
            return tagRepository.IsTagExist(name);
        }

        public bool ControlTagIsExistWithParameters(int id, string name)
        {
            return tagRepository.ControlTagIsExistWithParameters(id, name);
        }
    }
}
