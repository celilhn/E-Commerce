using System.Collections.Generic;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface ITagRepository
    {
        Tag AddTag(Tag tag);
        Tag GetTag(int id);
        Tag UpdateTag(Tag tag);
        List<Tag> GetTags();
        public bool IsTagExist(string name);
        bool ControlTagIsExistWithParameters(int id, string name);
    }
}
