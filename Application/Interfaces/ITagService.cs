using System.Collections.Generic;
using Domain.Models;

namespace Application.Interfaces
{
    public interface ITagService
    {
        Tag AddTag(Tag tag);
        Tag GetTag(int id);
        Tag UpdateTag(Tag tag);
        List<Tag> GetTags();
        public bool IsTagExist(string name);
        bool ControlTagIsExistWithParameters(int id, string name);
    }
}
